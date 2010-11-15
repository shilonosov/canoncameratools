using NMock2;
using NUnit.Framework;
using Source;

namespace Tests
{
    [TestFixture]
    public class CameraInfoTests
    {
        private Mockery _mockery;
        private ICamera _camera;

        [Test]
        public void DisplayStringTest()
        {
            const string productName = "product name";
            const string ownerName = "owner name";

            CameraInfo cameraInfo = new CameraInfo(null, productName, ownerName);

            Assert.AreEqual(string.Format("{0} - {1}", productName, ownerName), cameraInfo.DisplayString);
        }

        [SetUp]
        public void SetUp()
        {
            _mockery = new Mockery();
            _camera = (ICamera)_mockery.NewMock(typeof(ICamera));
        }

        [Test]
        public void TextFieldsTest()
        {
            const string cameraId = "camera id";
            const string productName = "product name";
            const string ownerName = "owner name";

            ConfigureMockCamera(cameraId, productName, ownerName, new IsoSpeedEnum[] { }, new ApertureEnum[] { }, new ExposalEnum[] { }, new ImageQualityEnum[] { }, IsoSpeedEnum.iso6, ApertureEnum.f0, ExposalEnum.tBulb, ImageQualityEnum.PPT_sRAW1);

            CameraInfo cameraInfo = new CameraInfo(_camera);

            Assert.AreEqual(cameraId, cameraInfo.Id);
            Assert.AreEqual(productName, cameraInfo.ProductName);
            Assert.AreEqual(ownerName, cameraInfo.OwnerName);

            _mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void AvailableIsoSpeedsTest()
        {
            IsoSpeedEnum[] isoSpeeds = new[] {IsoSpeedEnum.iso800, IsoSpeedEnum.iso6};

            ConfigureMockCamera(null, null, null, isoSpeeds, new ApertureEnum[] { }, new ExposalEnum[] { }, new ImageQualityEnum[] { }, IsoSpeedEnum.iso6, ApertureEnum.f0, ExposalEnum.tBulb, ImageQualityEnum.PPT_sRAW1);

            CameraInfo cameraInfo = new CameraInfo(_camera);

            Assert.AreEqual(isoSpeeds.Length, cameraInfo.AvailableIsoSpeeds.Count);
            Assert.That(cameraInfo.AvailableIsoSpeeds, NUnit.Framework.Has.Member(IsoSpeed.With(isoSpeeds[0])));
            Assert.That(cameraInfo.AvailableIsoSpeeds, NUnit.Framework.Has.Member(IsoSpeed.With(isoSpeeds[1])));

            _mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void AvailableAperturesTest()
        {
            ApertureEnum[] apertures = new[] { ApertureEnum.f9_5, ApertureEnum.f64 };

            ConfigureMockCamera(null, null, null, new IsoSpeedEnum[] { }, apertures, new ExposalEnum[] { }, new ImageQualityEnum[] { }, IsoSpeedEnum.iso6, ApertureEnum.f0, ExposalEnum.tBulb, ImageQualityEnum.PPT_sRAW1);

            CameraInfo cameraInfo = new CameraInfo(_camera);

            Assert.AreEqual(apertures.Length, cameraInfo.AvailableApertures.Count);
            Assert.That(cameraInfo.AvailableApertures, NUnit.Framework.Has.Member(Aperture.With(apertures[0])));
            Assert.That(cameraInfo.AvailableApertures, NUnit.Framework.Has.Member(Aperture.With(apertures[1])));

            _mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void AvailableExposalsTest()
        {
            ExposalEnum[] exposals = new[] { ExposalEnum.t6_stepOneThird, ExposalEnum.t1dot3 };

            ConfigureMockCamera(null, null, null, new IsoSpeedEnum[] { }, new ApertureEnum[] { }, exposals, new ImageQualityEnum[] { }, IsoSpeedEnum.iso6, ApertureEnum.f0, ExposalEnum.tBulb, ImageQualityEnum.PPT_sRAW1);

            CameraInfo cameraInfo = new CameraInfo(_camera);

            Assert.AreEqual(exposals.Length, cameraInfo.AvailableExposals.Count);
            Assert.That(cameraInfo.AvailableExposals, NUnit.Framework.Has.Member(Exposal.With(exposals[0])));
            Assert.That(cameraInfo.AvailableExposals, NUnit.Framework.Has.Member(Exposal.With(exposals[1])));

            _mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void AvailableImageQualitiesTest()
        {
            ImageQualityEnum[] imageQualities = new[] { ImageQualityEnum.PPT_sRAW1_L_hq, ImageQualityEnum.Legacy_RAW_L };

            ConfigureMockCamera(null, null, null, new IsoSpeedEnum[] { }, new ApertureEnum[] { }, new ExposalEnum[] { }, imageQualities, IsoSpeedEnum.iso6, ApertureEnum.f0, ExposalEnum.tBulb, ImageQualityEnum.PPT_sRAW1);

            CameraInfo cameraInfo = new CameraInfo(_camera);

            Assert.AreEqual(imageQualities.Length, cameraInfo.AvailableImageQualities.Count);
            Assert.That(cameraInfo.AvailableImageQualities, NUnit.Framework.Has.Member(ImageQuality.With(imageQualities[0])));
            Assert.That(cameraInfo.AvailableImageQualities, NUnit.Framework.Has.Member(ImageQuality.With(imageQualities[1])));

            _mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void EnumFieldsTest()
        {
            IsoSpeedEnum iso = IsoSpeedEnum.iso640;
            ApertureEnum aperture = ApertureEnum.f72;
            ExposalEnum exposal = ExposalEnum.t6;
            ImageQualityEnum imageQuality = ImageQualityEnum.PPT_sRAW1;

            ConfigureMockCamera(null, null, null, new IsoSpeedEnum[] { }, new ApertureEnum[] { }, new ExposalEnum[] { }, new ImageQualityEnum[] { }, iso, aperture, exposal, imageQuality);

            CameraInfo cameraInfo = new CameraInfo(_camera);

            Assert.AreEqual(IsoSpeed.With(iso), cameraInfo.CurrentIsoSpeed);
            Assert.AreEqual(Aperture.With(aperture), cameraInfo.CurrentAperture);
            Assert.AreEqual(Exposal.With(exposal), cameraInfo.CurrentExposal);
            Assert.AreEqual(ImageQuality.With(imageQuality), cameraInfo.CurrentImageQuality);

            _mockery.VerifyAllExpectationsHaveBeenMet();
        }

        
        private void ConfigureMockCamera(string aCameraId, string aProductName, string anOwnerName, IsoSpeedEnum[] anIsoSpeeds, ApertureEnum[] anApertures, ExposalEnum[] anExposals, ImageQualityEnum[] anImageQualities, IsoSpeedEnum anIsoSpeed, ApertureEnum anAperture, ExposalEnum anExposal, ImageQualityEnum anImageQuality)
        {
            Expect.Once.On(_camera).GetProperty("Id").Will(Return.Value(aCameraId));
            Expect.Once.On(_camera).GetProperty("ProductName").Will(Return.Value(aProductName));
            Expect.Once.On(_camera).GetProperty("OwnerName").Will(Return.Value(anOwnerName));
            Expect.Once.On(_camera).Method("GetAvailableValues").With(EDSDKLib.EDSDK.PropID_ISOSpeed).Will(Return.Value(anIsoSpeeds));
            Expect.Once.On(_camera).Method("GetAvailableValues").With(EDSDKLib.EDSDK.PropID_Av).Will(Return.Value(anApertures));
            Expect.Once.On(_camera).Method("GetAvailableValues").With(EDSDKLib.EDSDK.PropID_Tv).Will(Return.Value(anExposals));
            Expect.Once.On(_camera).Method("GetAvailableValues").With(EDSDKLib.EDSDK.PropID_ImageQuality).Will(Return.Value(anImageQualities));

            Expect.Once.On(_camera).GetProperty("IsoSpeed").Will(Return.Value((int)anIsoSpeed));
            Expect.Once.On(_camera).GetProperty("ApertureValue").Will(Return.Value((int)anAperture));
            Expect.Once.On(_camera).GetProperty("ExposalValue").Will(Return.Value((int)anExposal));
            Expect.Once.On(_camera).GetProperty("ImageQualityValue").Will(Return.Value((int)anImageQuality));
        }
    }
}
