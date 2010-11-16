using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Source
{
    public class LiveViewThread
    {
        private CameraInfo _cameraInfo;
        private CameraPool _cameraPool;
        private bool _isRunning;
        private Thread _thread;
        private object _syncObject;

        public LiveViewThread(CameraInfo cameraInfo, CameraPool cameraPool)
        {
            _cameraInfo = cameraInfo;
            _cameraPool = cameraPool;
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
            // TODO: do the magic
        }

        public void Start()
        {

        }

        public void Stop()
        {
        }
    }
}
