﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class Constants
    {
        public static string NAP_AM = "NAP_AM";
        public static string VONG_TRUONG_SINH = "VONG_TRUONG_SINH";

        public static string TRU_NGAY = "NGAY";
        public static string TRU_GIO = "GIO";
        public static string TRU_THANG = "THANG";
        public static string TRU_NAM = "NAM";
        public static string CUNG_MENH = "CUNG MENH";
        public static string THAI_NGUYEN = "THAI NGUYEN";

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

        public static class CungMenhSao
        {
            public static string CUNG_MENH_SAO = "CUNG_MENH_SAO";
            public static string THIEN_QUY = "THIEN_QUY";
            public static string THIEN_ACH = "THIEN_ACH";
            public static string THIEN_QUYEN = "THIEN_QUYEN";
            public static string THIEN_XICH = "THIEN_XICH";
            public static string THIEN_NHU = "THIEN_NHU";
            public static string THIEN_VAN = "THIEN_VAN";
            public static string THIEN_PHUC = "THIEN_PHUC";
            public static string THIEN_LAO = "THIEN_LAO";
            public static string THIEN_QUA = "THIEN_QUA";
            public static string THIEN_BI = "THIEN_BI";
            public static string THIEN_NGHE = "THIEN_NGHE";
            public static string THIEN_THO = "THIEN_THO";
        }

        public static class ThuocTinh
        {
            #region Luc Hop
            public static string LUC_HOP_SINH = "LUC_HOP_SINH";
            public static string LUC_HOP_KHAC = "LUC_HOP_KHAC";
            #endregion Luc Hop

            #region Tam Hoi
            public static string TAM_HOI = "TAM_HOI";
            public static string BAN_TAM_HOI = "BAN_TAM_HOI";
            #endregion Tam Hoi

            #region Tam Hop
            public static string TAM_HOP = "TAM_HOP";
            public static string BAN_TAM_HOP = "BAN_TAM_HOP";
            #endregion Tam Hop

        }

        public static class DiaChiLucHop
        {
            public static string LUC_HOP_KHAC = @"TRONG HOP CO KHAC: Truoc tot ma sau xau, truoc nong ma sau lanh.
Co the quan he vo chong hoac ban be, luc dau rat tot nhung sau do ly hon hoac tinh ban tan vo";
            public static string LUC_HOP_SINH = @"TRONG HOP CO SINH: Quan he vo chong hay cac moi quan he xa hoi thi ngay cang tot dep hon";

            public static string GUIDELINES = @"Luc hop, nam hop thi dep, nu hop thi da dam. Phu Nhan Ky Hop.";
        }

        public static class DiaChiTamHoi
        {
            public static string TAM_HOI = @"";
            public static string BAN_TAM_HOI = @"";
        }

        public static class DiaChiTamHop
        {
            public static string TAM_HOP = @"";
            public static string BAN_TAM_HOP = @"";

            public static string GUIDELINES = @"Kien Loc hop thuong nhieu tai san, van may ngoai y muon.
Neu la hop quy nhan Chinh An, thi duoc thien an vo cung tot.
Neu la hop Thuc Than, com an ao mac tai loc doi dao.
Neu la hop Nguyen Than Dai Hao, nguoi khong phep tac, noi thi cao sang ma hanh thi thap kem, gan tieu nhan xa quan tu.
Neu la hop Ham Tri, thuong la dam loan bat luong, pham tuc.
Tam hop, nam hop thi dep, nu hop thi da dam. Phu Nhan Ky Hop.";
        }
    }
}
