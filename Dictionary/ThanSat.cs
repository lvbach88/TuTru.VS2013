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

        private void DichMa()
        {
            var chiNamNgay = new List<ChiEnum> {
                this.TTM.LaSoCuaToi.TuTru[Constants.TRU_NAM].DiaChi.Ten,
                this.TTM.LaSoCuaToi.TuTru[Constants.TRU_NGAY].DiaChi.Ten};

            ChiEnum dichMa = ChiEnum.None;
            if (chiNamNgay.Contains(ChiEnum.Dan)
                || chiNamNgay.Contains(ChiEnum.Ngo)
                || chiNamNgay.Contains(ChiEnum.Tuat))
            {
                dichMa = ChiEnum.Than;
            }

            if (chiNamNgay.Contains(ChiEnum.Ty)
                || chiNamNgay.Contains(ChiEnum.Dau)
                || chiNamNgay.Contains(ChiEnum.Suu))
            {
                dichMa = ChiEnum.Hoi;
            }

            if (chiNamNgay.Contains(ChiEnum.Than)
                || chiNamNgay.Contains(ChiEnum.Ti)
                || chiNamNgay.Contains(ChiEnum.Thin))
            {
                dichMa = ChiEnum.Dan;
            }

            if (chiNamNgay.Contains(ChiEnum.Hoi)
                || chiNamNgay.Contains(ChiEnum.Mao)
                || chiNamNgay.Contains(ChiEnum.Mui))
            {
                dichMa = ChiEnum.Ty;
            }

            if (dichMa != ChiEnum.None)
            {

            }
        }
    }
}
