﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using EDSDKLib;

namespace Source
{
    public enum IsoSpeedEnum
    {
        isoAuto = 0x0000000,
        iso6 = 0x00000028,
        iso12 = 0x00000030,
        iso25 = 0x00000038,
        iso50 = 0x00000040,
        iso100 = 0x00000048,
        iso125 = 0x0000004b,
        iso160 = 0x0000004d,
        iso200 = 0x00000050,
        iso250 = 0x00000053,
        iso320 = 0x00000055,
        iso400 = 0x00000058,
        iso500 = 0x0000005b,
        iso640 = 0x0000005d,
        iso800 = 0x00000060,
        iso1000 = 0x00000063,
        iso1250 = 0x00000065,
        iso1600 = 0x00000068,
        iso2000 = 0x0000006b,
        iso2500 = 0x0000006d,
        iso3200 = 0x00000070,
        iso4000 = 0x00000075,
        iso5000 = 0x00000073,
        iso6400 = 0x00000078,
        iso12800 = 0x00000080,
        iso25600 = 0x00000088,
        iso51200 = 0x00000090,
        iso102400 = 0x00000098
    }

    public enum ApertureEnum
    {
            f0 = 0x00,
            f1 = 0x08,
            f1_1 = 0x0B,
            f1_2 = 0x0C,
            f1_2_stepOneThird = 0x0D,
            f1_4 = 0x10,
            f1_6 = 0x13,
            f1_8 = 0x14,
            f1_8_stepOneThird = 0x15,
            f2 = 0x18,
            f2_2 = 0x1B,
            f2_5 = 0x1C,
            f2_5_stepOneThird = 0x1D,
            f2_8 = 0x20,
            f3_2 = 0x23,
            f3_5 = 0x24,
            f3_5_stepOneThird = 0x25,
            f4 = 0x28,
            f4_5 = 0x2B,
            f4_5_stepOneThird = 0x2C,
            f5 = 0x2D,
            f5_6 = 0x30,
            f6_3 = 0x33,
            f6_7 = 0x34,
            f7_1 = 0x35,
            f8 = 0x38,
            f9 = 0x3B,
            f9_5 = 0x3C,
            f10 = 0x3D,
            f11 = 0x40,
            f13 = 0x43,
            f13_stepOneThird = 0x44,
            f14 = 0x45,
            f16 = 0x48,
            f18 = 0x4B,
            f19 = 0x4C,
            f20 = 0x4D,
            f22 = 0x50,
            f25 = 0x53,
            f27 = 0x54,
            f29 = 0x55,
            f32 = 0x58,
            f36 = 0x5B,
            f38 = 0x5C,
            f40 = 0x5D,
            f45 = 0x60,
            f51 = 0x63,
            f54 = 0x64,
            f57 = 0x65,
            f64 = 0x68,
            f72 = 0x6B,
            f76 = 0x6C,
            f80 = 0x6D,
            f91 = 0x70
    }

    public enum ExposalEnum
    {
            tZero = 0x00,
            tBulb = 0x0C,
            t30 = 0x10,
            t25 = 0x13,
            t20 = 0x14,
            t20_stepOneThird = 0x15,
            t15 = 0x18,
            t13 = 0x1B,
            t10 = 0x1C,
            t10_stepOneThird = 0x1D,
            t8 = 0x20,
            t6 = 0x23,
            t6_stepOneThird = 0x24,
            t5 = 0x25,
            t4 = 0x28,
            t3dot2 = 0x2B,
            t3 = 0x2C,
            t2dot5 = 0x2D,
            t2 = 0x30,
            t1dot6 = 0x33,
            t1dot5 = 0x34,
            t1dot3 = 0x35,
            t1 = 0x38,
            t0dot8 = 0x3B,
            t0dot7 = 0x3C,
            t0dot6 = 0x3D,
            t0dot5 = 0x40,
            t0dot4 = 0x43,
            t0dot3 = 0x44,
            t0dot3_stepOneThird = 0x45,
            t1_4 = 0x48,
            t1_5 = 0x4B,
            t1_6 = 0x4C,
            t1_6_stepOneThird = 0x4D,
            t1_8 = 0x50,
            t1_10 = 0x53,
            t1_10_stepOneThird = 0x54,
            t1_13 = 0x55,
            t1_15 = 0x58,
            t1_20 = 0x5B,
            t1_20_stepOneThird = 0x5C,
            t1_25 = 0x5D,
            t1_30 = 0x60,
            t1_40 = 0x63,
            t1_45 = 0x64,
            t1_50 = 0x65,
            t1_60 = 0x68,
            t1_80 = 0x6B,
            t1_90 = 0x6C,
            t1_100 = 0x6D,
            t1_125 = 0x70,
            t1_160 = 0x73,
            t1_180 = 0x74,
            t1_200 = 0x75,
            t1_250 = 0x78,
            t1_320 = 0x7B,
            t1_350 = 0x7C,
            t1_400 = 0x7D,
            t1_500 = 0x80,
            t1_640 = 0x83,
            t1_750 = 0x84,
            t1_800 = 0x85,
            t1_1000 = 0x88,
            t1_1250 = 0x8B,
            t1_1500 = 0x8C,
            t1_1600 = 0x8D,
            t1_2000 = 0x90,
            t1_2500 = 0x93,
            t1_3000 = 0x94,
            t1_3200 = 0x95,
            t1_4000 = 0x98,
            t1_5000 = 0x9B,
            t1_6000 = 0x9C,
            t1_6400 = 0x9D,
            t1_8000 = 0xA0
    }

    public enum SaveToEnum : uint
    {
            Save_on_a_memory_card_of_a_remote_camera = 1,
            Save_by_downloading_to_a_host_computer = 2,
            Save_both_ways = 3
    }

    public enum ImageQualityEnum
    {
        PPT_L = 0x00100f0f,
        PPT_M1 = 0x05100f0f,
        PPT_M2 = 0x06100f0f,
        PPT_S = 0x02100f0f,
        PPT_RAW = 0x00640f0f,
        PPT_RAW_L = 0x00640010,
        PPT_RAW_M1 = 0x00640510,
        PPT_RAW_M2 = 0x00640610,
        PPT_RAW_S = 0x00640210,
        PPT_sRAW = 0x02640f0f,
        PPT_sRAW_L = 0x02640010,
        PPT_sRAW_M1 = 0x02640510,
        PPT_sRAW_M2 = 0x02640610,
        PPT_sRAW_S = 0x02640210,
        PPT_sRAW_L_hq = 0x02640013,
        PPT_sRAW_L_lq = 0x02640012,
        PPT_sRAW_M_hq = 0x02640113,
        PPT_sRAW_M_lq = 0x02640112,
        PPT_sRAW_S_hq = 0x02640213,
        PPT_sRAW_S_lq = 0x02640212,
        PPT_L_hq = 0x00130f0f,
        PPT_M_hq = 0x01130f0f,
        PPT_S_hq = 0x02130f0f,
        PPT_L_lq = 0x00120f0f,
        PPT_M_lq = 0x01120f0f,
        PPT_S_lq = 0x02120f0f,
        PPT_RAW_L_hq = 0x00640013,
        PPT_RAW_M_hq = 0x00640113,
        PPT_RAW_S_hq = 0x00640213,
        PPT_RAW_L_lq = 0x00640012,
        PPT_RAW_M_lq = 0x00640112,
        PPT_RAW_S_lq = 0x00640212,
        PPT_sRAW1 = 0x01640f0f,
        PPT_sRAW1_L_hq = 0x01640013,
        PPT_sRAW1_L_lq = 0x01640012,
        PPT_sRAW1_M_hq = 0x01640113,
        PPT_sRAW1_M_lq = 0x01640112,
        PPT_sRAW1_S_hq = 0x01640213,
        PPT_sRAW1_S_lq = 0x01640212,

        Legacy_L = 0x001f000f,
        Legacy_M1 = 0x051f000f,
        Legacy_M2 = 0x061f000f,
        Legacy_S = 0x021f000f,
        Legacy_RAW_type_one = 0x002f000f,
        Legacy_RAW_L = 0x002f001f,
        Legacy_RAW_M1 = 0x002f051f,
        Legacy_RAW_M2 = 0x002f061f,
        Legacy_RAW_S = 0x002f021f,

        Legacy_L_hq = 0x00130000,
        Legacy_M_hq = 0x01130000,
        Legacy_S_hq = 0x02130000,
        Legacy_L_lq = 0x00120000,
        Legacy_M_lq = 0x01120000,
        Legacy_S_lq = 0x02120000,
        Legacy_RAW_type_two = 0x00240000,
        Legacy_RAW_L_hq = 0x00240013,
        Legacy_RAW_M_hq = 0x00240113,
        Legacy_RAW_S_hq = 0x00240213,
        Legacy_RAW_L_lq = 0x00240012,
        Legacy_RAW_M_lq = 0x00240112,
        Legacy_RAW_S_lq = 0x00240212
    }
}