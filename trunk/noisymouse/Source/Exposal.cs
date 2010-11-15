using System;
using EDSDKLib;
using System.Collections.Generic;

namespace Source
{
    public class Exposal : EnumValue
    {
        public static EnumValueCollection Exposals = new EnumValueCollection();
        public static Dictionary<ExposalEnum, double> delays = new Dictionary<ExposalEnum, double>();

        static Exposal()
        {
            delays.Add(ExposalEnum.tZero, 0);
            delays.Add(ExposalEnum.tBulb, double.MaxValue);
            delays.Add(ExposalEnum.t30, 30);
            delays.Add(ExposalEnum.t25, 25);
            delays.Add(ExposalEnum.t20, 20);
            delays.Add(ExposalEnum.t20_stepOneThird, 20);
            delays.Add(ExposalEnum.t15, 15);
            delays.Add(ExposalEnum.t13, 13);
            delays.Add(ExposalEnum.t10, 10);
            delays.Add(ExposalEnum.t10_stepOneThird, 10);
            delays.Add(ExposalEnum.t8, 8);
            delays.Add(ExposalEnum.t6, 6);
            delays.Add(ExposalEnum.t6_stepOneThird, 6);
            delays.Add(ExposalEnum.t5, 5);
            delays.Add(ExposalEnum.t4, 4);
            delays.Add(ExposalEnum.t3dot2, 3.2);
            delays.Add(ExposalEnum.t3, 3);
            delays.Add(ExposalEnum.t2dot5, 2.5);
            delays.Add(ExposalEnum.t2, 2);
            delays.Add(ExposalEnum.t1dot6, 1.6);
            delays.Add(ExposalEnum.t1dot5, 1.5);
            delays.Add(ExposalEnum.t1dot3, 1.3);
            delays.Add(ExposalEnum.t1, 1);
            delays.Add(ExposalEnum.t0dot8, 0.8);
            delays.Add(ExposalEnum.t0dot7, 0.7);
            delays.Add(ExposalEnum.t0dot6, 0.6);
            delays.Add(ExposalEnum.t0dot5, 0.5);
            delays.Add(ExposalEnum.t0dot4, 0.4);
            delays.Add(ExposalEnum.t0dot3, 0.3);
            delays.Add(ExposalEnum.t0dot3_stepOneThird, 0/3);
            delays.Add(ExposalEnum.t1_4, 1/4);
            delays.Add(ExposalEnum.t1_5, 1/5);
            delays.Add(ExposalEnum.t1_6, 1/6);
            delays.Add(ExposalEnum.t1_6_stepOneThird, 1/6);
            delays.Add(ExposalEnum.t1_8, 1/8);
            delays.Add(ExposalEnum.t1_10, 1/10);
            delays.Add(ExposalEnum.t1_10_stepOneThird, 1/10);
            delays.Add(ExposalEnum.t1_13, 1/13);
            delays.Add(ExposalEnum.t1_15, 1/15);
            delays.Add(ExposalEnum.t1_20, 1/20);
            delays.Add(ExposalEnum.t1_20_stepOneThird, 1/20);
            delays.Add(ExposalEnum.t1_25, 1/25);
            delays.Add(ExposalEnum.t1_30, 1/30);
            delays.Add(ExposalEnum.t1_40, 1/40);
            delays.Add(ExposalEnum.t1_45, 1/45);
            delays.Add(ExposalEnum.t1_50, 1/50);
            delays.Add(ExposalEnum.t1_60, 1/60);
            delays.Add(ExposalEnum.t1_80, 1/80);
            delays.Add(ExposalEnum.t1_90, 1/90);
            delays.Add(ExposalEnum.t1_100, 1/100);
            delays.Add(ExposalEnum.t1_125, 1/125);
            delays.Add(ExposalEnum.t1_160, 1/160);
            delays.Add(ExposalEnum.t1_180, 1/180);
            delays.Add(ExposalEnum.t1_200, 1/200);
            delays.Add(ExposalEnum.t1_250, 1/250);
            delays.Add(ExposalEnum.t1_320, 1/320);
            delays.Add(ExposalEnum.t1_350, 1/350);
            delays.Add(ExposalEnum.t1_400, 1/400);
            delays.Add(ExposalEnum.t1_500, 1/500);
            delays.Add(ExposalEnum.t1_640, 1/640);
            delays.Add(ExposalEnum.t1_750, 1/750);
            delays.Add(ExposalEnum.t1_800, 1/800);
            delays.Add(ExposalEnum.t1_1000, 1/1000);
            delays.Add(ExposalEnum.t1_1250, 1/1250);
            delays.Add(ExposalEnum.t1_1500, 1/1500);
            delays.Add(ExposalEnum.t1_1600, 1/1600);
            delays.Add(ExposalEnum.t1_2000, 1/2000);
            delays.Add(ExposalEnum.t1_2500, 1/2500);
            delays.Add(ExposalEnum.t1_3000, 1/3000);
            delays.Add(ExposalEnum.t1_3200, 1/3200);
            delays.Add(ExposalEnum.t1_4000, 1/4000);
            delays.Add(ExposalEnum.t1_5000, 1/5000);
            delays.Add(ExposalEnum.t1_6000, 1/6000);
            delays.Add(ExposalEnum.t1_6400, 1/6400);
            delays.Add(ExposalEnum.t1_8000, 1/8000);
            
            
            Exposals.Add(new Exposal(ExposalEnum.tZero, "0"));
            Exposals.Add(new Exposal(ExposalEnum.tBulb, "Bulb"));
            Exposals.Add(new Exposal(ExposalEnum.t30, "30\""));
            Exposals.Add(new Exposal(ExposalEnum.t25, "25\""));
            Exposals.Add(new Exposal(ExposalEnum.t20, "20\""));
            Exposals.Add(new Exposal(ExposalEnum.t20_stepOneThird, "20\""));
            Exposals.Add(new Exposal(ExposalEnum.t15, "15\""));
            Exposals.Add(new Exposal(ExposalEnum.t13, "13\""));
            Exposals.Add(new Exposal(ExposalEnum.t10, "10\""));
            Exposals.Add(new Exposal(ExposalEnum.t10_stepOneThird, "10\""));
            Exposals.Add(new Exposal(ExposalEnum.t8, "8\""));
            Exposals.Add(new Exposal(ExposalEnum.t6, "6\""));
            Exposals.Add(new Exposal(ExposalEnum.t6_stepOneThird, "6\""));
            Exposals.Add(new Exposal(ExposalEnum.t5, "5\""));
            Exposals.Add(new Exposal(ExposalEnum.t4, "4\""));
            Exposals.Add(new Exposal(ExposalEnum.t3dot2, "3\"2"));
            Exposals.Add(new Exposal(ExposalEnum.t3, "3\""));
            Exposals.Add(new Exposal(ExposalEnum.t2dot5, "2\"5"));
            Exposals.Add(new Exposal(ExposalEnum.t2, "2\""));
            Exposals.Add(new Exposal(ExposalEnum.t1dot6, "1\"6"));
            Exposals.Add(new Exposal(ExposalEnum.t1dot5, "1\"5"));
            Exposals.Add(new Exposal(ExposalEnum.t1dot3, "1\"3"));
            Exposals.Add(new Exposal(ExposalEnum.t1, "1\""));
            Exposals.Add(new Exposal(ExposalEnum.t0dot8, "0\"8"));
            Exposals.Add(new Exposal(ExposalEnum.t0dot7, "0\"7"));
            Exposals.Add(new Exposal(ExposalEnum.t0dot6, "0\"6"));
            Exposals.Add(new Exposal(ExposalEnum.t0dot5, "0\"5"));
            Exposals.Add(new Exposal(ExposalEnum.t0dot4, "0\"4"));
            Exposals.Add(new Exposal(ExposalEnum.t0dot3, "0\"3"));
            Exposals.Add(new Exposal(ExposalEnum.t0dot3_stepOneThird, "0\"3"));
            Exposals.Add(new Exposal(ExposalEnum.t1_4, "1/4"));
            Exposals.Add(new Exposal(ExposalEnum.t1_5, "1/5"));
            Exposals.Add(new Exposal(ExposalEnum.t1_6, "1/6"));
            Exposals.Add(new Exposal(ExposalEnum.t1_6_stepOneThird, "1/6"));
            Exposals.Add(new Exposal(ExposalEnum.t1_8, "1/8"));
            Exposals.Add(new Exposal(ExposalEnum.t1_10, "1/10"));
            Exposals.Add(new Exposal(ExposalEnum.t1_10_stepOneThird, "1/10"));
            Exposals.Add(new Exposal(ExposalEnum.t1_13, "1/13"));
            Exposals.Add(new Exposal(ExposalEnum.t1_15, "1/15"));
            Exposals.Add(new Exposal(ExposalEnum.t1_20, "1/20"));
            Exposals.Add(new Exposal(ExposalEnum.t1_20_stepOneThird, "1/20"));
            Exposals.Add(new Exposal(ExposalEnum.t1_25, "1/25"));
            Exposals.Add(new Exposal(ExposalEnum.t1_30, "1/30"));
            Exposals.Add(new Exposal(ExposalEnum.t1_40, "1/40"));
            Exposals.Add(new Exposal(ExposalEnum.t1_45, "1/45"));
            Exposals.Add(new Exposal(ExposalEnum.t1_50, "1/50"));
            Exposals.Add(new Exposal(ExposalEnum.t1_60, "1/60"));
            Exposals.Add(new Exposal(ExposalEnum.t1_80, "1/80"));
            Exposals.Add(new Exposal(ExposalEnum.t1_90, "1/90"));
            Exposals.Add(new Exposal(ExposalEnum.t1_100, "1/100"));
            Exposals.Add(new Exposal(ExposalEnum.t1_125, "1/125"));
            Exposals.Add(new Exposal(ExposalEnum.t1_160, "1/160"));
            Exposals.Add(new Exposal(ExposalEnum.t1_180, "1/180"));
            Exposals.Add(new Exposal(ExposalEnum.t1_200, "1/200"));
            Exposals.Add(new Exposal(ExposalEnum.t1_250, "1/250"));
            Exposals.Add(new Exposal(ExposalEnum.t1_320, "1/320"));
            Exposals.Add(new Exposal(ExposalEnum.t1_350, "1/350"));
            Exposals.Add(new Exposal(ExposalEnum.t1_400, "1/400"));
            Exposals.Add(new Exposal(ExposalEnum.t1_500, "1/500"));
            Exposals.Add(new Exposal(ExposalEnum.t1_640, "1/640"));
            Exposals.Add(new Exposal(ExposalEnum.t1_750, "1/750"));
            Exposals.Add(new Exposal(ExposalEnum.t1_800, "1/800"));
            Exposals.Add(new Exposal(ExposalEnum.t1_1000, "1/1000"));
            Exposals.Add(new Exposal(ExposalEnum.t1_1250, "1/1250"));
            Exposals.Add(new Exposal(ExposalEnum.t1_1500, "1/1500"));
            Exposals.Add(new Exposal(ExposalEnum.t1_1600, "1/1600"));
            Exposals.Add(new Exposal(ExposalEnum.t1_2000, "1/2000"));
            Exposals.Add(new Exposal(ExposalEnum.t1_2500, "1/2500"));
            Exposals.Add(new Exposal(ExposalEnum.t1_3000, "1/3000"));
            Exposals.Add(new Exposal(ExposalEnum.t1_3200, "1/3200"));
            Exposals.Add(new Exposal(ExposalEnum.t1_4000, "1/4000"));
            Exposals.Add(new Exposal(ExposalEnum.t1_5000, "1/5000"));
            Exposals.Add(new Exposal(ExposalEnum.t1_6000, "1/6000"));
            Exposals.Add(new Exposal(ExposalEnum.t1_6400, "1/6400"));
            Exposals.Add(new Exposal(ExposalEnum.t1_8000, "1/8000"));
        }

        private readonly int _delayInMilliseconds;

        public static Exposal With(uint aValue)
        {
            return (Exposal)Exposals[aValue];
        }

        public static Exposal With(ExposalEnum anExposalEnum)
        {
            return new Exposal(anExposalEnum, string.Format("#{0}", anExposalEnum));
        }

        public Exposal(ExposalEnum anExposalEnumValue, string aDisplayString)
            : base((uint)anExposalEnumValue, aDisplayString, EDSDK.PropID_Tv)
        {
            _delayInMilliseconds = (int)delays[anExposalEnumValue] * 1000;
        }

        public int GetDelay()
        {
            return _delayInMilliseconds;
        }

        public static EnumValueCollection GetListFrom(ICamera aCamera)
        {
            return GetListFrom(aCamera, EDSDK.PropID_Tv, Exposals);
            
        }
    }
}