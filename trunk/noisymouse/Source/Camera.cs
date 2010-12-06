using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using EDSDKLib;
using Source.Utils;


namespace Source
{
    public delegate void OnCameraReadyDelegate();

    public delegate void OnImageRecievedDelegate(byte[] anImage);

    public interface ICameraNotifications
    {
        void ShuttedDown();
        void WillSoonShutDown(ICamera aCamera);
        void CameraDone();
        void Log(string message);
    }

    public interface ICanHandleImage
    {
        void ImageRecieved(ImageFile imageFile);
    }

    public interface ICamera: IDisposable
    {
        string Id { get; }
        string ProductName { get; }
        string OwnerName { get; }
        
        uint IsoSpeed { get; set; }
        uint ApertureValue { get; set; }
        uint ExposalValue { get; set; }
        uint ImageQualityValue { get; set; }
        uint SaveToValue { set; }

        void SetProperty<T>(uint propertyId, T value);
        uint[] GetAvailableValues(uint aType);
        void UnlockUI();
        void LockUI();
        void Shoot(IImageHandler imageHandler);
        void PressShutterButton(IImageHandler imageHandler);

        string DisplayString { get; }
        void KeepALive();

        void StartLiveView(Action<uint> whenReady);
        void StopLiveView(Action<uint> whenReady);
        void MoveFocus(uint value);

        void DownloadLiveViewImage(Action<IntPtr, uint> onImageRecieved);
        void SetDownloadImageHandler(IImageHandler imageHandler);
    }

    public class CameraEvent
    {
        protected Action<uint> Handler { set; get; }
        public bool RunOnce { protected set; get; }
        protected uint PropertyId { set; get; }

        public CameraEvent(Action<uint> handler, bool runOnce, uint propertyId)
        {
            Handler = handler;
            RunOnce = runOnce;
            PropertyId = propertyId;
        }

        internal void Process(uint propertyId, uint inParameter)
        {
            if (propertyId == PropertyId)
            {
                //Handler.BeginInvoke(inParameter, null, null);
                Handler(inParameter);
            }
        }
    }

    public class Camera : ICamera
    {
        public const int BUFFER_SIZE = 2 * 1024 * 1024;


        private static readonly object _synchronizationObject = new object();
        private static readonly object _eventHandlersSync = new object();

        private bool _shouldRelease = true;
        private bool _disposed = false;

        private readonly TemporaryFolder _folder = new TemporaryFolder();
        private readonly EDSDK.EdsObjectEventHandler _onCameraEvent;
        private readonly EDSDK.EdsStateEventHandler _onCameraStateChanged;
        private readonly EDSDK.EdsPropertyEventHandler _onCameraPropertyChanged;
        private readonly IntPtr _pointer = IntPtr.Zero;
        private readonly ICameraNotifications _cameraNotifications;

        private IImageHandler _imageHandler;
        private List<CameraEvent> _eventHandlers;

        public Camera(IntPtr aPointer, ICameraNotifications aCameraNotifications)
        {
            _onCameraEvent = DownloadImage;
            _onCameraStateChanged = CameraStateChanged;
            _onCameraPropertyChanged = CameraPropertyChanged;
            _pointer = aPointer;
            _cameraNotifications = aCameraNotifications;
            _eventHandlers = new List<CameraEvent>();

            SDKHelper.CheckError(EDSDK.EdsOpenSession(_pointer));
            SDKHelper.CheckError(EDSDK.EdsSetObjectEventHandler(_pointer, EDSDK.ObjectEvent_All, _onCameraEvent, IntPtr.Zero));
            SDKHelper.CheckError(EDSDK.EdsSetCameraStateEventHandler(_pointer, EDSDK.StateEvent_All, _onCameraStateChanged, IntPtr.Zero));
            SDKHelper.CheckError(EDSDK.EdsSetPropertyEventHandler(_pointer, EDSDK.PropertyEvent_All, _onCameraPropertyChanged, IntPtr.Zero));
        }

        public string Id
        {
            get { return GetStringProperty(EDSDK.PropID_BodyID); }
        }

        public string ProductName
        {
            get { return GetStringProperty(EDSDK.PropID_ProductName); }
        }

        public string OwnerName
        {
            get { return GetStringProperty(EDSDK.PropID_OwnerName); }
        }

        public uint IsoSpeed
        {
            get { return GetIntProperty(EDSDK.PropID_ISOSpeed); }
            set { SetProperty(EDSDK.PropID_ISOSpeed, value); }
        }

        public uint ApertureValue
        {
            get { return GetIntProperty(EDSDK.PropID_Av); }
            set { SetProperty(EDSDK.PropID_Av, value); }
        }

        public uint ExposalValue
        {
            get { return GetIntProperty(EDSDK.PropID_Tv); }
            set { SetProperty(EDSDK.PropID_Tv, value); }
        }

        public uint ImageQualityValue
        {
            get { return GetIntProperty(EDSDK.PropID_ImageQuality); }
            set { SetProperty(EDSDK.PropID_ImageQuality, value); }
        }

        public uint SaveToValue
        {
            set { SetProperty(EDSDK.PropID_SaveTo, value); }
        }

        public void Dispose()
        {
            _folder.Dispose();
            if (_shouldRelease)
            {
                SDKHelper.CheckError(EDSDK.EdsCloseSession(_pointer));
                SDKHelper.CheckError(EDSDK.EdsRelease(_pointer));
            }
            _disposed = true;
        }

        public uint[] GetAvailableValues(uint aPropertyType)
        {
            CameraAlreadyDisposedException.ThrowIf(_disposed);
            EDSDK.EdsPropertyDesc propertyDesc;
            try
            {
                SDKHelper.CheckError(EDSDK.EdsGetPropertyDesc(_pointer, aPropertyType, out propertyDesc));
                int[] result = new int[propertyDesc.NumElements];
                Array.Copy(propertyDesc.PropDesc, result, result.Length);
                return Array.ConvertAll(result, new Converter<int,uint>(int32 => Convert.ToUInt32(int32)));
            }
            catch(SDKInvalidParameterExeption)
            {
                return new uint[0];
            }
        }

        private uint GetIntProperty(uint aPropertyId)
        {
            CameraAlreadyDisposedException.ThrowIf(_disposed);
            uint result;
            SDKHelper.CheckError(EDSDK.EdsGetPropertyData(_pointer, aPropertyId, 0, out result));
            return result;
        }

        private string GetStringProperty(uint aPropertyId)
        {
            CameraAlreadyDisposedException.ThrowIf(_disposed);
            string result;
            SDKHelper.CheckError(EDSDK.EdsGetPropertyData(_pointer, aPropertyId, 0, out result));
            return result;
        }

        public void SetProperty<T>(uint propertyId, T value)
        {
            CameraAlreadyDisposedException.ThrowIf(_disposed);
            SDKHelper.CheckError(EDSDK.EdsSetPropertyData(_pointer, propertyId, 0, sizeof(int), value));
        }

        public void UnlockUI()
        {
            CameraAlreadyDisposedException.ThrowIf(_disposed);
            SDKHelper.CheckError(EDSDK.EdsSendStatusCommand(_pointer, EDSDK.CameraState_UIUnLock, 0));
        }

        public void LockUI()
        {
            CameraAlreadyDisposedException.ThrowIf(_disposed);
            SDKHelper.CheckError(EDSDK.EdsSendStatusCommand(_pointer, EDSDK.CameraState_UILock, 0));
        }

        private uint DownloadImage(uint inEvent, IntPtr inRef, IntPtr inContext)
        {
            _cameraNotifications.Log(string.Format("Camera event: {0}", SDKHelper.DecodeEvent(inEvent)));

            lock (_synchronizationObject)
            {
                try
                {
                    if (inEvent == EDSDK.ObjectEvent_DirItemRequestTransfer)
                    {
                        if (_imageHandler != null)
                        {
                            _imageHandler.Handle(GetImageFile(inRef, _folder));
                        }
                        _cameraNotifications.CameraDone();
                    }
                    if (inEvent == EDSDK.ObjectEvent_DirItemCreated)
                    {
                        _cameraNotifications.CameraDone();
                    }
                }
                finally
                {
                    if (inRef != IntPtr.Zero) SDKHelper.CheckError(EDSDK.EdsRelease(inRef));
                }
                return 0;
            }
        }

        private ImageFile GetImageFile(IntPtr inRef, Folder aFolder)
        {
            EDSDK.EdsDirectoryItemInfo directoryItemInfo = GetDirectoryItemInfo(inRef);
            string filename = aFolder.ComposeFilename(directoryItemInfo.szFileName);
            IntPtr stream = GetFileStream(filename);
            try
            {
                SDKHelper.CheckError(EDSDK.EdsDownload(inRef, directoryItemInfo.Size, stream));
                SDKHelper.CheckError(EDSDK.EdsDownloadComplete(inRef));
            }
            catch
            {
                SDKHelper.CheckError(EDSDK.EdsDownloadCancel(inRef));
                throw;
            }
            finally
            {
                SDKHelper.CheckError(EDSDK.EdsRelease(stream));
            }
            return new ImageFile(File.ReadAllBytes(filename), directoryItemInfo.szFileName);
        }

        private static IntPtr GetFileStream(string filename)
        {
            IntPtr stream;
            SDKHelper.CheckError(EDSDK.EdsCreateFileStream(filename, EDSDK.EdsFileCreateDisposition.CreateAlways,
                                                           EDSDK.EdsAccess.ReadWrite, out stream));
            return stream;
        }

        private static EDSDK.EdsDirectoryItemInfo GetDirectoryItemInfo(IntPtr inRef)
        {
            EDSDK.EdsDirectoryItemInfo directoryItemInfo;
            SDKHelper.CheckError(EDSDK.EdsGetDirectoryItemInfo(inRef, out directoryItemInfo));
            return directoryItemInfo;
        }

        public void Shoot(IImageHandler imageHandler)
        {
            EDSDK.EdsCapacity capacity = new EDSDK.EdsCapacity();
            capacity.BytesPerSector = 1000;
            capacity.NumberOfFreeClusters = (int)UInt16.MaxValue;
            capacity.Reset = 1;

            SDKHelper.CheckError(EDSDK.EdsSetCapacity(_pointer, capacity));

            SendShootCommand(imageHandler, EDSDK.CameraCommand_TakePicture, (int)0);
        }

        public void PressShutterButton(IImageHandler imageHandler)
        {
            CameraAlreadyDisposedException.ThrowIf(_disposed);
            lock (_synchronizationObject)
            {
                SDKHelper.CheckError(EDSDK.EdsSendCommand(_pointer, EDSDK.CameraCommand_PressShutterButton, (int)EDSDK.EdsShutterButton.CameraCommand_ShutterButton_Completely_NonAF));
                SDKHelper.CheckError(EDSDK.EdsSendCommand(_pointer, EDSDK.CameraCommand_PressShutterButton, (int)EDSDK.EdsShutterButton.CameraCommand_ShutterButton_OFF));
                _imageHandler = imageHandler;
            }
        }

        private void SendShootCommand(IImageHandler imageHandler, uint command, int value)
        {
            CameraAlreadyDisposedException.ThrowIf(_disposed);
            lock (_synchronizationObject)
            {
                SDKHelper.CheckError(EDSDK.EdsSendCommand(_pointer, command, value));
                _imageHandler = imageHandler;
            }

        }

        public string DisplayString
        {
            get { return string.Format("{0}", ProductName); }
        }

        public void KeepALive()
        {
            CameraAlreadyDisposedException.ThrowIf(_disposed);
            SDKHelper.CheckError(EDSDK.EdsSendCommand(_pointer, EDSDK.CameraCommand_ExtendShutDownTimer, 0));
        }

        public override string ToString()
        {
            return DisplayString;
        }

        private uint CameraStateChanged(uint inEvent, uint inParameter, IntPtr inContext)
        {
            _cameraNotifications.Log(string.Format("Camera state event: {0}, {1}", inEvent, inParameter));

            if (inEvent == EDSDK.StateEvent_Shutdown)
            {
                _shouldRelease = false;
                _cameraNotifications.ShuttedDown();
            }
            if (inEvent == EDSDK.StateEvent_WillSoonShutDown)
            {
                _cameraNotifications.WillSoonShutDown(this);
            }

            if (inEvent == EDSDK.StateEvent_CaptureError)
            {
                throw new ShootingException(inParameter);
            }

            return EDSDK.EDS_ERR_OK;
        }

        public void MoveFocus(uint value)
        {
            SDKHelper.CheckError(EDSDK.EdsSendCommand(_pointer, EDSDK.CameraCommand_DriveLensEvf, (int)value));
        }


        public void StartLiveView(Action<uint> whenReady)
        {
            UInt32 device = Convert.ToUInt32(GetIntProperty(EDSDK.PropID_Evf_OutputDevice));
            device = EDSDK.EvfOutputDevice_PC | EDSDK.EvfOutputDevice_TFT;

            _cameraNotifications.Log(string.Format("LiveView device: {0}", device));

            if (GetIntProperty(EDSDK.PropID_Evf_Mode) == 0)
            {
                SetProperty(EDSDK.PropID_Evf_Mode, 1);
            }

            AddEventHandler(whenReady, true, EDSDK.PropID_Evf_OutputDevice);
            SetProperty(EDSDK.PropID_Evf_OutputDevice, device);
        }

        private void AddEventHandler(Action<uint> action, bool runOnce, uint eventId)
        {
            lock (_eventHandlersSync)
            {
                _eventHandlers.Add(new CameraEvent(action, runOnce, eventId));
            }
        }

        public void StopLiveView(Action<uint> whenReady)
        {
            UInt32 device = Convert.ToUInt32(GetIntProperty(EDSDK.PropID_Evf_OutputDevice));
            device = 0;

            _cameraNotifications.Log(string.Format("LiveView device: {0}", device));

            AddEventHandler(whenReady, true, EDSDK.PropID_Evf_OutputDevice);
            SetProperty(EDSDK.PropID_Evf_OutputDevice, device);
        }

        private uint CameraPropertyChanged(uint inEvent, uint inPropertyID, uint inParam, IntPtr inContext)
        {
            _cameraNotifications.Log(string.Format("Camera property changed: {0}, {1}, {2}", SDKHelper.DecodeEvent(inEvent), SDKHelper.DecodeProperty(inPropertyID), inParam));

            lock (_eventHandlersSync)
            {
                foreach (CameraEvent cameraEvent in _eventHandlers)
                {
                    cameraEvent.Process(inPropertyID, inParam);
                }
                _eventHandlers.RemoveAll(cameraEvent => cameraEvent.RunOnce);
            }

            return EDSDK.EDS_ERR_OK;
        }


        public void DownloadLiveViewImage(Action<IntPtr, uint> onImageRecieved)
        {
            IntPtr stream = IntPtr.Zero;
            IntPtr image = IntPtr.Zero;
            IntPtr pointer = IntPtr.Zero;
            uint size = 0;

            try
            {
                SDKHelper.CheckError(EDSDK.EdsCreateMemoryStream(BUFFER_SIZE, out stream));
                SDKHelper.CheckError(EDSDK.EdsCreateEvfImageRef(stream, out image));
                SDKHelper.CheckError(EDSDK.EdsDownloadEvfImage(_pointer, image));

                SDKHelper.CheckError(EDSDK.EdsGetPointer(stream, out pointer));
                SDKHelper.CheckError(EDSDK.EdsGetLength(stream, out size));

                onImageRecieved(pointer, size);

                SDKHelper.CheckError(EDSDK.EdsRelease(image));
                SDKHelper.CheckError(EDSDK.EdsRelease(stream));
            }
            catch (SDKComeBackLaterException)
            {
            }
        }

        public void SetDownloadImageHandler(IImageHandler imageHandler)
        {
            _imageHandler = imageHandler;
        }
    }
}