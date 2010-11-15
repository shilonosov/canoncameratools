using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultifocusShooter
{
    public class CameraThread
    {
        private Thread _thread;
        private object _syncObject;
        private Queue<Action> _queue;

        public CameraThread()
        {
            _syncObject = new object();
            _queue = new Queue<Action>();

            _thread = new Thread(this.ThreadLoop);
        }

        private void ThreadLoop()
        {

        }


        private Action GetNextAction()
        {
            lock (_syncObject)
            {
                return _queue.Dequeue();
            }
        }
    }
}
