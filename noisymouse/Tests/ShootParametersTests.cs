using EDSDKLib;
using NMock2;
using NUnit.Framework;
using Source;

namespace Tests
{
    [TestFixture]
    public class ShootParametersTests
    {
        [Test]
        public void EqualityTest()
        {
            Assert.AreEqual(new ShootParameters(IsoSpeedEnum.iso50, ApertureEnum.f10, ExposalEnum.t1_100), new ShootParameters(IsoSpeedEnum.iso50, ApertureEnum.f10, ExposalEnum.t1_100));
        }

        [Test]
        public void ToStringTest()
        {
            IsoSpeed isoSpeed = (IsoSpeed) IsoSpeed.IsoSpeeds.AtKey(IsoSpeedEnum.iso50);
            Aperture aperture = (Aperture) Aperture.Apertures.AtKey(ApertureEnum.f10);
            Exposal exposal = (Exposal) Exposal.Exposals.AtKey(ExposalEnum.t1_100);

            Assert.AreEqual("Iso 50, F10, 1/100", new ShootParameters(isoSpeed, aperture, exposal).ToString());
            Assert.AreEqual("Iso 50, F10, 1/100", new ShootParameters(isoSpeed, aperture, exposal).DisplayString);
        }

        [Test]
        public void EmptyToStringTest()
        {
            Assert.AreEqual(string.Empty, new ShootParameters().DisplayString);
            Assert.AreEqual(string.Empty, new ShootParameters().ToString());
        }

        [Test]
        public void ApplyToTest()
        {
            Mockery mockery = new Mockery();
            ICamera camera = (ICamera) mockery.NewMock(typeof (ICamera));

            IsoSpeedEnum iso = IsoSpeedEnum.iso50;
            ApertureEnum aperture = ApertureEnum.f10;
            ExposalEnum exposal = ExposalEnum.t1_100;

            Expect.Once.On(camera).Method("SetProperty").With(EDSDK.PropID_ISOSpeed, (int)iso);
            Expect.Once.On(camera).Method("SetProperty").With(EDSDK.PropID_Av, (int)aperture);
            Expect.Once.On(camera).Method("SetProperty").With(EDSDK.PropID_Tv, (int)exposal);

            ShootParameters parameters = new ShootParameters(iso, aperture, exposal);
            parameters.ApplyTo(camera);

            mockery.VerifyAllExpectationsHaveBeenMet();
        }
    }
}
