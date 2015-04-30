using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class Constants
    {
        public static string TRU_NGAY = "NGAY";
        public static string TRU_GIO = "GIO";
        public static string TRU_THANG = "THANG";
        public static string TRU_NAM = "NAM";

        public static int SO_DAI_VAN = 9;
        public static int NAM_DAI_VAN = 10;
        public static int SO_TIEU_VAN = SO_DAI_VAN * NAM_DAI_VAN;


        public static int SEEDING_YEAR = 2015;
        public static CanEnum SEEDING_CAN = CanEnum.At;
        public static ChiEnum SEEDING_CHI = ChiEnum.Mui;

        public static int CUNG_MENH_SHIFT = -1;
        public static int CUNG_MENH_LOWER_BOUND = 14;
        public static int CUNG_MENH_UPPER_BOUND = 26;

        public static int THAI_NGUYEN_CAN_SHIFT = 1;
        public static int THAI_NGUYEN_CHI_SHIFT = 3;
    }
}
