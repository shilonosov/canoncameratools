using System;

namespace Source
{
    public interface ICameraProcessor: IDisposable
    {
        IShootParameters ShootParameters { get; }
        ICameraInfo CameraInfo { get; }
        ICamera Camera { get; }

        void TakeAPicture(IShootParameters aShootParameters, IImageHandler imageHandler);
        void PressShutterButton(IImageHandler imageHandler);
        IShootParameters[] CreateExposalBracketing(int aStep, int aCount, IShootParameters anInitialParameters);
        IShootParameters[] CreateApertureBracketing(IShootParameters anInitialiParameters, Aperture[] anApertures);
    }

    public class CameraProcessor : ICameraProcessor
    {
        private readonly ICamera _camera;
        private readonly ICameraInfo _cameraInfo;

        public ICamera Camera
        {
            get { return _camera; }
        }

        public IShootParameters ShootParameters
        {
            get { return new ShootParameters(IsoSpeed.With(_camera.IsoSpeed), Aperture.With(_camera.ApertureValue), Exposal.With(_camera.ExposalValue)); }
        }

        public ICameraInfo CameraInfo
        {
            get { return _cameraInfo; }
        }

        public CameraProcessor(IntPtr aPointer, ICameraNotifications aCameraNotifications)
            : this(new Camera(aPointer, aCameraNotifications))
        {
        }

        public CameraProcessor(ICamera aCamera, ICameraInfo aCameraInfo)
        {
            _camera = aCamera;
            _cameraInfo = aCameraInfo;
        }

        public CameraProcessor(ICamera aCamera): this(aCamera, new CameraInfo(aCamera))
        {
        }

        public void TakeAPicture(IShootParameters aShootParameters, IImageHandler imageHandler)
        {
            aShootParameters.ApplyTo(_camera);
            _camera.Shoot(imageHandler);
        }

        public void PressShutterButton(IImageHandler imageHandler)
        {
            _camera.PressShutterButton(imageHandler);
        }

        public IShootParameters[] CreateExposalBracketing(int aStep, int aCount, IShootParameters anInitialParameters)
        {
            EnumValueCollection exposals = Exposal.GetListFrom(_camera);

            IShootParameters[] result = new IShootParameters[aCount];

            for (int i = 0; i < aCount; ++i)
            {
                result[i] = anInitialParameters.Copy();
                result[i].Exposal = (Exposal)exposals.GetWithRelatedIndex(result[i].Exposal, (aStep*i) - ((aCount-1)*aStep)/2);
            }

            return result;
        }

        public IShootParameters[] CreateApertureBracketing(IShootParameters anInitialiParameters, Aperture[] anApertures)
        {
            IShootParameters[] result = new IShootParameters[anApertures.Length];
            EnumValueCollection exposals = Exposal.GetListFrom(_camera);
            EnumValueCollection apertures = Aperture.GetListFrom(_camera);

            for (int i = 0; i < result.Length; ++i)
            {
                ShootParameters newParameter = anInitialiParameters.Copy();
                newParameter.Aperture = anApertures[i];
                newParameter.Exposal = (Exposal)exposals.GetWithRelatedIndex(newParameter.Exposal, apertures.GetIndexDifferenceBeetween(anInitialiParameters.Aperture, anApertures[i]));
                result[i] = newParameter;
            }

            return result;
        }

        public void Dispose()
        {
            _camera.Dispose();
        }

    }
}
