using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using EDSDKLib;

namespace Source
{
    public class LiveViewThread
    {
        private ICameraPool _cameraPool;
        private ICameraInfo _cameraInfo;
        private bool _isRunning;
        private Thread _thread;
        private object _syncObject;
        private Action<IntPtr, uint> _onImageRecieved;

        public LiveViewThread(ICameraPool cameraPool, Action<IntPtr, uint> onImageRecieved)
        {
            _cameraPool = cameraPool;
            _onImageRecieved = onImageRecieved;
            _cameraInfo = null;
            _isRunning = false;
            _thread = new Thread(Worker);
            _syncObject = new object();
        }

        private void Worker()
        {
            while (_isRunning)
            {
                LoopFunction();
            }
        }

        protected void LoopFunction()
        {
            _cameraPool.DownloadLiveViewImage(_cameraInfo, _onImageRecieved);
        }

        public void Start(ICameraInfo cameraInfo)
        {
            _cameraInfo = cameraInfo;
            _cameraPool.StartLiveView(_cameraInfo, StartWorkerThread);
        }

        private void StartWorkerThread(uint value)
        {
            lock (_syncObject)
            {
                _isRunning = true;
                _thread.Start();
            }
        }

        public void Stop()
        {
            lock (_syncObject)
            {
                if (_isRunning)
                {
                    _isRunning = false;
                    _thread.Join();
                    _cameraPool.StopLiveView(_cameraInfo);
                    _cameraInfo = null;
                }
            }
        }

        public void Pause()
        {
            lock (_syncObject)
            {
                if (_isRunning)
                {
                    _isRunning = false;
                    _thread.Join();
                    _cameraPool.StopLiveView(_cameraInfo);
                }
            }
        }

        public void Resume()
        {
            _cameraPool.StartLiveView(_cameraInfo, StartWorkerThread);
        }
    }
}
