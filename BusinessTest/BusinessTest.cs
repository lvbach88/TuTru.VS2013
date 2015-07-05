using Business;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTest
{
    [TestClass]
    public class BusinessTest
    {
        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            TongHopCanChi.Init();
            LookUpTable.Init();
        }

        [TestMethod]
        public void Check_CreateTuTru_NotNull()
        {
            string canNam = "Ky", chiNam = "Ty", canThang = "Dinh", chiThang = "Suu",
                canNgay = "Nham", chiNgay = "Than", canGio = "At", chiGio = "Ty",
                gt = "Nam";
            Business.TuTruMap mybiz = new Business.TuTruMap();
            mybiz.CreateTuTru(gt, canNam, chiNam, canThang, chiThang, canNgay, chiNgay, canGio, chiGio);

            Assert.IsNotNull(mybiz.LaSoCuaToi);
        }

        [TestMethod]
        public void Check_CreateTuTru_Null()
        {
            string canNam = "", chiNam = "Ty", canThang = "Dinh", chiThang = "Suu",
                canNgay = "Nham", chiNgay = "Than", canGio = "At", chiGio = "Ty",
                gt = "Nu";
            Business.TuTruMap mybiz = new Business.TuTruMap();
            mybiz.CreateTuTru(gt, canNam, chiNam, canThang, chiThang, canNgay, chiNgay, canGio, chiGio);

            Assert.IsNull(mybiz.LaSoCuaToi);
        }

        [TestMethod]
        public void Check_CreateDaiVan_AmNu()
        {
            string canNam = "Ky", chiNam = "Ty", canThang = "Dinh", chiThang = "Suu",
                canNgay = "Nham", chiNgay = "Than", canGio = "At", chiGio = "Ty",
                gt = "Nu";
            int tuoi = 9;
            Business.TuTruMap mybiz = new Business.TuTruMap();
            mybiz.CreateTuTru(gt, canNam, chiNam, canThang, chiThang, canNgay, chiNgay, canGio, chiGio);
            mybiz.CreateDaiVan(tuoi);
            var can = mybiz.LaSoCuaToi.DaiVan[4].ThienCan.Can;
            var chi = mybiz.LaSoCuaToi.DaiVan[4].DiaChi.Ten;
            var t = mybiz.LaSoCuaToi.TuoiDaiVan[4];
            Assert.AreEqual<CanEnum>(CanEnum.Nham, can);
            Assert.AreEqual<ChiEnum>(ChiEnum.Ngo, chi);
            Assert.AreEqual(49, t);
        }

        [TestMethod]
        public void Check_CreateDaiVan_AmNam()
        {
            string canNam = "Dinh", chiNam = "Mao", canThang = "Quy", chiThang = "Suu",
                canNgay = "Tan", chiNgay = "Mui", canGio = "Ky", chiGio = "Hoi",
                gt = "Nam";
            int tuoi = 4;
            Business.TuTruMap mybiz = new Business.TuTruMap();
            mybiz.CreateTuTru(gt, canNam, chiNam, canThang, chiThang, canNgay, chiNgay, canGio, chiGio);
            mybiz.CreateDaiVan(tuoi);
            var can = mybiz.LaSoCuaToi.DaiVan[4].ThienCan.Can;
            var chi = mybiz.LaSoCuaToi.DaiVan[4].DiaChi.Ten;
            var t = mybiz.LaSoCuaToi.TuoiDaiVan[4];
            Assert.AreEqual<CanEnum>(CanEnum.Mau, can);
            Assert.AreEqual<ChiEnum>(ChiEnum.Than, chi);
            Assert.AreEqual(44, t);
        }

        [TestMethod]
        public void Check_CreateCungMenh_AmNam()
        {
            string canNam = "Dinh", chiNam = "Mao", 
                    canThang = "Quy", chiThang = "Suu",
                    canNgay = "Tan", chiNgay = "Mui", 
                    canGio = "Ky", chiGio = "Hoi",
                gt = "Nam";
            int tuoi = 4;
            Business.TuTruMap mybiz = new Business.TuTruMap();
            mybiz.CreateTuTru(gt, canNam, chiNam, canThang, chiThang, canNgay, chiNgay, canGio, chiGio);
            mybiz.CreateDaiVan(tuoi);
            mybiz.CreateCungMenh();
            Assert.AreEqual<CanEnum>(CanEnum.At, mybiz.LaSoCuaToi.TuTru[Constants.CUNG_MENH].ThienCan.Can);
            Assert.AreEqual<ChiEnum>(ChiEnum.Ty, mybiz.LaSoCuaToi.TuTru[Constants.CUNG_MENH].DiaChi.Ten);

        }

        [TestMethod]
        public void Check_CreateThaiNguyen_AmNam()
        {
            string canNam = "Dinh", chiNam = "Mao",
                    canThang = "Quy", chiThang = "Suu",
                    canNgay = "Tan", chiNgay = "Mui",
                    canGio = "Ky", chiGio = "Hoi",
                gt = "Nam";
            int tuoi = 4;
            Business.TuTruMap mybiz = new Business.TuTruMap();
            mybiz.CreateTuTru(gt, canNam, chiNam, canThang, chiThang, canNgay, chiNgay, canGio, chiGio);
            mybiz.CreateDaiVan(tuoi);
            mybiz.CreateThaiNguyen();
            Assert.AreEqual<CanEnum>(CanEnum.Giap, mybiz.LaSoCuaToi.TuTru[Constants.THAI_NGUYEN].ThienCan.Can);
            Assert.AreEqual<ChiEnum>(ChiEnum.Thin, mybiz.LaSoCuaToi.TuTru[Constants.THAI_NGUYEN].DiaChi.Ten);
        }

        [TestMethod]
        public void Check_InitLaSo_AmNam()
        {
            string canNam = "Dinh", chiNam = "Mao",
                    canThang = "Quy", chiThang = "Suu",
                    canNgay = "Tan", chiNgay = "Mui",
                    canGio = "Ky", chiGio = "Hoi",
                gt = "Nam";
            int tuoi = 4;
            Business.TuTruMap mybiz = new Business.TuTruMap();
            mybiz.InitLaSo(gt, canNam, chiNam, canThang, chiThang, canNgay, chiNgay, canGio, chiGio, tuoi);

            var truNam = mybiz.LaSoCuaToi.TuTru[Constants.TRU_NAM];
            var truThang = mybiz.LaSoCuaToi.TuTru[Constants.TRU_THANG];
            var truNgay = mybiz.LaSoCuaToi.TuTru[Constants.TRU_NGAY];
            var truGio = mybiz.LaSoCuaToi.TuTru[Constants.TRU_GIO];
            var cungMenh = mybiz.LaSoCuaToi.TuTru[Constants.CUNG_MENH];
            var thaiNguyen = mybiz.LaSoCuaToi.TuTru[Constants.THAI_NGUYEN];
            var tru44 = mybiz.LaSoCuaToi.DaiVan[4];

            // check Thap Than
            Assert.AreEqual<ThapThanEnum>(ThapThanEnum.ThienQuan, truNam.ThienCan.ThapThan);
            Assert.AreEqual<ThapThanEnum>(ThapThanEnum.ThucThan, truThang.ThienCan.ThapThan);
            Assert.AreEqual<ThapThanEnum>(ThapThanEnum.ThienAn, truGio.ThienCan.ThapThan);
            Assert.AreEqual<ThapThanEnum>(ThapThanEnum.ThienTai, truNgay.DiaChi.TapKhi.ThapThan);

            Assert.AreEqual<ThapThanEnum>(ThapThanEnum.ChinhTai, thaiNguyen.ThienCan.ThapThan);
            Assert.AreEqual<ThapThanEnum>(ThapThanEnum.ChinhQuan, cungMenh.DiaChi.BanKhi.ThapThan);

            // check Nap Am
            Assert.AreEqual<NguHanhEnum>(NguHanhEnum.Hoa, (NguHanhEnum)cungMenh.ThuocTinh[Constants.NAP_AM]);
            Assert.AreEqual<NguHanhEnum>(NguHanhEnum.Moc, (NguHanhEnum)truGio.ThuocTinh[Constants.NAP_AM]);

            // check Vong Truong Sinh
            Assert.AreEqual<GiaiDoanTruongSinhEnum>(GiaiDoanTruongSinhEnum.DeVuong, (GiaiDoanTruongSinhEnum)tru44.ThuocTinh[Constants.VONG_TRUONG_SINH]);

            Assert.AreEqual<GiaiDoanTruongSinhEnum>(GiaiDoanTruongSinhEnum.Mo, (GiaiDoanTruongSinhEnum)thaiNguyen.ThuocTinh[Constants.VONG_TRUONG_SINH]);

            // check Cung Menh Sao
            Assert.AreEqual<string>(Constants.CungMenhSao.THIEN_VAN, (string)cungMenh.ThuocTinh[Constants.CungMenhSao.CUNG_MENH_SAO]);
        }

        #region Dia Chi Luc Hop
        [TestMethod]
        public void Check_LucHopTho1()
        {
            string canNam = "Dinh", chiNam = "Mao",
                    canThang = "Quy", chiThang = "Suu",
                    canNgay = "Tan", chiNgay = "Mui",
                    canGio = "Ky", chiGio = "Hoi",
                gt = "Nam";
            int tuoi = 4, tuoiDV = 4;
            Business.TuTruMap mybiz = new Business.TuTruMap();
            mybiz.InitLaSo(gt, canNam, chiNam, canThang, chiThang, canNgay, chiNgay, canGio, chiGio, tuoi, tuoiDV);

            DiaChiLucHop dclh = new DiaChiLucHop(mybiz);
            dclh.SetLaw();

            var ti = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ti);
            var suu = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Suu);

            Assert.IsTrue(ti.ThuocTinh.Keys.Contains(Constants.ThuocTinh.LUC_HOP_KHAC));
            Assert.IsTrue(((NguHanhEnum)ti.ThuocTinh[Constants.ThuocTinh.LUC_HOP_KHAC]) == NguHanhEnum.Tho);

            Assert.IsTrue(suu.ThuocTinh.Keys.Contains(Constants.ThuocTinh.LUC_HOP_KHAC));
            Assert.IsTrue(((NguHanhEnum)suu.ThuocTinh[Constants.ThuocTinh.LUC_HOP_KHAC]) == NguHanhEnum.Tho);
        }

        [TestMethod]
        public void Check_LucHopTho2()
        {
            string canNam = "Dinh", chiNam = "Mao",
                    canThang = "Quy", chiThang = "Suu",
                    canNgay = "Tan", chiNgay = "Mui",
                    canGio = "Ky", chiGio = "Hoi",
                gt = "Nam";
            int tuoi = 4, tuoiDV = 64;
            Business.TuTruMap mybiz = new Business.TuTruMap();
            mybiz.InitLaSo(gt, canNam, chiNam, canThang, chiThang, canNgay, chiNgay, canGio, chiGio, tuoi, tuoiDV);

            DiaChiLucHop dclh = new DiaChiLucHop(mybiz);
            dclh.SetLaw();

            var ngo = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ngo);
            var mui = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Mui);

            Assert.IsTrue(ngo.ThuocTinh.Keys.Contains(Constants.ThuocTinh.LUC_HOP_SINH));
            Assert.IsTrue(((NguHanhEnum)ngo.ThuocTinh[Constants.ThuocTinh.LUC_HOP_SINH]) == NguHanhEnum.Tho);

            Assert.IsTrue(mui.ThuocTinh.Keys.Contains(Constants.ThuocTinh.LUC_HOP_SINH));
            Assert.IsTrue(((NguHanhEnum)mui.ThuocTinh[Constants.ThuocTinh.LUC_HOP_SINH]) == NguHanhEnum.Tho);
        }

        [TestMethod]
        public void Check_LucHopMoc()
        {
            string canNam = "Dinh", chiNam = "Mao",
                    canThang = "Quy", chiThang = "Suu",
                    canNgay = "Tan", chiNgay = "Mui",
                    canGio = "Ky", chiGio = "Hoi",
                gt = "Nam";
            int tuoi = 4, tuoiDV = 4;
            Business.TuTruMap mybiz = new Business.TuTruMap();
            mybiz.InitLaSo(gt, canNam, chiNam, canThang, chiThang, canNgay, chiNgay, canGio, chiGio, tuoi, tuoiDV);

            DiaChiLucHop dclh = new DiaChiLucHop(mybiz);
            dclh.TatcaTru.Add(LookUpTable.TruOfTheYear(2010));
            dclh.SetLaw();

            var dan = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dan);
            var hoi = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Hoi);

            Assert.IsTrue(dan.ThuocTinh.Keys.Contains(Constants.ThuocTinh.LUC_HOP_SINH));
            Assert.IsTrue(((NguHanhEnum)dan.ThuocTinh[Constants.ThuocTinh.LUC_HOP_SINH]) == NguHanhEnum.Moc);

            Assert.IsTrue(hoi.ThuocTinh.Keys.Contains(Constants.ThuocTinh.LUC_HOP_SINH));
            Assert.IsTrue(((NguHanhEnum)hoi.ThuocTinh[Constants.ThuocTinh.LUC_HOP_SINH]) == NguHanhEnum.Moc);
        }

        [TestMethod]
        public void Check_LucHopHoa()
        {
            string canNam = "Dinh", chiNam = "Mao",
                    canThang = "Quy", chiThang = "Suu",
                    canNgay = "Tan", chiNgay = "Mui",
                    canGio = "Ky", chiGio = "Hoi",
                gt = "Nam";
            int tuoi = 4, tuoiDV = 24;
            Business.TuTruMap mybiz = new Business.TuTruMap();
            mybiz.InitLaSo(gt, canNam, chiNam, canThang, chiThang, canNgay, chiNgay, canGio, chiGio, tuoi, tuoiDV);

            DiaChiLucHop dclh = new DiaChiLucHop(mybiz);
            dclh.SetLaw();

            var mao = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Mao);
            var tuat = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Tuat);

            Assert.IsTrue(mao.ThuocTinh.Keys.Contains(Constants.ThuocTinh.LUC_HOP_KHAC));
            Assert.IsTrue(((NguHanhEnum)mao.ThuocTinh[Constants.ThuocTinh.LUC_HOP_KHAC]) == NguHanhEnum.Hoa);

            Assert.IsTrue(tuat.ThuocTinh.Keys.Contains(Constants.ThuocTinh.LUC_HOP_KHAC));
            Assert.IsTrue(((NguHanhEnum)tuat.ThuocTinh[Constants.ThuocTinh.LUC_HOP_KHAC]) == NguHanhEnum.Hoa);
        }

        [TestMethod]
        public void Check_LucHopKim()
        {
            string canNam = "Dinh", chiNam = "Mao",
                    canThang = "Quy", chiThang = "Suu",
                    canNgay = "Tan", chiNgay = "Mui",
                    canGio = "Ky", chiGio = "Hoi",
                gt = "Nam";
            int tuoi = 4, tuoiDV = 34;
            Business.TuTruMap mybiz = new Business.TuTruMap();
            mybiz.InitLaSo(gt, canNam, chiNam, canThang, chiThang, canNgay, chiNgay, canGio, chiGio, tuoi, tuoiDV);

            DiaChiLucHop dclh = new DiaChiLucHop(mybiz);
            dclh.SetLaw();

            var thin = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Thin);
            var dau = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dau);

            Assert.IsTrue(thin.ThuocTinh.Keys.Contains(Constants.ThuocTinh.LUC_HOP_SINH));
            Assert.IsTrue(((NguHanhEnum)thin.ThuocTinh[Constants.ThuocTinh.LUC_HOP_SINH]) == NguHanhEnum.Kim);

            Assert.IsTrue(dau.ThuocTinh.Keys.Contains(Constants.ThuocTinh.LUC_HOP_SINH));
            Assert.IsTrue(((NguHanhEnum)dau.ThuocTinh[Constants.ThuocTinh.LUC_HOP_SINH]) == NguHanhEnum.Kim);
        }

        [TestMethod]
        public void Check_LucHopThuy()
        {
            string canNam = "Dinh", chiNam = "Mao",
                    canThang = "Quy", chiThang = "Suu",
                    canNgay = "Tan", chiNgay = "Mui",
                    canGio = "Ky", chiGio = "Hoi",
                gt = "Nam";
            int tuoi = 4, tuoiDV = 44;
            Business.TuTruMap mybiz = new Business.TuTruMap();
            mybiz.InitLaSo(gt, canNam, chiNam, canThang, chiThang, canNgay, chiNgay, canGio, chiGio, tuoi, tuoiDV);

            DiaChiLucHop dclh = new DiaChiLucHop(mybiz);
            dclh.SetLaw();

            var ty = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ty);
            var than = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Than);

            Assert.IsTrue(ty.ThuocTinh.Keys.Contains(Constants.ThuocTinh.LUC_HOP_KHAC));
            Assert.IsTrue(((NguHanhEnum)ty.ThuocTinh[Constants.ThuocTinh.LUC_HOP_KHAC]) == NguHanhEnum.Thuy);

            Assert.IsTrue(than.ThuocTinh.Keys.Contains(Constants.ThuocTinh.LUC_HOP_KHAC));
            Assert.IsTrue(((NguHanhEnum)than.ThuocTinh[Constants.ThuocTinh.LUC_HOP_KHAC]) == NguHanhEnum.Thuy);
        }

        #endregion Dia Chi Luc Hop

    }
}
