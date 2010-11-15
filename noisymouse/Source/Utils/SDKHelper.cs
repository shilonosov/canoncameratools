using System;
using System.Collections.Generic;
using EDSDKLib;

namespace Source
{
    public class SDKException : ApplicationException
    {
        public SDKException()
            : base()
        { }

        public SDKException(string aMessage)
            : base(aMessage)
        { }
    }

    public class SDKInvalidParameterExeption : SDKException
    {
    }

    public class ShootingException : SDKException
    {
        private static readonly Dictionary<uint, string> _errors = new Dictionary<uint, string>();

        static ShootingException()
        {
            _errors[0x00000001] = "Shooting failure";
            _errors[0x00000002] = "The lens was closed";
            _errors[0x00000003] = "General errors from the shooting mode, such as errors from the bulb or mirror-up mechanism";
            _errors[0x00000004] = "Sensor cleaning";
            _errors[0x00000005] = "Error because the camera was set for silent operation (in PF21)";
            _errors[0x00000006] = "Prohibited settings using CFn-2, and no card inserted";
            _errors[0x00000007] = "Card error (including CARD-FULL/No.-FULL)";
            _errors[0x00000008] = "Write-protected";
        }

        public ShootingException()
            : base()
        { }

        public ShootingException(uint aCode)
            : base(_errors[aCode])
        { }
    }

    public class SDKHelper
    {
        public static void CheckError(uint aErrorCode)
        {
            if (aErrorCode == EDSDK.EDS_ERR_INVALID_PARAMETER)
            {
                throw new SDKInvalidParameterExeption();
            }
            if (aErrorCode != EDSDK.EDS_ERR_OK)
            {
                throw new ApplicationException(aErrorCode.ToString());
            }
        }

        public static string DecodeEvent(uint inEvent)
        {
            switch (inEvent)
            {
                case EDSDK.PropertyEvent_PropertyChanged: return "PropertyEvent_PropertyChanged";
                case EDSDK.PropertyEvent_PropertyDescChanged: return "PropertyEvent_PropertyDescChanged";
                case EDSDK.ObjectEvent_VolumeInfoChanged: return "ObjectEvent_VolumeInfoChanged";
                case EDSDK.ObjectEvent_VolumeUpdateItems: return "ObjectEvent_VolumeUpdateItems";
                case EDSDK.ObjectEvent_FolderUpdateItems: return "ObjectEvent_FolderUpdateItems";
                case EDSDK.ObjectEvent_DirItemCreated: return "ObjectEvent_DirItemCreated";
                case EDSDK.ObjectEvent_DirItemRemoved: return "ObjectEvent_DirItemRemoved";
                case EDSDK.ObjectEvent_DirItemInfoChanged: return "ObjectEvent_DirItemInfoChanged";
                case EDSDK.ObjectEvent_DirItemContentChanged: return "ObjectEvent_DirItemContentChanged";
                case EDSDK.ObjectEvent_DirItemRequestTransfer: return "ObjectEvent_DirItemRequestTransfer";
                case EDSDK.ObjectEvent_DirItemRequestTransferDT: return "ObjectEvent_DirItemRequestTransferDT";
                case EDSDK.ObjectEvent_DirItemCancelTransferDT: return "ObjectEvent_DirItemCancelTransferDT";
                case EDSDK.ObjectEvent_VolumeAdded: return "ObjectEvent_VolumeAdded";
                case EDSDK.ObjectEvent_VolumeRemoved: return "ObjectEvent_VolumeRemoved";
            }
            return inEvent.ToString();
        }

        public static string DecodeProperty(uint inPropertyID)
        {
            switch (inPropertyID)
            {
                case EDSDK.PropID_ProductName: return "PropID_ProductName";
                case EDSDK.PropID_BodyID: return "PropID_BodyID";
                case EDSDK.PropID_OwnerName: return "PropID_OwnerName";
                case EDSDK.PropID_MakerName: return "PropID_MakerName";
                case EDSDK.PropID_DateTime: return "PropID_DateTime";
                case EDSDK.PropID_FirmwareVersion: return "PropID_FirmwareVersion";
                case EDSDK.PropID_BatteryLevel: return "PropID_BatteryLevel";
                case EDSDK.PropID_CFn: return "PropID_CFn";
                case EDSDK.PropID_SaveTo: return "PropID_SaveTo";
                case EDSDK.kEdsPropID_CurrentStorage: return "kEdsPropID_CurrentStorage";
                case EDSDK.kEdsPropID_CurrentFolder: return "kEdsPropID_CurrentFolder";
                case EDSDK.kEdsPropID_MyMenu: return "kEdsPropID_MyMenu";

                case EDSDK.PropID_AEMode: return "PropID_AEMode";
                case EDSDK.PropID_DriveMode: return "PropID_DriveMode";
                case EDSDK.PropID_ISOSpeed: return "PropID_ISOSpeed";
                case EDSDK.PropID_MeteringMode: return "PropID_MeteringMode";
                case EDSDK.PropID_AFMode: return "PropID_AFMode";
                case EDSDK.PropID_Av: return "PropID_Av";
                case EDSDK.PropID_Tv: return "PropID_Tv";
                case EDSDK.PropID_ExposureCompensation: return "PropID_ExposureCompensation";
                case EDSDK.PropID_FlashCompensation: return "PropID_FlashCompensation";
                case EDSDK.PropID_FocalLength: return "PropID_FocalLength";
                case EDSDK.PropID_AvailableShots: return "PropID_AvailableShots";
                case EDSDK.PropID_Bracket: return "PropID_Bracket";
                case EDSDK.PropID_WhiteBalanceBracket: return "PropID_WhiteBalanceBracket";
                case EDSDK.PropID_LensName: return "PropID_LensName";
                case EDSDK.PropID_AEBracket: return "PropID_AEBracket";
                case EDSDK.PropID_FEBracket: return "PropID_FEBracket";
                case EDSDK.PropID_ISOBracket: return "PropID_ISOBracket";
                case EDSDK.PropID_NoiseReduction: return "PropID_NoiseReduction";
                case EDSDK.PropID_FlashOn: return "PropID_FlashOn";
                case EDSDK.PropID_RedEye: return "PropID_RedEye";
                case EDSDK.PropID_FlashMode: return "PropID_FlashMode";
                case EDSDK.PropID_LensStatus: return "PropID_LensStatus";

                case EDSDK.PropID_Artist: return "PropID_Artist";
                case EDSDK.PropID_Copyright: return "PropID_Copyright";
                case EDSDK.PropID_DepthOfField: return "PropID_DepthOfField";
                case EDSDK.PropID_EFCompensation: return "PropID_EFCompensation";


                case EDSDK.PropID_Evf_OutputDevice: return "PropID_Evf_OutputDevice";
                case EDSDK.PropID_Evf_Mode: return "PropID_Evf_Mode";
                case EDSDK.PropID_Evf_WhiteBalance: return "PropID_Evf_WhiteBalance";
                case EDSDK.PropID_Evf_ColorTemperature: return "PropID_Evf_ColorTemperature";
                case EDSDK.PropID_Evf_DepthOfFieldPreview: return "PropID_Evf_DepthOfFieldPreview";

            }

            return inPropertyID.ToString();
        }
    }

    public class CameraAlreadyDisposedException : SDKException
    {
        public CameraAlreadyDisposedException(string aMessage)
            : base(aMessage)
        { }

        public static void ThrowIf(bool anExpression)
        {
            if (anExpression)
            {
                throw new CameraAlreadyDisposedException("Cannot operate - camera disconnected");
            }
        }
    }
}
