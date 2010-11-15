using System;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Source
{
    public interface ITimer
    {
        void Start(int anInterval, int aTotalCount, IControllable controllable, Dispatcher dispatcher);
        void Stop();
    }

    public class TimerWrapper: ITimer
    {
        private int _interval;
        private int _totalCount;

        private void ThreadFunction(IControllable controllable, Dispatcher dispatcher)
        {
            int shots = 0;
            do
            {
                //anObject.Action();
                //actionDelegate.BeginInvoke(null, anObject);
                //form.Invoke(actionDelegate);
                //dispatcher.BeginInvoke(action);

                controllable.BuildImagesQueue();
                controllable.MakeAShoot();
                
                shots++;

                WaitFor(_interval);

            } while (shots < _totalCount);
        }

        private static void WaitFor(int anInterval)
        {
            DateTime endTime = DateTime.Now.AddSeconds(anInterval);
            
            while (endTime > DateTime.Now)
            {
                Thread.Sleep(100);
            }
        }

        public void Start(int anInterval, int aTotalCount, IControllable controllable, Dispatcher dispatcher)
        {
            _interval = anInterval;
            _totalCount = aTotalCount;

            ThreadFunction(controllable, dispatcher);
        }

        public void Stop()
        {
            _totalCount = 0;
            //_thread.Abort();
        }
    }

    public interface IControllable
    {
        void MakeAShoot();
        void BuildImagesQueue();
    }


    public class Scheduler
    {
        private readonly ITimer _timer;
        private readonly Dispatcher _dispatcher;
        private readonly IControllable _controllable;

        public Scheduler(IControllable controllable, Dispatcher dispatcher)
        {
            _controllable = controllable;
            _dispatcher = dispatcher;
            _timer = new TimerWrapper();
        }

        public void Start(int anInterval, int aTotalCount)
        {
            _timer.Start(anInterval, aTotalCount, _controllable, _dispatcher);
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
