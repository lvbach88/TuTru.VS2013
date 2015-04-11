using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using Business;

namespace BusinessTest
{
    [TestClass]
    public class LookUpTableTest
    {
        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            TongHopCanChi.Init();
            LookUpTable.Init();
        }

        #region Nap Am
        
        [TestMethod]
        public void Check_NapAm_DinhMao()
        {
            NguHanhEnum nguHanh;

            LookUpTable.NapAm.TryGetValue(new Tuple<CanEnum, ChiEnum>(CanEnum.Dinh, ChiEnum.Mao), out nguHanh);

            Assert.AreEqual<NguHanhEnum>(NguHanhEnum.Hoa, nguHanh);
        }

        [TestMethod]
        public void Check_NapAm_QuySuu()
        {
            NguHanhEnum nguHanh;

            LookUpTable.NapAm.TryGetValue(new Tuple<CanEnum, ChiEnum>(CanEnum.Quy, ChiEnum.Suu), out nguHanh);

            Assert.AreEqual<NguHanhEnum>(NguHanhEnum.Moc, nguHanh);
        }

        [TestMethod]
        public void Check_NapAm_TanMui()
        {
            NguHanhEnum nguHanh;

            LookUpTable.NapAm.TryGetValue(new Tuple<CanEnum, ChiEnum>(CanEnum.Tan, ChiEnum.Mui), out nguHanh);

            Assert.AreEqual<NguHanhEnum>(NguHanhEnum.Tho, nguHanh);
        }

        [TestMethod]
        public void Check_NapAm_KyHoi()
        {
            NguHanhEnum nguHanh;

            LookUpTable.NapAm.TryGetValue(new Tuple<CanEnum, ChiEnum>(CanEnum.Ky, ChiEnum.Hoi), out nguHanh);

            Assert.AreEqual<NguHanhEnum>(NguHanhEnum.Moc, nguHanh);
        }
        #endregion Nap Am

        #region Vong Truong Sinh
        [TestMethod]
        public void Check_VongTruongSinh_Giap_Ty()
        {
            GiaiDoanTruongSinhEnum ts = LookUpTable.VongTruongSinh(CanEnum.Giap, ChiEnum.Ty);

            Assert.AreEqual<GiaiDoanTruongSinhEnum>(GiaiDoanTruongSinhEnum.Benh, ts);
        }

        [TestMethod]
        public void Check_VongTruongSinh_Dinh_Suu()
        {
            GiaiDoanTruongSinhEnum ts = LookUpTable.VongTruongSinh(CanEnum.Dinh, ChiEnum.Suu);

            Assert.AreEqual<GiaiDoanTruongSinhEnum>(GiaiDoanTruongSinhEnum.Mo, ts);
        }

        [TestMethod]
        public void Check_VongTruongSinh_Canh_Mui()
        {
            GiaiDoanTruongSinhEnum ts = LookUpTable.VongTruongSinh(CanEnum.Canh, ChiEnum.Mui);

            Assert.AreEqual<GiaiDoanTruongSinhEnum>(GiaiDoanTruongSinhEnum.QuanDoi, ts);
        }

        [TestMethod]
        public void Check_VongTruongSinh_Nham_Ti()
        {
            GiaiDoanTruongSinhEnum ts = LookUpTable.VongTruongSinh(CanEnum.Nham, ChiEnum.Ti);

            Assert.AreEqual<GiaiDoanTruongSinhEnum>(GiaiDoanTruongSinhEnum.DeVuong, ts);
        }
        #endregion Vong Truong Sinh

        #region Ngu Ho Don
        [TestMethod]
        public void Check_NguHoDon_Giap_Mao()
        {
            Tru tru = LookUpTable.NguHoDon(CanEnum.Giap, ChiEnum.Mao);

            Assert.AreEqual<CanEnum>(CanEnum.Dinh, tru.ThienCan.Can);
            Assert.AreEqual<ChiEnum>(ChiEnum.Mao, tru.DiaChi.Ten);
        }

        [TestMethod]
        public void Check_NguHoDon_At_Than()
        {
            Tru tru = LookUpTable.NguHoDon(CanEnum.At, ChiEnum.Than);

            Assert.AreEqual<CanEnum>(CanEnum.Giap, tru.ThienCan.Can);
            Assert.AreEqual<ChiEnum>(ChiEnum.Than, tru.DiaChi.Ten);
        }

        [TestMethod]
        public void Check_NguHoDon_Binh_Suu()
        {
            Tru tru = LookUpTable.NguHoDon(CanEnum.Binh, ChiEnum.Suu);

            Assert.AreEqual<CanEnum>(CanEnum.Tan, tru.ThienCan.Can);
            Assert.AreEqual<ChiEnum>(ChiEnum.Suu, tru.DiaChi.Ten);
        }

        [TestMethod]
        public void Check_NguHoDon_Dinh_Dan()
        {
            Tru tru = LookUpTable.NguHoDon(CanEnum.Dinh, ChiEnum.Dan);

            Assert.AreEqual<CanEnum>(CanEnum.Nham, tru.ThienCan.Can);
            Assert.AreEqual<ChiEnum>(ChiEnum.Dan, tru.DiaChi.Ten);
        }

        [TestMethod]
        public void Check_NguHoDon_Mau_Hoi()
        {
            Tru tru = LookUpTable.NguHoDon(CanEnum.Mau, ChiEnum.Hoi);

            Assert.AreEqual<CanEnum>(CanEnum.Quy, tru.ThienCan.Can);
            Assert.AreEqual<ChiEnum>(ChiEnum.Hoi, tru.DiaChi.Ten);
        }
        #endregion Ngu Ho Don

        #region Ngu Thu Don
        [TestMethod]
        public void Check_NguThuDon_Giap_Mao()
        {
            Tru tru = LookUpTable.NguThuDon(CanEnum.Giap, ChiEnum.Mao);

            Assert.AreEqual<CanEnum>(CanEnum.Dinh, tru.ThienCan.Can);
            Assert.AreEqual<ChiEnum>(ChiEnum.Mao, tru.DiaChi.Ten);
        }

        [TestMethod]
        public void Check_NguThuDon_At_Than()
        {
            Tru tru = LookUpTable.NguThuDon(CanEnum.At, ChiEnum.Than);

            Assert.AreEqual<CanEnum>(CanEnum.Giap, tru.ThienCan.Can);
            Assert.AreEqual<ChiEnum>(ChiEnum.Than, tru.DiaChi.Ten);
        }

        [TestMethod]
        public void Check_NguThuDon_Binh_Suu()
        {
            Tru tru = LookUpTable.NguThuDon(CanEnum.Binh, ChiEnum.Suu);

            Assert.AreEqual<CanEnum>(CanEnum.Ky, tru.ThienCan.Can);
            Assert.AreEqual<ChiEnum>(ChiEnum.Suu, tru.DiaChi.Ten);
        }

        [TestMethod]
        public void Check_NguThuDon_Dinh_Dan()
        {
            Tru tru = LookUpTable.NguThuDon(CanEnum.Dinh, ChiEnum.Dan);

            Assert.AreEqual<CanEnum>(CanEnum.Nham, tru.ThienCan.Can);
            Assert.AreEqual<ChiEnum>(ChiEnum.Dan, tru.DiaChi.Ten);
        }

        [TestMethod]
        public void Check_NguThuDon_Mau_Hoi()
        {
            Tru tru = LookUpTable.NguThuDon(CanEnum.Mau, ChiEnum.Hoi);

            Assert.AreEqual<CanEnum>(CanEnum.Quy, tru.ThienCan.Can);
            Assert.AreEqual<ChiEnum>(ChiEnum.Hoi, tru.DiaChi.Ten);
        }
        #endregion Ngu Thu Don
    }
}
