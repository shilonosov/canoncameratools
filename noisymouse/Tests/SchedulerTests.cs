using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NMock2;
using NUnit.Framework;
using Source;

namespace Tests
{
    //[TestFixture]
    public class SchedulerTests
    {
        private const int _interval = 10;
        private Mockery _mockery;
        private ITimer _timer;

        [SetUp]
        public void SetUp()
        {
            _mockery = new Mockery();
            _timer = (ITimer)_mockery.NewMock(typeof(ITimer));
        }

        [Test]
        public void RunByintervalTest()
        {
            Scheduler scheduler = null;// new Scheduler(_timer);

            Expect.Once.On(_timer).Method("Start").With(_interval, null);
            
            scheduler.Start(_interval, 1);

            _mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void StopTest()
        {
            Scheduler scheduler = null;// new Scheduler(_timer);

            Expect.Once.On(_timer).Method("Stop").WithNoArguments();

            scheduler.Stop();

            _mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void RunWithStartTimeTest()
        {
            DateTime start = new DateTime(2009, 06, 09, 16, 00, 00);
            DateTime end = new DateTime(2009, 06, 09, 16, 10, 00);

            Scheduler scheduler = null;// new Scheduler(_timer);

            //scheduler.Start(_interval, start, end);

            _mockery.VerifyAllExpectationsHaveBeenMet();
        }
    }
}
