using System;
using EDSDKLib;

namespace Source
{
    public class SaveTo : EnumValue
    {
        public static EnumValueCollection SaveToValues = new EnumValueCollection();

        static SaveTo()
        {
            SaveToValues.Add(new SaveTo(SaveToEnum.Save_both_ways, "Both ways"));
            SaveToValues.Add(new SaveTo(SaveToEnum.Save_by_downloading_to_a_host_computer, "Download to host"));
            SaveToValues.Add(new SaveTo(SaveToEnum.Save_on_a_memory_card_of_a_remote_camera, "On the camera card"));
        }

        public SaveTo(SaveToEnum anIsoSpeedEnum, string aDisplayString)
            : base((uint)anIsoSpeedEnum, aDisplayString, EDSDK.PropID_SaveTo)
        {
        }

        public static SaveTo With(int aValue)
        {
            return (SaveTo) SaveToValues[aValue];
        }

        public static SaveTo With(SaveToEnum aSaveToEnum)
        {
            return new SaveTo(aSaveToEnum, string.Format("#{0}", aSaveToEnum));
        }

        public static EnumValueCollection GetListFrom(ICamera aCamera)
        {
            return GetListFrom(aCamera, EDSDK.PropID_SaveTo, SaveToValues);
        }
    }
}