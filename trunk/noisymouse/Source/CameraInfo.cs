using System;

namespace Source
{
    public interface ICameraInfo
    {
        string Id { get; }
        string ProductName { get; }
        string OwnerName { get; }
        string DisplayString { get; }
        
        EnumValueCollection AvailableIsoSpeeds { get; }
        EnumValueCollection AvailableApertures { get; }
        EnumValueCollection AvailableExposals { get; }
        EnumValueCollection AvailableImageQualities { get; }

        IsoSpeed CurrentIsoSpeed { get; }
        Aperture CurrentAperture { get; }
        Exposal CurrentExposal { get; }
        ImageQuality CurrentImageQuality { get; }

        string ToString();
    }

    public class CameraInfo: ICameraInfo
    {
        private readonly string _id;
        private readonly string _productName;
        private readonly string _ownerName;
        private readonly EnumValueCollection _isoSpeeds;
        private readonly EnumValueCollection _apertures;
        private readonly EnumValueCollection _exposals;
        private readonly EnumValueCollection _imageQualities;
        private readonly IsoSpeed _currentIsoSpeed;
        private readonly Aperture _currentAperture;
        private readonly Exposal _currentExposal;
        private readonly ImageQuality _currentImageQuality;

        public string Id
        {
            get { return _id; }
        }

        public string ProductName
        {
            get { return _productName; }
        }

        public string OwnerName
        {
            get { return _ownerName; }
        }

        public string DisplayString
        {
            get { return string.Format("{0} - {1}", _productName, _ownerName); }
        }

        public EnumValueCollection AvailableIsoSpeeds
        {
            get { return _isoSpeeds; }
        }

        public EnumValueCollection AvailableApertures
        {
            get { return _apertures; }
        }

        public EnumValueCollection AvailableExposals
        {
            get { return _exposals; }
        }

        public EnumValueCollection AvailableImageQualities
        {
            get { return _imageQualities; }
        }

        public IsoSpeed CurrentIsoSpeed
        {
            get { return _currentIsoSpeed; }
        }

        public Aperture CurrentAperture
        {
            get { return _currentAperture; }
        }

        public Exposal CurrentExposal
        {
            get { return _currentExposal; }
        }

        public ImageQuality CurrentImageQuality
        {
            get { return _currentImageQuality; }
        }

        public CameraInfo(string aCameraId, string aProductName, string aUserName)
        {
            _id = aCameraId;
            _productName = aProductName;
            _ownerName = aUserName;
        }

        public CameraInfo(string aCameraId): this(aCameraId, string.Empty, string.Empty)
        {
        }

        public CameraInfo(ICamera aCamera): this(aCamera.Id, aCamera.ProductName, aCamera.OwnerName)
        {
            _isoSpeeds = IsoSpeed.GetListFrom(aCamera);
            _apertures = Aperture.GetListFrom(aCamera);
            _exposals = Exposal.GetListFrom(aCamera);
            _imageQualities = ImageQuality.GetListFrom(aCamera);

            _currentIsoSpeed = IsoSpeed.With(aCamera.IsoSpeed);
            _currentAperture = Aperture.With(aCamera.ApertureValue);
            _currentExposal = Exposal.With(aCamera.ExposalValue);
            _currentImageQuality = ImageQuality.With(aCamera.ImageQualityValue);
        }

        public override string ToString()
        {
            return DisplayString;
        }
    }
}
