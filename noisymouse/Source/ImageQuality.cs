using System;
using EDSDKLib;

namespace Source
{
    public class ImageQuality : EnumValue
    {
        public static EnumValueCollection ImageQualityValues = new EnumValueCollection();

        static ImageQuality()
        {
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_L, "L"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_M1, "M1"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_M2, "M2"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_S, "S"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_RAW, "Raw"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_RAW_L, "Raw+L"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_RAW_M1, "Raw+M1"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_RAW_M2, "Raw+M2"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_RAW_S, "Raw+S"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_sRAW, "sRaw"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_sRAW_L, "sRaw+L"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_sRAW_M1, "sRaw+M1"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_sRAW_M2, "sRaw+M2"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_sRAW_S, "sRaw+S"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_sRAW_L_hq, "sRaw+L HQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_sRAW_L_lq, "sRaw+L LQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_sRAW_M_hq, "sRaw+M HQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_sRAW_M_lq, "sRaw+M LQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_sRAW_S_hq, "sRaw+S HQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_sRAW_S_lq, "sRaw+S LQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_L_hq, "L HQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_M_hq, "M HQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_S_hq, "S HQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_L_lq, "L LQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_M_lq, "M LQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_S_lq, "S LQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_RAW_L_hq, "Raw+L HQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_RAW_M_hq, "Raw+M HQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_RAW_S_hq, "Raw+S HQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_RAW_L_lq, "Raw+L LQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_RAW_M_lq, "Raw+M LQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_RAW_S_lq, "Raw+S LQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_sRAW1, "sRaw1"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_sRAW1_L_hq, "sRaw1+L HQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_sRAW1_L_lq, "sRaw1+L LQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_sRAW1_M_hq, "sRaw1+M HQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_sRAW1_M_lq, "sRaw1+M LQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_sRAW1_S_hq, "sRaw1+S HQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.PPT_sRAW1_S_lq, "sRaw1+s LQ"));

            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.Legacy_L, "L"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.Legacy_M1, "M1"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.Legacy_M2, "M2"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.Legacy_S, "S"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.Legacy_RAW_type_one, "Raw"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.Legacy_RAW_L, "Raw+L"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.Legacy_RAW_M1, "Raw+M1"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.Legacy_RAW_M2, "Raw+M2"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.Legacy_RAW_S, "Raw+S"));

            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.Legacy_L_hq, "L HQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.Legacy_M_hq, "M HQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.Legacy_S_hq, "S HQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.Legacy_L_lq, "L LQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.Legacy_M_lq, "M LQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.Legacy_S_lq, "S LQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.Legacy_RAW_type_two, "Raw"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.Legacy_RAW_L_hq, "Raw+L HQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.Legacy_RAW_M_hq, "Raw+M HQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.Legacy_RAW_S_hq, "Raw+S HQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.Legacy_RAW_L_lq, "Raw+L LQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.Legacy_RAW_M_lq, "Raw+M LQ"));
            ImageQualityValues.Add(new ImageQuality(ImageQualityEnum.Legacy_RAW_S_lq, "Raw+S LQ"));
        }

        public ImageQuality(ImageQualityEnum anImageQualityEnum, string aDisplayString)
            : base((uint)anImageQualityEnum, aDisplayString, EDSDK.PropID_ImageQuality)
        {
        }

        public static ImageQuality With(uint aValue)
        {
            return (ImageQuality)ImageQualityValues[aValue];
        }

        public static ImageQuality With(ImageQualityEnum anImageQualityEnum)
        {
            return new ImageQuality(anImageQualityEnum, string.Format("#{0}", anImageQualityEnum));
        }

        public static EnumValueCollection GetListFrom(ICamera aCamera)
        {
            return GetListFrom(aCamera, EDSDK.PropID_ImageQuality, ImageQualityValues);
        }
    }
}