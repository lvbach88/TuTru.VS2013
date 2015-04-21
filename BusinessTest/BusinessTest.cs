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
            Business.Business mybiz = new Business.Business();
            mybiz.CreateTuTru(gt, canNam, chiNam, canThang, chiThang, canNgay, chiNgay, canGio, chiGio);

            Assert.IsNotNull(mybiz.LaSoCuaToi);
        }

        [TestMethod]
        public void Check_CreateTuTru_Null()
        {
            string canNam = "", chiNam = "Ty", canThang = "Dinh", chiThang = "Suu",
                canNgay = "Nham", chiNgay = "Than", canGio = "At", chiGio = "Ty",
                gt = "Nu";
            Business.Business mybiz = new Business.Business();
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
            Business.Business mybiz = new Business.Business();
            mybiz.CreateTuTru(gt, canNam, chiNam, canThang, chiThang, canNgay, chiNgay, canGio, chiGio);
            mybiz.CreateDaiVan(tuoi);
            var can = mybiz.LaSoCuaToi.DaiVan[4].ThienCan.Can;
            var chi = mybiz.LaSoCuaToi.DaiVan[4].DiaChi.Ten;
            var t = mybiz.LaSoCuaToi.Tuoi[4];
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
            Business.Business mybiz = new Business.Business();
            mybiz.CreateTuTru(gt, canNam, chiNam, canThang, chiThang, canNgay, chiNgay, canGio, chiGio);
            mybiz.CreateDaiVan(tuoi);
            var can = mybiz.LaSoCuaToi.DaiVan[4].ThienCan.Can;
            var chi = mybiz.LaSoCuaToi.DaiVan[4].DiaChi.Ten;
            var t = mybiz.LaSoCuaToi.Tuoi[4];
            Assert.AreEqual<CanEnum>(CanEnum.Mau, can);
            Assert.AreEqual<ChiEnum>(ChiEnum.Than, chi);
            Assert.AreEqual(44, t);
        }
    }
}
