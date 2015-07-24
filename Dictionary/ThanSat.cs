using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ThanSat
    {
        public TuTruMap TTM { get; private set; }

        public ThanSat(TuTruMap ttm)
        {
            this.TTM = ttm;
        }

        private void SetThanSatTru(CanEnum can, ChiEnum chi, string thansat)
        {
            TruCollection law = new TruCollection(this.TTM);

            foreach (var item in law.TatcaTru)
            {
                if (item.ThienCan.Can == can && item.DiaChi.Ten == chi)
                {
                    item.AddThanSat(thansat);
                }
            }
        }

        private void ThienAtQuyNhan()
        {
            var namNgay = new List<CanEnum> {TTM.LaSoCuaToi.TuTru[Constants.TRU_NAM].ThienCan.Can,
                TTM.LaSoCuaToi.TuTru[Constants.TRU_NGAY].ThienCan.Can};

            if (namNgay.Contains(CanEnum.Giap) || namNgay.Contains(CanEnum.Mau))
            {
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Mui).AddThanSat(Constants.ThanSat.THIEN_AT_QUY_NHAN);
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Suu).AddThanSat(Constants.ThanSat.THIEN_AT_QUY_NHAN);
            }
            
            if (namNgay.Contains(CanEnum.At) || namNgay.Contains(CanEnum.Ky))
            {
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Than).AddThanSat(Constants.ThanSat.THIEN_AT_QUY_NHAN);
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ti).AddThanSat(Constants.ThanSat.THIEN_AT_QUY_NHAN);
            }

            if (namNgay.Contains(CanEnum.Binh) || namNgay.Contains(CanEnum.Dinh))
            {
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dau).AddThanSat(Constants.ThanSat.THIEN_AT_QUY_NHAN);
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Hoi).AddThanSat(Constants.ThanSat.THIEN_AT_QUY_NHAN);
            }

            if (namNgay.Contains(CanEnum.Canh) || namNgay.Contains(CanEnum.Tan))
            {
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dan).AddThanSat(Constants.ThanSat.THIEN_AT_QUY_NHAN);
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ngo).AddThanSat(Constants.ThanSat.THIEN_AT_QUY_NHAN);
            }

            if (namNgay.Contains(CanEnum.Nham) || namNgay.Contains(CanEnum.Quy))
            {
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Mao).AddThanSat(Constants.ThanSat.THIEN_AT_QUY_NHAN);
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ty).AddThanSat(Constants.ThanSat.THIEN_AT_QUY_NHAN);
            }

        }

        private void ThienNguyetDucQuyNhan()
        {
            var thang = this.TTM.LaSoCuaToi.TuTru[Constants.TRU_THANG].DiaChi.Ten;

            switch (thang)
            {
                case ChiEnum.None:
                    break;
                case ChiEnum.Ti:
                    
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ty).AddThanSat(Constants.ThanSat.THIEN_DUC);
                    
                    TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Nham).AddThanSat(Constants.ThanSat.NGUYET_DUC);
                    break;
                case ChiEnum.Suu:
                    TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Canh).AddThanSat(Constants.ThanSat.THIEN_DUC);
                  
                    TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Canh).AddThanSat(Constants.ThanSat.NGUYET_DUC);
                    
                    break;
                case ChiEnum.Dan:

                    TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Dinh).AddThanSat(Constants.ThanSat.THIEN_DUC);
                    
                    TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Binh).AddThanSat(Constants.ThanSat.NGUYET_DUC);
                    
                    break;
                case ChiEnum.Mao:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Than).AddThanSat(Constants.ThanSat.THIEN_DUC);

                    TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Giap).AddThanSat(Constants.ThanSat.NGUYET_DUC);

                    break;
                case ChiEnum.Thin:
                    TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Nham).AddThanSat(Constants.ThanSat.THIEN_DUC);

                    TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Nham).AddThanSat(Constants.ThanSat.NGUYET_DUC);

                    break;
                case ChiEnum.Ty:
                    TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Tan).AddThanSat(Constants.ThanSat.THIEN_DUC);

                    TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Canh).AddThanSat(Constants.ThanSat.NGUYET_DUC);

                    break;
                case ChiEnum.Ngo:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Hoi).AddThanSat(Constants.ThanSat.THIEN_DUC);

                    TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Binh).AddThanSat(Constants.ThanSat.NGUYET_DUC);

                    break;
                case ChiEnum.Mui:
                    TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Giap).AddThanSat(Constants.ThanSat.THIEN_DUC);

                    TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Giap).AddThanSat(Constants.ThanSat.NGUYET_DUC);
                    
                    break;
                case ChiEnum.Than:
                    TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Quy).AddThanSat(Constants.ThanSat.THIEN_DUC);

                    TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Nham).AddThanSat(Constants.ThanSat.NGUYET_DUC);
                    
                    break;
                case ChiEnum.Dau:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dan).AddThanSat(Constants.ThanSat.THIEN_DUC);

                    TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Canh).AddThanSat(Constants.ThanSat.NGUYET_DUC);
                    
                    break;
                case ChiEnum.Tuat:
                    TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Binh).AddThanSat(Constants.ThanSat.THIEN_DUC);

                    TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Binh).AddThanSat(Constants.ThanSat.NGUYET_DUC);

                    break;
                case ChiEnum.Hoi:
                    TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.At).AddThanSat(Constants.ThanSat.THIEN_DUC);

                    TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Giap).AddThanSat(Constants.ThanSat.NGUYET_DUC);
                    
                    break;
                default:
                    break;
            }
        }

        private void KhoiCanhQuyNhan()
        {
            var truNgay = this.TTM.LaSoCuaToi.TuTru[Constants.TRU_NGAY];

            if (LookUpTable.IsTruMatched(truNgay, CanEnum.Nham, ChiEnum.Thin)
                || LookUpTable.IsTruMatched(truNgay, CanEnum.Canh, ChiEnum.Thin)
                || LookUpTable.IsTruMatched(truNgay, CanEnum.Mau, ChiEnum.Tuat)
                || LookUpTable.IsTruMatched(truNgay, CanEnum.Canh, ChiEnum.Tuat))
            {
                truNgay.AddThanSat(Constants.ThanSat.KHOI_CANH_QUY_NHAN);
            }
        }

        private void LocThan()
        {
            var canNgay = this.TTM.LaSoCuaToi.TuTru[Constants.TRU_NGAY].ThienCan.Can;

            switch (canNgay)
            {
                case CanEnum.None:
                    break;
                case CanEnum.Giap:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dan).AddThanSat(Constants.ThanSat.LOC_THAN);
                    break;
                case CanEnum.At:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Mao).AddThanSat(Constants.ThanSat.LOC_THAN);
                    break;
                case CanEnum.Binh:
                case CanEnum.Mau:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ty).AddThanSat(Constants.ThanSat.LOC_THAN);
                    break;
                case CanEnum.Dinh:
                case CanEnum.Ky:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ngo).AddThanSat(Constants.ThanSat.LOC_THAN);
                    break;
                case CanEnum.Canh:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Than).AddThanSat(Constants.ThanSat.LOC_THAN);
                    break;
                case CanEnum.Tan:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dau).AddThanSat(Constants.ThanSat.LOC_THAN);
                    break;
                case CanEnum.Nham:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Hoi).AddThanSat(Constants.ThanSat.LOC_THAN);
                    break;
                case CanEnum.Quy:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ti).AddThanSat(Constants.ThanSat.LOC_THAN);
                    break;
                default:
                    break;
            }
        }

        private void KinhDuong()
        {
            var canNgay = this.TTM.LaSoCuaToi.TuTru[Constants.TRU_NGAY].ThienCan.Can;
            switch (canNgay)
            {
                case CanEnum.None:
                    break;
                case CanEnum.Giap:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Mao).AddThanSat(Constants.ThanSat.LOC_THAN);
                    break;
                case CanEnum.At:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dan).AddThanSat(Constants.ThanSat.LOC_THAN);
                    break;
                case CanEnum.Binh:
                case CanEnum.Mau:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ngo).AddThanSat(Constants.ThanSat.LOC_THAN);
                    break;
                case CanEnum.Dinh:
                case CanEnum.Ky:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ty).AddThanSat(Constants.ThanSat.LOC_THAN);
                    break;
                case CanEnum.Canh:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dau).AddThanSat(Constants.ThanSat.LOC_THAN);
                    break;
                case CanEnum.Tan:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Than).AddThanSat(Constants.ThanSat.LOC_THAN);
                    break;
                case CanEnum.Nham:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ti).AddThanSat(Constants.ThanSat.LOC_THAN);
                    break;
                case CanEnum.Quy:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Hoi).AddThanSat(Constants.ThanSat.LOC_THAN);
                    break;
                default:
                    break;
            }
        }

        private void KimDu()
        {
            var canNgay = this.TTM.LaSoCuaToi.TuTru[Constants.TRU_NGAY].ThienCan.Can;

            DiaChi dc = null;
            switch (canNgay)
            {
                case CanEnum.None:
                    break;
                case CanEnum.Giap:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Thin);
                    break;
                case CanEnum.At:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ty);
                    break;
                case CanEnum.Binh:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Mui);
                    break;
                case CanEnum.Dinh:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Than);
                    break;
                case CanEnum.Mau:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Mui);
                    break;
                case CanEnum.Ky:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Than);
                    break;
                case CanEnum.Canh:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Tuat);
                    break;
                case CanEnum.Tan:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Hoi);
                    break;
                case CanEnum.Nham:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Suu);
                    break;
                case CanEnum.Quy: 
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dan);
                    break;
                default:
                    break;
            }
            if (dc != null)
            {
                dc.AddThanSat(Constants.ThanSat.KIM_DU);
            }
        }

        private void VanXuong()
        {
            List<CanEnum> ngayNam = new List<CanEnum> { 
                this.TTM.LaSoCuaToi.TuTru[Constants.TRU_NGAY].ThienCan.Can,
                this.TTM.LaSoCuaToi.TuTru[Constants.TRU_NAM].ThienCan.Can
            };

            DiaChi dc = null;
            if (ngayNam.Contains(CanEnum.Giap))
            {
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ty).AddThanSat(Constants.ThanSat.VAN_XUONG);
            }
            if (ngayNam.Contains(CanEnum.At))
            {
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ngo).AddThanSat(Constants.ThanSat.VAN_XUONG);
            }
            if (ngayNam.Contains(CanEnum.Binh))
            {
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Than).AddThanSat(Constants.ThanSat.VAN_XUONG);
            }
            if (ngayNam.Contains(CanEnum.Dinh))
            {
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dau).AddThanSat(Constants.ThanSat.VAN_XUONG);
            }
            if (ngayNam.Contains(CanEnum.Mau))
            {
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Than).AddThanSat(Constants.ThanSat.VAN_XUONG);
            }
            if (ngayNam.Contains(CanEnum.Ky))
            {
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dau).AddThanSat(Constants.ThanSat.VAN_XUONG);
            }
            if (ngayNam.Contains(CanEnum.Canh))
            {
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Hoi).AddThanSat(Constants.ThanSat.VAN_XUONG);
            }
            if (ngayNam.Contains(CanEnum.Tan))
            {
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ti).AddThanSat(Constants.ThanSat.VAN_XUONG);
            }
            if (ngayNam.Contains(CanEnum.Nham))
            {
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dan).AddThanSat(Constants.ThanSat.VAN_XUONG);
            }
            if (ngayNam.Contains(CanEnum.Quy))
            {
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Mao).AddThanSat(Constants.ThanSat.VAN_XUONG);
            }
            
        }

        private void ThienY()
        {
            var chiThang = this.TTM.LaSoCuaToi.TuTru[Constants.TRU_THANG].DiaChi.Ten;
            DiaChi dc = null;

            switch (chiThang)
            {
                case ChiEnum.None:
                    break;
                case ChiEnum.Ti:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Hoi);
                    break;
                case ChiEnum.Suu:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ti);
                    break;
                case ChiEnum.Dan:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Suu);
                    break;
                case ChiEnum.Mao:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dan);
                    break;
                case ChiEnum.Thin:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Mao);
                    break;
                case ChiEnum.Ty:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Thin);
                    break;
                case ChiEnum.Ngo:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ty);
                    break;
                case ChiEnum.Mui:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ngo);
                    break;
                case ChiEnum.Than:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Mui);
                    break;
                case ChiEnum.Dau:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Than);
                    break;
                case ChiEnum.Tuat:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dau);
                    break;
                case ChiEnum.Hoi:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Tuat);
                    break;
                default:
                    break;
            }

            if (dc != null)
            {
                dc.AddThanSat(Constants.ThanSat.THIEN_Y);
            }
        }

        private void DichMa_HoaCai_TuongTinh_KiepSat()
        {
            var chiNamNgay = new List<ChiEnum> {
                this.TTM.LaSoCuaToi.TuTru[Constants.TRU_NAM].DiaChi.Ten,
                this.TTM.LaSoCuaToi.TuTru[Constants.TRU_NGAY].DiaChi.Ten};

            if (chiNamNgay.Contains(ChiEnum.Dan)
                || chiNamNgay.Contains(ChiEnum.Ngo)
                || chiNamNgay.Contains(ChiEnum.Tuat))
            {
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Than).AddThanSat(Constants.ThanSat.DICH_MA);

                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Tuat).AddThanSat(Constants.ThanSat.HOA_CAI);

                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ngo).AddThanSat(Constants.ThanSat.TUONG_TINH);

                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Hoi).AddThanSat(Constants.ThanSat.KIEP_SAT);

            }

            if (chiNamNgay.Contains(ChiEnum.Ty)
                || chiNamNgay.Contains(ChiEnum.Dau)
                || chiNamNgay.Contains(ChiEnum.Suu))
            {
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Hoi).AddThanSat(Constants.ThanSat.DICH_MA);

                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Suu).AddThanSat(Constants.ThanSat.HOA_CAI);

                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dau).AddThanSat(Constants.ThanSat.TUONG_TINH);

                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dan).AddThanSat(Constants.ThanSat.KIEP_SAT);

            }

            if (chiNamNgay.Contains(ChiEnum.Than)
                || chiNamNgay.Contains(ChiEnum.Ti)
                || chiNamNgay.Contains(ChiEnum.Thin))
            {
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dan).AddThanSat(Constants.ThanSat.DICH_MA);

                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Thin).AddThanSat(Constants.ThanSat.HOA_CAI);

                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ti).AddThanSat(Constants.ThanSat.TUONG_TINH);

                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ty).AddThanSat(Constants.ThanSat.KIEP_SAT);

            }

            if (chiNamNgay.Contains(ChiEnum.Hoi)
                || chiNamNgay.Contains(ChiEnum.Mao)
                || chiNamNgay.Contains(ChiEnum.Mui))
            {
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ty).AddThanSat(Constants.ThanSat.DICH_MA);

                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Mui).AddThanSat(Constants.ThanSat.HOA_CAI);

                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Mao).AddThanSat(Constants.ThanSat.TUONG_TINH);

                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Than).AddThanSat(Constants.ThanSat.KIEP_SAT);

            }
        }

        private void Dao_Hoa()
        {
            var chiNamGio = new List<ChiEnum> {
                this.TTM.LaSoCuaToi.TuTru[Constants.TRU_NAM].DiaChi.Ten,
                this.TTM.LaSoCuaToi.TuTru[Constants.TRU_GIO].DiaChi.Ten};

            if (chiNamGio.Contains(ChiEnum.Dan)
                || chiNamGio.Contains(ChiEnum.Ngo)
                || chiNamGio.Contains(ChiEnum.Tuat))
            {
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Mao).AddThanSat(Constants.ThanSat.DAO_HOA);
            }

            if (chiNamGio.Contains(ChiEnum.Ty)
                || chiNamGio.Contains(ChiEnum.Dau)
                || chiNamGio.Contains(ChiEnum.Suu))
            {
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ngo).AddThanSat(Constants.ThanSat.DAO_HOA);
            }

            if (chiNamGio.Contains(ChiEnum.Than)
                || chiNamGio.Contains(ChiEnum.Ti)
                || chiNamGio.Contains(ChiEnum.Thin))
            {
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dau).AddThanSat(Constants.ThanSat.DAO_HOA);
            }

            if (chiNamGio.Contains(ChiEnum.Hoi)
                || chiNamGio.Contains(ChiEnum.Mao)
                || chiNamGio.Contains(ChiEnum.Mui))
            {
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ti).AddThanSat(Constants.ThanSat.DAO_HOA);
            }
        }

        private void Dao_Hoa_Sat()
        {
            CanEnum canNgay = this.TTM.LaSoCuaToi.TuTru[Constants.TRU_NGAY].ThienCan.Can;

            switch (canNgay)
            {
                case CanEnum.None:
                    break;
                case CanEnum.Giap:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ti).AddThanSat(Constants.ThanSat.DAO_HOA_SAT);
                    break;
                case CanEnum.At:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ty).AddThanSat(Constants.ThanSat.DAO_HOA_SAT);
                    break;
                case CanEnum.Binh:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Mao).AddThanSat(Constants.ThanSat.DAO_HOA_SAT);
                    break;
                case CanEnum.Dinh:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Than).AddThanSat(Constants.ThanSat.DAO_HOA_SAT);
                    break;
                case CanEnum.Mau:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Mao).AddThanSat(Constants.ThanSat.DAO_HOA_SAT);
                    break;
                case CanEnum.Ky:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Than).AddThanSat(Constants.ThanSat.DAO_HOA_SAT);
                    break;
                case CanEnum.Canh:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ngo).AddThanSat(Constants.ThanSat.DAO_HOA_SAT);
                    break;
                case CanEnum.Tan:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Hoi).AddThanSat(Constants.ThanSat.DAO_HOA_SAT);
                    break;
                case CanEnum.Nham:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dau).AddThanSat(Constants.ThanSat.DAO_HOA_SAT);
                    break;
                case CanEnum.Quy:
                    TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dan).AddThanSat(Constants.ThanSat.DAO_HOA_SAT);
                    break;
                default:
                    break;
            }
        }

        private void KhongVong()
        {
            Tru ngay = this.TTM.LaSoCuaToi.TuTru[Constants.TRU_NGAY];

            int canNgayId = TongHopCanChi.MuoiThienCan.FindIndex(u => u.Can == ngay.ThienCan.Can);
            int quyId = TongHopCanChi.MuoiThienCan.FindIndex(u => u.Can == CanEnum.Quy);

            int steps = quyId - canNgayId;
            int chiNgayId = TongHopCanChi.MuoiHaiDiaChi.FindIndex(u => u.Ten == ngay.DiaChi.Ten);
            int n = TongHopCanChi.MuoiHaiDiaChi.Count;

            int kv1 = (chiNgayId + steps + 1) % n;
            int kv2 = (chiNgayId + steps + 2) % n;

            TongHopCanChi.MuoiHaiDiaChi[kv1].AddThanSat(Constants.ThanSat.KHONG_VONG);
            TongHopCanChi.MuoiHaiDiaChi[kv2].AddThanSat(Constants.ThanSat.KHONG_VONG);
        }

        private void ThienXa()
        {
            var chiThang = this.TTM.LaSoCuaToi.TuTru[Constants.TRU_THANG].DiaChi.Ten;

            switch (chiThang)
            {
                case ChiEnum.None:
                    break;
                case ChiEnum.Dan:
                case ChiEnum.Mao:
                case ChiEnum.Thin:
                    SetThanSatTru(CanEnum.Mau, ChiEnum.Dan, Constants.ThanSat.THIEN_XA);
                    break;
                case ChiEnum.Ty:
                case ChiEnum.Ngo:
                case ChiEnum.Mui:
                    SetThanSatTru(CanEnum.Giap, ChiEnum.Ngo, Constants.ThanSat.THIEN_XA);
                    break;
                case ChiEnum.Than:
                case ChiEnum.Dau:
                case ChiEnum.Tuat:
                    SetThanSatTru(CanEnum.Mau, ChiEnum.Than, Constants.ThanSat.THIEN_XA);
                    break;
                case ChiEnum.Hoi:
                case ChiEnum.Ti:
                case ChiEnum.Suu:
                    SetThanSatTru(CanEnum.Giap, ChiEnum.Ti, Constants.ThanSat.THIEN_XA);
                    break;
                default:
                    break;
            }
        }

        private void HocDuong()
        {
            CanEnum ngay = this.TTM.LaSoCuaToi.TuTru[Constants.TRU_NGAY].ThienCan.Can;

            ChiEnum chi = ChiEnum.None;
            switch (ngay)
            {
                case CanEnum.None:
                    break;
                case CanEnum.Giap:
                case CanEnum.At:
                    chi = ChiEnum.Hoi;
                    break;
                case CanEnum.Binh:
                case CanEnum.Dinh:
                case CanEnum.Mau:
                case CanEnum.Ky:
                    chi = ChiEnum.Dan;
                    break;
                case CanEnum.Canh:
                case CanEnum.Tan:
                    chi = ChiEnum.Ty;
                    break;
                case CanEnum.Nham:
                case CanEnum.Quy:
                    chi = ChiEnum.Than;
                    break;
                default:
                    break;
            }

            if (chi != ChiEnum.None)
            {
                TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == chi).AddThanSat(Constants.ThanSat.HOC_DUONG);
            }
        }

        private void TuQuan()
        {
            List<CanEnum> ngayNam = new List<CanEnum>
                            { this.TTM.LaSoCuaToi.TuTru[Constants.TRU_NGAY].ThienCan.Can,
                                this.TTM.LaSoCuaToi.TuTru[Constants.TRU_NAM].ThienCan.Can
                            };

            if (ngayNam.Contains(CanEnum.Giap))
            {
                SetThanSatTru(CanEnum.Canh, ChiEnum.Dan, Constants.ThanSat.TU_QUAN);
            }

            if (ngayNam.Contains(CanEnum.At))
            {
                SetThanSatTru(CanEnum.Tan, ChiEnum.Mao, Constants.ThanSat.TU_QUAN);
            }

            if (ngayNam.Contains(CanEnum.Binh))
            {
                SetThanSatTru(CanEnum.At, ChiEnum.Ty, Constants.ThanSat.TU_QUAN);
            }

            if (ngayNam.Contains(CanEnum.Dinh))
            {
                SetThanSatTru(CanEnum.Mau, ChiEnum.Ngo, Constants.ThanSat.TU_QUAN);
            }

            if (ngayNam.Contains(CanEnum.Mau))
            {
                SetThanSatTru(CanEnum.Dinh, ChiEnum.Ty, Constants.ThanSat.TU_QUAN);
            }

            if (ngayNam.Contains(CanEnum.Ky))
            {
                SetThanSatTru(CanEnum.Canh, ChiEnum.Ngo, Constants.ThanSat.TU_QUAN);
            }

            if (ngayNam.Contains(CanEnum.Canh))
            {
                SetThanSatTru(CanEnum.Nham, ChiEnum.Than, Constants.ThanSat.TU_QUAN);
            }

            if (ngayNam.Contains(CanEnum.Tan))
            {
                SetThanSatTru(CanEnum.Quy, ChiEnum.Dau, Constants.ThanSat.TU_QUAN);
            }

            if (ngayNam.Contains(CanEnum.Nham))
            {
                SetThanSatTru(CanEnum.Quy, ChiEnum.Hoi, Constants.ThanSat.TU_QUAN);
            }

            if (ngayNam.Contains(CanEnum.Quy))
            {
                SetThanSatTru(CanEnum.Binh, ChiEnum.Ti, Constants.ThanSat.TU_QUAN);
            }

        }

        public void SetThanSat()
        {
            ThienAtQuyNhan();
            ThienNguyetDucQuyNhan();
            KhoiCanhQuyNhan();
            LocThan();
            KinhDuong();
            KimDu();
            VanXuong();
            ThienY();
            DichMa_HoaCai_TuongTinh_KiepSat();
            Dao_Hoa();
            Dao_Hoa_Sat();
            KhongVong();
            ThienXa();
            HocDuong();
            TuQuan();
        }
    }
}
