using System;
using System.Collections.Generic;
using System.Linq;
using EDSDKLib;
using System.Windows.Threading;

namespace Source
{
    public interface ICameraPool : IDisposable
    {
        void RefreshList();
        ICameraInfo[] CameraList { get; }

        void TakeAPicture(string cameraId, IShootParameters _shootingParameters, IImageHandler _imageHandler);
        void PressShutterButton(string cameraId, IImageHandler _imageHandler);

        void StartLiveView(string cameraId, Action<uint> onSwitched);
        void MoveFocus(string cameraId, uint value);
        void StopLiveView(string cameraId);

        void LockUI(ICameraInfo cameraInfo);
        void UnlockUI(ICameraInfo cameraInfo);

        void SetVideoMode(ICameraInfo cameraInfo);

        void SetFlashMode(ICameraInfo CameraInfo, int p);
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

        protected ICameraProcessor GetCamera(string anId)
        {
            return _processors.Values.ToArray().Single(processor => processor.CameraInfo.Id == anId);
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


        public void TakeAPicture(string cameraId, IShootParameters shootingParameters, IImageHandler imageHandler)
        {
            _dispatcher.BeginInvoke((Action)(() =>
            {
                GetCamera(cameraId).TakeAPicture(shootingParameters, imageHandler);
            }));
        }

        public void PressShutterButton(string cameraId, IImageHandler imageHandler)
        {
            GetCamera(cameraId).PressShutterButton(imageHandler);
        }

        public void StartLiveView(string cameraId, Action<uint> onSwitched)
        {
            GetCamera(cameraId).Camera.StartLiveView(onSwitched);
        }

        public void MoveFocus(string cameraId, uint value)
        {
            GetCamera(cameraId).Camera.MoveFocus(value);
        }

        public void StopLiveView(string cameraId)
        {
            GetCamera(cameraId).Camera.StopLiveView();
        }


        public void LockUI(ICameraInfo cameraInfo)
        {
            GetCamera(cameraInfo.Id).Camera.LockUI();
        }

        public void UnlockUI(ICameraInfo cameraInfo)
        {
            GetCamera(cameraInfo.Id).Camera.UnlockUI();
        }

        public void SetVideoMode(ICameraInfo cameraInfo)
        {
            GetCamera(cameraInfo.Id).Camera.SetProperty(EDSDK.PropID_DriveMode, 2);
        }


        public void SetFlashMode(ICameraInfo cameraInfo, int mode)
        {
            GetCamera(cameraInfo.Id).Camera.SetProperty(EDSDK.PropID_FlashMode, mode);
        }
    }
}
