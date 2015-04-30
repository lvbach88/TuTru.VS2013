using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Business
{
    public class Business
    {

        public LaSo LaSoCuaToi { get; set; }

        public void InitLaSo()
        {
            // to call all create/set methods.


            //set thap than
            int n = TongHopCanChi.MuoiThienCan.Count;
            for (int i = 0; i < n; i++)
            {
                SetThapThan(can: TongHopCanChi.MuoiThienCan[i]);
            }
        }
        
        public void CreateTuTru( string gioiTinh,
                                string canNam, string chiNam,
                                string canThang, string chiThang,
                                string canNgay, string chiNgay,
                                string canGio, string chiGio)
        {
            CanEnum e_canNam, e_canThang, e_canNgay, e_canGio;
            ChiEnum e_chiNam, e_chiThang, e_chiNgay, e_chiGio;
            GioiTinhEnum e_gt;

            bool cvtGt = Enum.TryParse<GioiTinhEnum>(gioiTinh, true, out e_gt);
            cvtGt &= Enum.IsDefined(typeof(GioiTinhEnum), e_gt);

            bool cvtCanNam = Enum.TryParse<CanEnum>(canNam, true, out e_canNam);
            cvtCanNam &= Enum.IsDefined(typeof(CanEnum), e_canNam);

            bool cvtCanThang = Enum.TryParse<CanEnum>(canThang, true, out e_canThang);
            cvtCanThang &= Enum.IsDefined(typeof(CanEnum), e_canThang);

            bool cvtCanNgay= Enum.TryParse<CanEnum>(canNgay, true, out e_canNgay);
            cvtCanNgay &= Enum.IsDefined(typeof(CanEnum), e_canNgay);

            bool cvtCanGio = Enum.TryParse<CanEnum>(canGio, true, out e_canGio);
            cvtCanGio &= Enum.IsDefined(typeof(CanEnum), e_canGio);


            bool cvtChiNam = Enum.TryParse<ChiEnum>(chiNam, true, out e_chiNam);
            cvtChiNam &= Enum.IsDefined(typeof(ChiEnum), e_chiNam);

            bool cvtChiThang = Enum.TryParse<ChiEnum>(chiThang, true, out e_chiThang);
            cvtChiThang &= Enum.IsDefined(typeof(ChiEnum), e_chiThang);

            bool cvtChiNgay = Enum.TryParse<ChiEnum>(chiNgay, true, out e_chiNgay);
            cvtChiNgay &= Enum.IsDefined(typeof(ChiEnum), e_chiNgay);

            bool cvtChiGio = Enum.TryParse<ChiEnum>(chiGio, true, out e_chiGio);
            cvtChiGio &= Enum.IsDefined(typeof(ChiEnum), e_chiGio);

            if (!(cvtCanNam && cvtCanThang && cvtCanNgay && cvtCanGio
                && cvtChiNam && cvtChiThang && cvtChiNgay && cvtChiGio
                && cvtGt))
            {
                this.LaSoCuaToi = null;
            }
            else
            {
                this.LaSoCuaToi = new LaSo();
                Tru truNam = new Tru(TongHopCanChi.MuoiThienCan.Single<ThienCan>(u => u.Can == e_canNam),
                                        TongHopCanChi.MuoiHaiDiaChi.Single<DiaChi>(u => u.Ten == e_chiNam));
                Tru truThang = new Tru(TongHopCanChi.MuoiThienCan.Single<ThienCan>(u => u.Can == e_canThang),
                                        TongHopCanChi.MuoiHaiDiaChi.Single<DiaChi>(u => u.Ten == e_chiThang));
                Tru truNgay = new Tru(TongHopCanChi.MuoiThienCan.Single<ThienCan>(u => u.Can == e_canNgay),
                                        TongHopCanChi.MuoiHaiDiaChi.Single<DiaChi>(u => u.Ten == e_chiNgay));
                Tru truGio = new Tru(TongHopCanChi.MuoiThienCan.Single<ThienCan>(u => u.Can == e_canGio),
                                        TongHopCanChi.MuoiHaiDiaChi.Single<DiaChi>(u => u.Ten == e_chiGio));
                
                this.LaSoCuaToi.TuTru.Add(Constants.TRU_NAM, truNam);
                this.LaSoCuaToi.TuTru.Add(Constants.TRU_THANG, truThang);
                this.LaSoCuaToi.TuTru.Add(Constants.TRU_NGAY, truNgay);
                this.LaSoCuaToi.TuTru.Add(Constants.TRU_GIO, truGio);

                this.LaSoCuaToi.GioiTinh = e_gt;

            }

            
        }

        public void CreateDaiVan(int age = Int16.MinValue)
        {
            
            int direction = 1;

            if ((this.LaSoCuaToi.GioiTinh == GioiTinhEnum.Nam && this.LaSoCuaToi.TuTru[Constants.TRU_NAM].ThienCan.AmDuong == AmDuongEnum.Duong)
                || (this.LaSoCuaToi.GioiTinh == GioiTinhEnum.Nu && this.LaSoCuaToi.TuTru[Constants.TRU_NAM].ThienCan.AmDuong == AmDuongEnum.Am))
            {
                direction = 1;
            }
            else if ((this.LaSoCuaToi.GioiTinh == GioiTinhEnum.Nam && this.LaSoCuaToi.TuTru[Constants.TRU_NAM].ThienCan.AmDuong == AmDuongEnum.Am)
                || (this.LaSoCuaToi.GioiTinh == GioiTinhEnum.Nu && this.LaSoCuaToi.TuTru[Constants.TRU_NAM].ThienCan.AmDuong == AmDuongEnum.Duong))
            {
                direction = -1;
            }

            var canThang = this.LaSoCuaToi.TuTru[Constants.TRU_THANG].ThienCan.Can;
            var chiThang = this.LaSoCuaToi.TuTru[Constants.TRU_THANG].DiaChi.Ten;

            int canIndex = TongHopCanChi.MuoiThienCan.FindIndex(u => u.Can == canThang);
            int chiIndex = TongHopCanChi.MuoiHaiDiaChi.FindIndex(u => u.Ten == chiThang);

            int nCan = TongHopCanChi.MuoiThienCan.Count;
            int nChi = TongHopCanChi.MuoiHaiDiaChi.Count;

            for (int i = 0; i < Constants.SO_DAI_VAN; i++)
            {
                canIndex = (canIndex + nCan + direction) % nCan;
                chiIndex = (chiIndex + nChi + direction) % nChi;
                this.LaSoCuaToi.DaiVan.Add(new Tru(TongHopCanChi.MuoiThienCan[canIndex], TongHopCanChi.MuoiHaiDiaChi[chiIndex]));
            }

            //populate ages
            if (age != Int16.MinValue)
            {
                for (int i = 0; i < Constants.SO_DAI_VAN; i++)
                {
                    this.LaSoCuaToi.TuoiDaiVan.Add(age);
                    age += Constants.NAM_DAI_VAN;
                }
            }

        }

        public void CreateTieuVan()
        {

            int direction = 1;

            if ((this.LaSoCuaToi.GioiTinh == GioiTinhEnum.Nam && this.LaSoCuaToi.TuTru[Constants.TRU_NAM].ThienCan.AmDuong == AmDuongEnum.Duong)
                || (this.LaSoCuaToi.GioiTinh == GioiTinhEnum.Nu && this.LaSoCuaToi.TuTru[Constants.TRU_NAM].ThienCan.AmDuong == AmDuongEnum.Am))
            {
                direction = 1;
            }
            else if ((this.LaSoCuaToi.GioiTinh == GioiTinhEnum.Nam && this.LaSoCuaToi.TuTru[Constants.TRU_NAM].ThienCan.AmDuong == AmDuongEnum.Am)
                || (this.LaSoCuaToi.GioiTinh == GioiTinhEnum.Nu && this.LaSoCuaToi.TuTru[Constants.TRU_NAM].ThienCan.AmDuong == AmDuongEnum.Duong))
            {
                direction = -1;
            }

            var canGio = this.LaSoCuaToi.TuTru[Constants.TRU_GIO].ThienCan.Can;
            var chiGio = this.LaSoCuaToi.TuTru[Constants.TRU_GIO].DiaChi.Ten;

            int canIndex = TongHopCanChi.MuoiThienCan.FindIndex(u => u.Can == canGio);
            int chiIndex = TongHopCanChi.MuoiHaiDiaChi.FindIndex(u => u.Ten == chiGio);

            int nCan = TongHopCanChi.MuoiThienCan.Count;
            int nChi = TongHopCanChi.MuoiHaiDiaChi.Count;

            // make sure TieuVan starts from 1 year-old.
            // index of the TieuVan list (from 1 onward) is the age of TieuVan.
            this.LaSoCuaToi.TieuVan.Add(null); 
            for (int i = 0; i < Constants.SO_DAI_VAN; i++)
            {
                canIndex = (canIndex + nCan + direction) % nCan;
                chiIndex = (chiIndex + nChi + direction) % nChi;
                this.LaSoCuaToi.TieuVan.Add(new Tru(TongHopCanChi.MuoiThienCan[canIndex], TongHopCanChi.MuoiHaiDiaChi[chiIndex]));
            }


        }

        public void CreateCungMenh()
        {
            int thangIndex = TongHopCanChi.MuoiHaiDiaChi.FindIndex(u => u.Ten == this.LaSoCuaToi.TuTru[Constants.TRU_THANG].DiaChi.Ten);
            int gioIndex = TongHopCanChi.MuoiHaiDiaChi.FindIndex(u => u.Ten == this.LaSoCuaToi.TuTru[Constants.TRU_GIO].DiaChi.Ten);
            thangIndex += Constants.CUNG_MENH_SHIFT;
            gioIndex += Constants.CUNG_MENH_SHIFT;
            
            int n = TongHopCanChi.MuoiHaiDiaChi.Count;
            int soThang = thangIndex > 0 ? thangIndex : thangIndex + n;
            int soGio = gioIndex > 0 ? gioIndex : gioIndex + n;

            int sum = soThang + soGio;
            int soCungMenh;

            if (sum < Constants.CUNG_MENH_LOWER_BOUND)
            {
                soCungMenh = Constants.CUNG_MENH_LOWER_BOUND - sum;
            }
            else
            {
                soCungMenh = Constants.CUNG_MENH_UPPER_BOUND - sum;
            }

            int cungMenhIndex = (soCungMenh - Constants.CUNG_MENH_SHIFT + n) % n;
            var cungMenhChi = TongHopCanChi.MuoiHaiDiaChi[cungMenhIndex];

            this.LaSoCuaToi.CungMenh = LookUpTable.NguHoDon(this.LaSoCuaToi.TuTru[Constants.TRU_NAM].ThienCan.Can, cungMenhChi.Ten);
        }

        public void CreateThaiNguyen()
        {
            int canThangIndex = TongHopCanChi.MuoiThienCan.FindIndex(u => u.Can == this.LaSoCuaToi.TuTru[Constants.TRU_THANG].ThienCan.Can);
            int chiThangIndex = TongHopCanChi.MuoiHaiDiaChi.FindIndex(u => u.Ten == this.LaSoCuaToi.TuTru[Constants.TRU_THANG].DiaChi.Ten);

            int nCan = TongHopCanChi.MuoiThienCan.Count;
            int nChi = TongHopCanChi.MuoiHaiDiaChi.Count;

            int thaiNguyenCanIndex = (canThangIndex + Constants.THAI_NGUYEN_CAN_SHIFT + nCan) % nCan;
            int thaiNguyenChiIndex = (chiThangIndex + Constants.THAI_NGUYEN_CHI_SHIFT + nChi) % nChi;

            this.LaSoCuaToi.ThaiNguyen = new Tru(TongHopCanChi.MuoiThienCan[thaiNguyenCanIndex], TongHopCanChi.MuoiHaiDiaChi[thaiNguyenChiIndex]);
        }

        /// <summary>
        /// Set Thap Than based on "can ngay"
        /// </summary>
        /// <param name="canNgay">to be based on</param>
        /// <param name="can">to set Thap Than property</param>
        public void SetThapThan(ThienCan canNgay = null, ThienCan can = null)
        {
            if (canNgay == null)
            {
                canNgay = this.LaSoCuaToi.TuTru[Constants.TRU_NGAY].ThienCan;
            }

            var sinhKhac = LookUpTable.NguHanhSinhKhac[canNgay.NguHanh];
            var nhSinh = sinhKhac.Item1;
            var nhDuocSinh = sinhKhac.Item2;
            var nhKhac = sinhKhac.Item3;
            var nhBiKhac = sinhKhac.Item4;

            if (can.NguHanh == nhSinh)
            {
                if (canNgay.AmDuong == can.AmDuong)
                {
                    can.ThapThan = ThapThanEnum.ThucThan;
                }
                else
                {
                    can.ThapThan = ThapThanEnum.ThuongQuan;
                }
            }
            else if (can.NguHanh == nhDuocSinh)
            {
                if (canNgay.AmDuong == can.AmDuong)
                {
                    can.ThapThan = ThapThanEnum.ThienAn;
                }
                else
                {
                    can.ThapThan = ThapThanEnum.ChinhAn;
                }
            }
            else if (can.NguHanh == nhKhac)
            {
                if (canNgay.AmDuong == can.AmDuong)
                {
                    can.ThapThan = ThapThanEnum.ThienTai;
                }
                else
                {
                    can.ThapThan = ThapThanEnum.ChinhTai;
                }
            }
            else if (can.NguHanh == nhBiKhac)
            {
                if (canNgay.AmDuong == can.AmDuong)
                {
                    can.ThapThan = ThapThanEnum.ThienQuan;
                }
                else
                {
                    can.ThapThan = ThapThanEnum.ChinhQuan;
                }
            }
            else //same Ngu Hanh
            {
                if (canNgay.AmDuong == can.AmDuong)
                {
                    can.ThapThan = ThapThanEnum.TyKien;
                }
                else
                {
                    can.ThapThan = ThapThanEnum.KiepTai;
                }
            }
        }

        


    }
}
