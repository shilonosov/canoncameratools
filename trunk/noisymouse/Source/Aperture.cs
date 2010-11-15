using System;
using EDSDKLib;

namespace Source
{
    public class Aperture: EnumValue
    {
        public static EnumValueCollection Apertures = new EnumValueCollection();

        static Aperture()
        {
           Apertures.Add(new Aperture(ApertureEnum.f0, "F0"));
           Apertures.Add(new Aperture(ApertureEnum.f1, "F1"));
           Apertures.Add(new Aperture(ApertureEnum.f1_1, "F1.1"));
           Apertures.Add(new Aperture(ApertureEnum.f1_2, "F1.2"));
           Apertures.Add(new Aperture(ApertureEnum.f1_2_stepOneThird, "F1.2"));
           Apertures.Add(new Aperture(ApertureEnum.f1_4, "F1.4"));
           Apertures.Add(new Aperture(ApertureEnum.f1_6, "F1.6"));
           Apertures.Add(new Aperture(ApertureEnum.f1_8, "F1.8"));
           Apertures.Add(new Aperture(ApertureEnum.f1_8_stepOneThird, "F1.8"));
           Apertures.Add(new Aperture(ApertureEnum.f2, "F2"));
           Apertures.Add(new Aperture(ApertureEnum.f2_2, "F2.2"));
           Apertures.Add(new Aperture(ApertureEnum.f2_5, "F2.5"));
           Apertures.Add(new Aperture(ApertureEnum.f2_5_stepOneThird, "F2.5"));
           Apertures.Add(new Aperture(ApertureEnum.f2_8, "F2.8"));
           Apertures.Add(new Aperture(ApertureEnum.f3_2, "F3.2"));
           Apertures.Add(new Aperture(ApertureEnum.f3_5, "F3.5"));
           Apertures.Add(new Aperture(ApertureEnum.f3_5_stepOneThird, "F3.5"));
           Apertures.Add(new Aperture(ApertureEnum.f4, "F4"));
           Apertures.Add(new Aperture(ApertureEnum.f4_5, "F4.5"));
           Apertures.Add(new Aperture(ApertureEnum.f4_5_stepOneThird, "F4.5"));
           Apertures.Add(new Aperture(ApertureEnum.f5, "F5.0"));
           Apertures.Add(new Aperture(ApertureEnum.f5_6, "F5.6"));
           Apertures.Add(new Aperture(ApertureEnum.f6_3, "F6.3"));
           Apertures.Add(new Aperture(ApertureEnum.f6_7, "F6.7"));
           Apertures.Add(new Aperture(ApertureEnum.f7_1, "F7.1"));
           Apertures.Add(new Aperture(ApertureEnum.f8, "F8"));
           Apertures.Add(new Aperture(ApertureEnum.f9, "F9"));
           Apertures.Add(new Aperture(ApertureEnum.f9_5, "F9.5"));
           Apertures.Add(new Aperture(ApertureEnum.f10, "F10"));
           Apertures.Add(new Aperture(ApertureEnum.f11, "F11"));
           Apertures.Add(new Aperture(ApertureEnum.f13, "F13"));
           Apertures.Add(new Aperture(ApertureEnum.f13_stepOneThird, "F13"));
           Apertures.Add(new Aperture(ApertureEnum.f14, "F14"));
           Apertures.Add(new Aperture(ApertureEnum.f16, "F16"));
           Apertures.Add(new Aperture(ApertureEnum.f18, "F18"));
           Apertures.Add(new Aperture(ApertureEnum.f19, "F19"));
           Apertures.Add(new Aperture(ApertureEnum.f20, "F20"));
           Apertures.Add(new Aperture(ApertureEnum.f22, "F22"));
           Apertures.Add(new Aperture(ApertureEnum.f25, "F25"));
           Apertures.Add(new Aperture(ApertureEnum.f27, "F27"));
           Apertures.Add(new Aperture(ApertureEnum.f29, "F29"));
           Apertures.Add(new Aperture(ApertureEnum.f32, "F32"));
           Apertures.Add(new Aperture(ApertureEnum.f36, "F36"));
           Apertures.Add(new Aperture(ApertureEnum.f38, "F38"));
           Apertures.Add(new Aperture(ApertureEnum.f40, "F40"));
           Apertures.Add(new Aperture(ApertureEnum.f45, "F45"));
           Apertures.Add(new Aperture(ApertureEnum.f51, "F51"));
           Apertures.Add(new Aperture(ApertureEnum.f54, "F54"));
           Apertures.Add(new Aperture(ApertureEnum.f57, "F57"));
           Apertures.Add(new Aperture(ApertureEnum.f64, "F64"));
           Apertures.Add(new Aperture(ApertureEnum.f72, "F72"));
           Apertures.Add(new Aperture(ApertureEnum.f76, "F76"));
           Apertures.Add(new Aperture(ApertureEnum.f80, "F80"));
           Apertures.Add(new Aperture(ApertureEnum.f91, "F91"));
        }

        public static Aperture With(uint aValue)
        {
            return (Aperture) Apertures[aValue];
        }

        public static Aperture With(ApertureEnum anApertureEnum)
        {
            return new Aperture(anApertureEnum, string.Format("#{0}", anApertureEnum));
        }

        public Aperture(ApertureEnum anIsoSpeedEnum, string aDisplayString)
            : base((uint)anIsoSpeedEnum, aDisplayString, EDSDK.PropID_Av)
        {}

        public static EnumValueCollection GetListFrom(ICamera aCamera)
        {
            return GetListFrom(aCamera, EDSDK.PropID_Av, Apertures);
            
        }
    }
}