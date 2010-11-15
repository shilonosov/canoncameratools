using NMock2;
using NUnit.Framework;
using Source;

namespace Tests
{
    [TestFixture]
    public class ImageTests
    {
        private const string CameraId = "camera id";

        private Mockery _mockery;
        private ICameraProcessor _cameraProcessor;
        private IShootParameters _parameters;
        private IImageHandler _imageHandler;
        private ICameraPool _cameraPool;

        [SetUp]
        public void SetUp()
        {
            _mockery = new Mockery();

            _cameraProcessor = (ICameraProcessor)_mockery.NewMock(typeof(ICameraProcessor));

            _parameters = (IShootParameters)_mockery.NewMock(typeof(IShootParameters));
            _imageHandler = (IImageHandler)_mockery.NewMock(typeof(IImageHandler));
            _cameraPool = (ICameraPool) _mockery.NewMock(typeof (ICameraPool));
        }

        [Test]
        public void MakeTest()
        {
            Expect.Once.On(_cameraPool).Method("GetCamera").With(CameraId).Will(Return.Value(_cameraProcessor));
            Expect.Once.On(_cameraProcessor).Method("MakeAShoot").With(_parameters, _imageHandler);

            Image image = new Image(new CameraInfo(CameraId), _parameters, _imageHandler);

            image.Make(_cameraPool);

            _mockery.VerifyAllExpectationsHaveBeenMet();
        }


        [Test]
        public void ToStringTest()
        {
            const string parameters = "parameters";
            const string imagehandler = "imageHandler";
            const string model = "model";
            const string userName = "userName";

            ICameraInfo cameraInfo = (ICameraInfo) _mockery.NewMock(typeof (ICameraInfo));

            Expect.Once.On(_parameters).GetProperty("DisplayString").Will(Return.Value(parameters));
            Expect.Once.On(_imageHandler).GetProperty("DisplayString").Will(Return.Value(imagehandler));

            Image image = new Image(new CameraInfo(CameraId, model, userName), _parameters, _imageHandler);

            Assert.AreEqual(string.Format("{0} - {1}\t{2}\t{3}", model, userName, parameters, imagehandler), image.DisplayString);

            _mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void CameraDisplayStringTest()
        {
            const string productName = "product name";
            const string ownerName = "owner name";

            Image image = new Image(new CameraInfo("camera Id", productName, ownerName), new ShootParameters(), new StubHandler());

            Assert.AreEqual(string.Format("{0} - {1}", productName, ownerName), image.CameraDisplayString);
        }
    }
}
