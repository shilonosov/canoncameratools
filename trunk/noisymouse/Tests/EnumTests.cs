using NMock2;
using NUnit.Framework;
using Source;

namespace Tests
{
    [TestFixture]
    public class EnumTests
    {
        private Mockery _mockery;
        private ICamera _camera;

        [SetUp]
        public void SetUp()
        {
            _mockery = new Mockery();
            _camera = (ICamera)_mockery.NewMock(typeof(ICamera));
        }

        [Test]
        public void GetIsoAvailableValuesTest()
        {
            int[] rawValues = new int[] {(int) IsoSpeedEnum.iso6, (int) IsoSpeedEnum.iso320, (int) IsoSpeedEnum.iso6400};
            Expect.Once.On(_camera).Method("GetAvailableValues").With(EDSDKLib.EDSDK.PropID_ISOSpeed).Will(Return.Value(rawValues));

            EnumValueCollection values = IsoSpeed.GetListFrom(_camera);

            Assert.AreEqual(rawValues.Length, values.Count);
            
            CheckValue(rawValues, values, 0, "Iso 6");
            CheckValue(rawValues, values, 1, "Iso 320");
            CheckValue(rawValues, values, 2, "Iso 6400");

            _mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void GetApertureAvailableValuesTest()
        {
            int[] rawValues = new int[] { (int)ApertureEnum.f1, (int)ApertureEnum.f64, (int)ApertureEnum.f9 };
            Expect.Once.On(_camera).Method("GetAvailableValues").With(EDSDKLib.EDSDK.PropID_Av).Will(Return.Value(rawValues));

            EnumValueCollection values = Aperture.GetListFrom(_camera);

            Assert.AreEqual(rawValues.Length, values.Count);

            CheckValue(rawValues, values, 0, "F1");
            CheckValue(rawValues, values, 1, "F64");
            CheckValue(rawValues, values, 2, "F9");

            _mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void GetExposalAvailableValuesTest()
        {
            int[] rawValues = new int[] { (int)ExposalEnum.tBulb, (int)ExposalEnum.t0dot8, (int)ExposalEnum.t30 };
            Expect.Once.On(_camera).Method("GetAvailableValues").With(EDSDKLib.EDSDK.PropID_Tv).Will(Return.Value(rawValues));

            EnumValueCollection values = Exposal.GetListFrom(_camera);

            Assert.AreEqual(rawValues.Length, values.Count);

            CheckValue(rawValues, values, 0, "Bulb");
            CheckValue(rawValues, values, 1, "0\"8");
            CheckValue(rawValues, values, 2, "30\"");

            _mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ToStringTest()
        {
            Assert.AreEqual(IsoSpeed.With(IsoSpeedEnum.iso6400).DisplayString, IsoSpeed.With(IsoSpeedEnum.iso6400).ToString());
            Assert.AreEqual(Aperture.With(ApertureEnum.f9_5).DisplayString, Aperture.With(ApertureEnum.f9_5).ToString());
            Assert.AreEqual(Exposal.With(ExposalEnum.t8).DisplayString, Exposal.With(ExposalEnum.t8).ToString());
        }

        [Test]
        public void EqualityTest()
        {
            Assert.AreEqual(IsoSpeed.IsoSpeeds[(int) IsoSpeedEnum.iso800], IsoSpeed.With(IsoSpeedEnum.iso800));
        }

        [Test]
        public void ApplyTest()
        {
            const uint type = 1;
            const int value = 2;

            Mockery mockery = new Mockery();
            ICamera camera = (ICamera) mockery.NewMock(typeof (ICamera));
            Expect.Once.On(camera).Method("SetProperty").With(type, value);

            new EnumValue(value, string.Empty, type).ApplyTo(camera);
            
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void GetAvailableValuesTest()
        {
            const uint type = 123;
            int[] values = new int[] {1, 2, 10};
            EnumValueCollection collection = new EnumValueCollection();
            collection.Add(new EnumValue(1, "1", 0));
            collection.Add(new EnumValue(2, "2", 0));
            collection.Add(new EnumValue(3, "3", 0));
            collection.Add(new EnumValue(10, "10", 0));

            Mockery mockery = new Mockery();
            ICamera camera = (ICamera)mockery.NewMock(typeof(ICamera));
            Expect.Once.On(camera).Method("GetAvailableValues").With(type).Will(Return.Value(values));

            EnumValueCollection result = EnumValue.GetListFrom(camera, type, collection);
            Assert.AreEqual(values.Length, result.Count);
            Assert.AreEqual(values[0], result[1].Value);
            Assert.AreEqual(values[1], result[2].Value);
            Assert.AreEqual(values[2], result[10].Value);

            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        private static void CheckValue(int[] aRawValues, EnumValueCollection aValues, int anIndex, string anExpectedDisplayString)
        {
            EnumValue enumValue = aValues.AtIndex(anIndex);

            Assert.AreEqual(aRawValues[anIndex], enumValue.Value);
            Assert.AreEqual(anExpectedDisplayString, enumValue.DisplayString);
        }
    }
}
