using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Business
{
    public class TuTruMap
    {

        public LaSo LaSoCuaToi { get; set; }
        public Tru DaiVanHienTai { get; private set; }

        public void InitLaSo( string gioiTinh,
                                string canNam, string chiNam,
                                string canThang, string chiThang,
                                string canNgay, string chiNgay,
                                string canGio, string chiGio,
                                int tuoi, int tuoiDV = Int16.MinValue)
        {
            // to call all create/set methods.
            // 1. create tu tru
            // 2. create dai van
            // 3. create tieu van
            // 4. create cung menh
            // 5. create thai nguyen
            CreateTuTru(gioiTinh, canNam, chiNam, canThang, chiThang, canNgay, chiNgay, canGio, chiGio);
            CreateDaiVan(tuoi, tuoiDV);
            CreateTieuVan();
            CreateCungMenh();
            CreateThaiNguyen();

            var truNgay = this.LaSoCuaToi.TuTru[Constants.TRU_NGAY];

            #region Set Thap Than
            int n = TongHopCanChi.MuoiThienCan.Count;
            for (int i = 0; i < n; i++)
            {
                SetThapThan(can: TongHopCanChi.MuoiThienCan[i]);
            }
            #endregion Set Thap Than

            #region Set Nap Am, Vong Truong Sinh
            foreach (var tru in this.LaSoCuaToi.TuTru.Values)
            {
                SetNapAm(tru);
                tru.ThuocTinh.Add(Constants.VONG_TRUONG_SINH, LookUpTable.VongTruongSinh(truNgay.ThienCan.Can, tru.DiaChi.Ten));
            }

            foreach (var tru in this.LaSoCuaToi.DaiVan)
            {
                SetNapAm(tru);
                tru.ThuocTinh.Add(Constants.VONG_TRUONG_SINH, LookUpTable.VongTruongSinh(truNgay.ThienCan.Can, tru.DiaChi.Ten));
            }

            // Tieu Van starts at 1
            for (int i = 1; i < this.LaSoCuaToi.TieuVan.Count; i++)
            {
                var tru = this.LaSoCuaToi.TieuVan[i];
                SetNapAm(tru);
                tru.ThuocTinh.Add(Constants.VONG_TRUONG_SINH, LookUpTable.VongTruongSinh(truNgay.ThienCan.Can, tru.DiaChi.Ten));
            }

            #endregion Set Nap Am, Vong Truong Sinh


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

        public void CreateDaiVan(int age = Int16.MinValue, int daiVanHienTai = Int16.MinValue)
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

            //Tru cua Dai Van hien tai
            if (daiVanHienTai != Int16.MinValue)
            {
                this.DaiVanHienTai = this.LaSoCuaToi.DaiVan[this.LaSoCuaToi.TuoiDaiVan.FindIndex(u => u == daiVanHienTai)];
            }
            else
            {
                this.DaiVanHienTai = this.LaSoCuaToi.DaiVan[0];
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

            var cungMenh = LookUpTable.NguHoDon(this.LaSoCuaToi.TuTru[Constants.TRU_NAM].ThienCan.Can, cungMenhChi.Ten);

            switch (cungMenh.DiaChi.Ten)
            {
                case ChiEnum.None:
                    break;
                case ChiEnum.Ti:
                    cungMenh.ThuocTinh.Add(Constants.CungMenhSao.CUNG_MENH_SAO, Constants.CungMenhSao.THIEN_QUY);
                    break;
                case ChiEnum.Suu:
                    cungMenh.ThuocTinh.Add(Constants.CungMenhSao.CUNG_MENH_SAO, Constants.CungMenhSao.THIEN_ACH);
                    break;
                case ChiEnum.Dan:
                    cungMenh.ThuocTinh.Add(Constants.CungMenhSao.CUNG_MENH_SAO, Constants.CungMenhSao.THIEN_QUYEN);
                    break;
                case ChiEnum.Mao:
                    cungMenh.ThuocTinh.Add(Constants.CungMenhSao.CUNG_MENH_SAO, Constants.CungMenhSao.THIEN_XICH);
                    break;
                case ChiEnum.Thin:
                    cungMenh.ThuocTinh.Add(Constants.CungMenhSao.CUNG_MENH_SAO, Constants.CungMenhSao.THIEN_NHU);
                    break;
                case ChiEnum.Ty:
                    cungMenh.ThuocTinh.Add(Constants.CungMenhSao.CUNG_MENH_SAO, Constants.CungMenhSao.THIEN_VAN);
                    break;
                case ChiEnum.Ngo:
                    cungMenh.ThuocTinh.Add(Constants.CungMenhSao.CUNG_MENH_SAO, Constants.CungMenhSao.THIEN_PHUC);
                    break;
                case ChiEnum.Mui:
                    cungMenh.ThuocTinh.Add(Constants.CungMenhSao.CUNG_MENH_SAO, Constants.CungMenhSao.THIEN_LAO);
                    break;
                case ChiEnum.Than:
                    cungMenh.ThuocTinh.Add(Constants.CungMenhSao.CUNG_MENH_SAO, Constants.CungMenhSao.THIEN_QUA);
                    break;
                case ChiEnum.Dau:
                    cungMenh.ThuocTinh.Add(Constants.CungMenhSao.CUNG_MENH_SAO, Constants.CungMenhSao.THIEN_BI);
                    break;
                case ChiEnum.Tuat:
                    cungMenh.ThuocTinh.Add(Constants.CungMenhSao.CUNG_MENH_SAO, Constants.CungMenhSao.THIEN_NGHE);
                    break;
                case ChiEnum.Hoi:
                    cungMenh.ThuocTinh.Add(Constants.CungMenhSao.CUNG_MENH_SAO, Constants.CungMenhSao.THIEN_THO);
                    break;
                default:
                    break;
            }

            this.LaSoCuaToi.TuTru.Add(Constants.CUNG_MENH, cungMenh);
        }

        public void CreateThaiNguyen()
        {
            int canThangIndex = TongHopCanChi.MuoiThienCan.FindIndex(u => u.Can == this.LaSoCuaToi.TuTru[Constants.TRU_THANG].ThienCan.Can);
            int chiThangIndex = TongHopCanChi.MuoiHaiDiaChi.FindIndex(u => u.Ten == this.LaSoCuaToi.TuTru[Constants.TRU_THANG].DiaChi.Ten);

            int nCan = TongHopCanChi.MuoiThienCan.Count;
            int nChi = TongHopCanChi.MuoiHaiDiaChi.Count;

            int thaiNguyenCanIndex = (canThangIndex + Constants.THAI_NGUYEN_CAN_SHIFT + nCan) % nCan;
            int thaiNguyenChiIndex = (chiThangIndex + Constants.THAI_NGUYEN_CHI_SHIFT + nChi) % nChi;

            var thaiNguyen = new Tru(TongHopCanChi.MuoiThienCan[thaiNguyenCanIndex], TongHopCanChi.MuoiHaiDiaChi[thaiNguyenChiIndex]);
            this.LaSoCuaToi.TuTru.Add(Constants.THAI_NGUYEN, thaiNguyen);
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

        public void SetNapAm(Tru tru)
        {
            NguHanhEnum nguHanh;
            LookUpTable.NapAm.TryGetValue(new Tuple<CanEnum, ChiEnum>(tru.ThienCan.Can, tru.DiaChi.Ten), out nguHanh);
            tru.ThuocTinh.Add(Constants.NAP_AM, nguHanh);
        }


    }
}
