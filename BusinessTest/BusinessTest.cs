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
        public void Check_CreateLaSo_NotNull()
        {
            string canNam = "Ky", chiNam = "Ty", canThang = "Dinh", chiThang = "Suu",
                canNgay = "Nham", chiNgay = "Than", canGio = "At", chiGio = "Ty";
            Business.Business mybiz = new Business.Business();
            mybiz.CreateLaSo(canNam, chiNam, canThang, chiThang, canNgay, chiNgay, canGio, chiGio);

            Assert.IsNotNull(mybiz.LaSoCuaToi);
        }

        [TestMethod]
        public void Check_CreateLaSo_Null()
        {
            string canNam = "", chiNam = "Ty", canThang = "Dinh", chiThang = "Suu",
                canNgay = "Nham", chiNgay = "Than", canGio = "At", chiGio = "Ty";
            Business.Business mybiz = new Business.Business();
            mybiz.CreateLaSo(canNam, chiNam, canThang, chiThang, canNgay, chiNgay, canGio, chiGio);

            Assert.IsNull(mybiz.LaSoCuaToi);
        }
    }
}
