using System;
using System.Collections.Generic;
using System.Linq;
using EDSDKLib;
using System.Windows.Threading;
using System.IO;

namespace Source
{
    public interface ICameraPool : IDisposable
    {
        void RefreshList();
        ICameraInfo[] CameraList { get; }

        void TakeAPicture(ICameraInfo cameraInfo, IShootParameters _shootingParameters, IImageHandler _imageHandler);
        void PressShutterButton(ICameraInfo cameraInfo, IImageHandler _imageHandler);

        void StartLiveView(ICameraInfo cameraInfo, Action<uint> onSwitched);
        void MoveFocus(ICameraInfo cameraInfo, uint value, Action afterMove);
        void StopLiveView(ICameraInfo cameraInfo, Action<uint> whenReady);

        void LockUI(ICameraInfo cameraInfo);
        void UnlockUI(ICameraInfo cameraInfo);

        void SetVideoMode(ICameraInfo cameraInfo);

        void SetFlashMode(ICameraInfo cameraInfo, int mode);

        void DownloadLiveViewImage(ICameraInfo cameraInfo, Action<MemoryStream, uint> onImageRecieved);

        void StartListenTakeImage(ICameraInfo cameraInfo, IImageHandler imageHandler);
        void StopListenTakeImage(ICameraInfo cameraInfo);
    }

    public class CameraPool: ICameraPool
    {
        private readonly ICameraNotifications _cameraNotifications;
        private IntPtr _cameraListPointer;
        private Dictionary<IntPtr, ICameraProcessor> _processors = new Dictionary<IntPtr, ICameraProcessor>();
        private readonly Dispatcher _dispatcher;

        public CameraPool(ICameraNotifications aCameraNotifications, Dispatcher dispatcher)
        {
            _cameraNotifications = aCameraNotifications;
            _dispatcher = dispatcher;
            Initialize();
        }

        private void Initialize()
        {
            SDKHelper.CheckError(EDSDK.EdsInitializeSDK());
            SDKHelper.CheckError(EDSDK.EdsGetCameraList(out _cameraListPointer));

            LoadCamerasList(_cameraListPointer);
        }

        private void UnInitialize()
        {
            Array.ForEach(_processors.Values.ToArray(), cameraProcessor => cameraProcessor.Dispose());
            SDKHelper.CheckError(EDSDK.EdsRelease(_cameraListPointer));
            SDKHelper.CheckError(EDSDK.EdsTerminateSDK());
        }

        public void Dispose()
        {
            UnInitialize();
        }

        protected ICameraProcessor GetCameraProcessor(ICameraInfo cameraInfo)
        {
            return _processors.Values.ToArray().Single(processor => processor.CameraInfo.Id == cameraInfo.Id);
        }

        public void RefreshList()
        {
            LoadCamerasList(_cameraListPointer);
        }
        
        private void LoadCamerasList(IntPtr aCameraListPointer)
        {
            int cameraCount;
            SDKHelper.CheckError(EDSDK.EdsGetChildCount(aCameraListPointer, out cameraCount));

            IntPtr[] pointers = GetCameraPointers(aCameraListPointer, cameraCount);

            Dictionary<IntPtr, ICameraProcessor> temporary = new Dictionary<IntPtr, ICameraProcessor>();

            for (int i = 0; i < pointers.Length; ++i)
            {
                IntPtr pointer = pointers[i];
                if (_processors.ContainsKey(pointer))
                {
                    temporary.Add(pointer, _processors[pointer]);
                    _processors.Remove(pointer);
                }
                else
                {
                    temporary.Add(pointer, new CameraProcessor(pointer, _cameraNotifications));
                }
            }

            Array.ForEach(_processors.Values.ToArray(), cameraProcessor => cameraProcessor.Dispose());
            _processors = temporary;
        }

        private static IntPtr[] GetCameraPointers(IntPtr aCameraListPointer, int cameraCount)
        {
            IntPtr[] pointers = new IntPtr[cameraCount];
            for (int i = 0; i < cameraCount; ++i)
            {
                IntPtr cameraPointer;
                SDKHelper.CheckError(EDSDK.EdsGetChildAtIndex(aCameraListPointer, i, out cameraPointer));
                pointers[i] = cameraPointer;
            }
            return pointers;
        }

        public ICameraInfo[] CameraList
        {
            get { return _processors.Values.Select(processor => processor.CameraInfo).ToArray(); }
        }


        public void TakeAPicture(ICameraInfo cameraInfo, IShootParameters shootingParameters, IImageHandler imageHandler)
        {
            _dispatcher.BeginInvoke((Action)(() =>
            {
                GetCameraProcessor(cameraInfo).TakeAPicture(shootingParameters, imageHandler);
            }));
        }

        public void PressShutterButton(ICameraInfo cameraInfo, IImageHandler imageHandler)
        {
            GetCameraProcessor(cameraInfo).PressShutterButton(imageHandler);
        }

        public void StartLiveView(ICameraInfo cameraInfo, Action<uint> onSwitched)
        {
            GetCameraProcessor(cameraInfo).Camera.StartLiveView(onSwitched);
        }

        public void MoveFocus(ICameraInfo cameraInfo, uint value, Action afterMove)
        {
            _dispatcher.BeginInvoke((Action)(() =>
            {
                GetCameraProcessor(cameraInfo).Camera.MoveFocus(value);
                afterMove();
            }));
        }

        public void StopLiveView(ICameraInfo cameraInfo, Action<uint> whenReady)
        {
            GetCameraProcessor(cameraInfo).Camera.StopLiveView(whenReady);
        }


        public void LockUI(ICameraInfo cameraInfo)
        {
            GetCameraProcessor(cameraInfo).Camera.LockUI();
        }

        public void UnlockUI(ICameraInfo cameraInfo)
        {
            GetCameraProcessor(cameraInfo).Camera.UnlockUI();
        }

        public void SetVideoMode(ICameraInfo cameraInfo)
        {
            GetCameraProcessor(cameraInfo).Camera.SetProperty(EDSDK.PropID_DriveMode, 2);
        }

        public void SetFlashMode(ICameraInfo cameraInfo, int mode)
        {
            GetCameraProcessor(cameraInfo).Camera.SetProperty(EDSDK.PropID_FlashMode, mode);
        }

        public void DownloadLiveViewImage(ICameraInfo cameraInfo, Action<MemoryStream, uint> onImageRecieved)
        {
            GetCameraProcessor(cameraInfo).Camera.DownloadLiveViewImage(onImageRecieved);
        }


        public void StartListenTakeImage(ICameraInfo cameraInfo, IImageHandler imageHandler)
        {
            ICamera camera = GetCameraProcessor(cameraInfo).Camera;
            camera.SaveToValue = (uint)SaveToEnum.Save_by_downloading_to_a_host_computer;
            camera.SetDownloadImageHandler(imageHandler);
        }

        public void StopListenTakeImage(ICameraInfo cameraInfo)
        {
            ICamera camera = GetCameraProcessor(cameraInfo).Camera;
            camera.SaveToValue = (uint)SaveToEnum.Save_on_a_memory_card_of_a_remote_camera;
            camera.SetDownloadImageHandler(null);
        }
    }
}
