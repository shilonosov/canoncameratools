using System;
using EDSDKLib;
using NMock2;
using NUnit.Framework;
using Source;

namespace Tests
{
    [TestFixture]
    public class CameraProcessorTests
    {
        private Mockery _mockery;
        private ICamera _camera;
        private ICameraInfo _cameraInfo;
        private ImageFile _imageFile;


        [SetUp]
        public void SetUp()
        {
            _mockery = new Mockery();
            _camera = (ICamera)_mockery.NewMock(typeof(ICamera));
            _cameraInfo = (ICameraInfo) _mockery.NewMock(typeof (ICameraInfo));

            _imageFile = new ImageFile();
        }

        [Test]
        public void MakeAShootTest()
        {
            IImageHandler imageHandler = (IImageHandler) _mockery.NewMock(typeof (IImageHandler));
            IShootParameters parameters = (IShootParameters) _mockery.NewMock(typeof (IShootParameters));
            
            Expect.Once.On(_camera).Method("LockUI").WithNoArguments();
            Expect.Once.On(parameters).Method("ApplyTo").With(_camera);
            Expect.Once.On(_camera).Method("Shoot").WithNoArguments().Will(Return.Value(_imageFile));
            Expect.Once.On(imageHandler).Method("Handle").With(_imageFile);
            Expect.Once.On(_camera).Method("UnlockUI").WithNoArguments();

            CameraProcessor processor = new CameraProcessor(_camera, _cameraInfo);

            //processor.MakeAShoot(parameters, imageHandler);

            _mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void CatchShootExceptionTest()
        {
            ShootingException exception = new ShootingException();

            IImageHandler imageHandler = (IImageHandler)_mockery.NewMock(typeof(IImageHandler));
            IShootParameters parameters = (IShootParameters)_mockery.NewMock(typeof(IShootParameters));

            Expect.Once.On(_camera).Method("LockUI").WithNoArguments();
            Expect.Once.On(parameters).Method("ApplyTo").With(_camera);
            Expect.Once.On(_camera).Method("Shoot").WithNoArguments().Will(Throw.Exception(exception));
            Expect.Once.On(_camera).Method("UnlockUI").WithNoArguments();

            CameraProcessor processor = new CameraProcessor(_camera, _cameraInfo);

            try
            {
                //processor.MakeAShoot(parameters, imageHandler);
                Assert.Fail();
            }
            catch(Exception anException)
            {
                Assert.AreEqual(exception, anException);
            }

            _mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void CreateExposalBracketingTest()
        {
            ShootParameters parameters = new ShootParameters(IsoSpeedEnum.iso50, ApertureEnum.f5_6, ExposalEnum.t1_100);

            Expect.Once.On(_camera).Method("GetAvailableValues").With(EDSDK.PropID_Tv).Will(Return.Value(
                new int[]
                    {
                        (int)ExposalEnum.t1_4000,
                        (int)ExposalEnum.t1_125,
                        (int)ExposalEnum.t1_100,
                        (int)ExposalEnum.t1_80,
                        (int)ExposalEnum.t1_60,
                        (int)ExposalEnum.t1,
                        (int)ExposalEnum.t30
                    }));

            CameraProcessor processor = new CameraProcessor(_camera, _cameraInfo);
            IShootParameters[] exposalBracketing = processor.CreateExposalBracketing(2, 3, parameters);

            Assert.AreEqual(3, exposalBracketing.Length);
            Assert.AreEqual(new ShootParameters(IsoSpeedEnum.iso50, ApertureEnum.f5_6, ExposalEnum.t1_4000), exposalBracketing[0]);
            Assert.AreEqual(new ShootParameters(IsoSpeedEnum.iso50, ApertureEnum.f5_6, ExposalEnum.t1_100), exposalBracketing[1]);
            Assert.AreEqual(new ShootParameters(IsoSpeedEnum.iso50, ApertureEnum.f5_6, ExposalEnum.t1_60), exposalBracketing[2]);

            _mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void CreateApertureBracketingTest()
        {
            ShootParameters parameters = new ShootParameters(IsoSpeedEnum.iso50, ApertureEnum.f5_6, ExposalEnum.t1_80);

            Aperture[] apertures = new Aperture[] { (Aperture) Aperture.Apertures.AtKey(ApertureEnum.f2), (Aperture) Aperture.Apertures.AtKey(ApertureEnum.f91) };


            Expect.Once.On(_camera).Method("GetAvailableValues").With(EDSDK.PropID_Tv).Will(Return.Value(
                new int[]
                    {
                        (int)ExposalEnum.t30,
                        (int)ExposalEnum.t1,
                        (int)ExposalEnum.t1_60,
                        (int)ExposalEnum.t1_80,
                        (int)ExposalEnum.t1_100,
                        (int)ExposalEnum.t1_125,
                        (int)ExposalEnum.t1_4000
                    }));
            Expect.Once.On(_camera).Method("GetAvailableValues").With(EDSDK.PropID_Av).Will(Return.Value(
                new int[]
                    {
                        (int)ApertureEnum.f1,
                        (int)ApertureEnum.f2,
                        (int)ApertureEnum.f3_5,
                        (int)ApertureEnum.f5_6,
                        (int)ApertureEnum.f8,
                        (int)ApertureEnum.f11,
                        (int)ApertureEnum.f91
                    }));

            CameraProcessor processor = new CameraProcessor(_camera, _cameraInfo);

            IShootParameters[] apertureBracketing = processor.CreateApertureBracketing(parameters, apertures);

            Assert.AreEqual(2, apertureBracketing.Length);
            Assert.AreEqual(new ShootParameters(IsoSpeedEnum.iso50, ApertureEnum.f2, ExposalEnum.t1_125), apertureBracketing[0]);
            Assert.AreEqual(new ShootParameters(IsoSpeedEnum.iso50, ApertureEnum.f91, ExposalEnum.t30), apertureBracketing[1]);

            _mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void DisposeTest()
        {
            Expect.Once.On(_camera).Method("Dispose").WithNoArguments();

            new CameraProcessor(_camera, _cameraInfo).Dispose();

            _mockery.VerifyAllExpectationsHaveBeenMet();
        }
    }
}
