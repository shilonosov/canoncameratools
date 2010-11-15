using System;
using EDSDKLib;

namespace Source
{
    public class IsoSpeed : EnumValue
    {
        public static EnumValueCollection IsoSpeeds = new EnumValueCollection();

        static IsoSpeed()
        {
            IsoSpeeds.Add(new IsoSpeed(IsoSpeedEnum.isoAuto, "Iso AUTO"));
            IsoSpeeds.Add(new IsoSpeed(IsoSpeedEnum.iso6, "Iso 6"));
            IsoSpeeds.Add(new IsoSpeed(IsoSpeedEnum.iso12, "Iso 12"));
            IsoSpeeds.Add(new IsoSpeed(IsoSpeedEnum.iso25, "Iso 25"));
            IsoSpeeds.Add(new IsoSpeed(IsoSpeedEnum.iso50, "Iso 50"));
            IsoSpeeds.Add(new IsoSpeed(IsoSpeedEnum.iso100, "Iso 100"));
            IsoSpeeds.Add(new IsoSpeed(IsoSpeedEnum.iso125, "Iso 125"));
            IsoSpeeds.Add(new IsoSpeed(IsoSpeedEnum.iso160, "Iso 160"));
            IsoSpeeds.Add(new IsoSpeed(IsoSpeedEnum.iso200, "Iso 200"));
            IsoSpeeds.Add(new IsoSpeed(IsoSpeedEnum.iso250, "Iso 250"));
            IsoSpeeds.Add(new IsoSpeed(IsoSpeedEnum.iso320, "Iso 320"));
            IsoSpeeds.Add(new IsoSpeed(IsoSpeedEnum.iso400, "Iso 400"));
            IsoSpeeds.Add(new IsoSpeed(IsoSpeedEnum.iso500, "Iso 500"));
            IsoSpeeds.Add(new IsoSpeed(IsoSpeedEnum.iso640, "Iso 640"));
            IsoSpeeds.Add(new IsoSpeed(IsoSpeedEnum.iso800, "Iso 800"));
            IsoSpeeds.Add(new IsoSpeed(IsoSpeedEnum.iso1000, "Iso 1000"));
            IsoSpeeds.Add(new IsoSpeed(IsoSpeedEnum.iso1250, "Iso 1250"));
            IsoSpeeds.Add(new IsoSpeed(IsoSpeedEnum.iso1600, "Iso 1600"));
            IsoSpeeds.Add(new IsoSpeed(IsoSpeedEnum.iso2000, "Iso 2000"));
            IsoSpeeds.Add(new IsoSpeed(IsoSpeedEnum.iso2500, "Iso 2500"));
            IsoSpeeds.Add(new IsoSpeed(IsoSpeedEnum.iso3200, "Iso 3200"));
            IsoSpeeds.Add(new IsoSpeed(IsoSpeedEnum.iso4000, "Iso 4000"));
            IsoSpeeds.Add(new IsoSpeed(IsoSpeedEnum.iso5000, "Iso 5000"));
            IsoSpeeds.Add(new IsoSpeed(IsoSpeedEnum.iso6400, "Iso 6400"));
            IsoSpeeds.Add(new IsoSpeed(IsoSpeedEnum.iso12800, "Iso 12800"));
        }

        public static IsoSpeed With(uint aValue)
        {
            return (IsoSpeed) IsoSpeeds[aValue];
        }

        public static IsoSpeed With(IsoSpeedEnum anIsoSpeedEnum)
        {
            return new IsoSpeed(anIsoSpeedEnum, string.Format("#{0}", anIsoSpeedEnum));
        }

        public IsoSpeed(IsoSpeedEnum anIsoSpeedEnum, string aDisplayString) : base((uint)anIsoSpeedEnum, aDisplayString, EDSDK.PropID_ISOSpeed)
        {}

        public static EnumValueCollection GetListFrom(ICamera aCamera)
        {
            return GetListFrom(aCamera, EDSDK.PropID_ISOSpeed, IsoSpeeds);
            
        }
    }
}