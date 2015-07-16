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
        }

        private void ThienAtQuyNhan()
        {
            var namNgay = new List<CanEnum> {TTM.LaSoCuaToi.TuTru[Constants.TRU_NAM].ThienCan.Can,
                TTM.LaSoCuaToi.TuTru[Constants.TRU_NGAY].ThienCan.Can};

            ChiEnum chi1 = ChiEnum.None, chi2 = ChiEnum.None;

            if (namNgay.Contains(CanEnum.Giap) || namNgay.Contains(CanEnum.Mau))
            {
                chi1 = ChiEnum.Mui;
                chi2 = ChiEnum.Suu;
            }
            
            if (namNgay.Contains(CanEnum.At) || namNgay.Contains(CanEnum.Ky))
            {
                chi1 = ChiEnum.Than;
                chi2 = ChiEnum.Ti;
            }

            if (namNgay.Contains(CanEnum.Binh) || namNgay.Contains(CanEnum.Dinh))
            {
                chi1 = ChiEnum.Dau;
                chi2 = ChiEnum.Hoi;
            }

            if (namNgay.Contains(CanEnum.Canh) || namNgay.Contains(CanEnum.Tan))
            {
                chi1 = ChiEnum.Dan;
                chi2 = ChiEnum.Ngo;
            }

            if (namNgay.Contains(CanEnum.Nham) || namNgay.Contains(CanEnum.Quy))
            {
                chi1 = ChiEnum.Mao;
                chi2 = ChiEnum.Ty;
            }

            if (chi1 != ChiEnum.None)
            {
                DiaChi dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == chi1);
                if (!dc.ThanSat.ContainsKey(Constants.ThanSat.THIEN_AT_QUY_NHAN))
                {
                    dc.ThanSat.Add(Constants.ThanSat.THIEN_AT_QUY_NHAN, Constants.ThanSat.THIEN_AT_QUY_NHAN);
                }
            }

            if (chi2 != ChiEnum.None)
            {
                DiaChi dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == chi2);
                if (!dc.ThanSat.ContainsKey(Constants.ThanSat.THIEN_AT_QUY_NHAN))
                {
                    dc.ThanSat.Add(Constants.ThanSat.THIEN_AT_QUY_NHAN, Constants.ThanSat.THIEN_AT_QUY_NHAN);
                }
            }
        }

        private void ThienNguyetDucQuyNhan()
        {
            var thang = this.TTM.LaSoCuaToi.TuTru[Constants.TRU_THANG].DiaChi.Ten;

            ThienCan canThienDuc = null, canNguyetDuc = null;
            DiaChi chiThienDuc = null;


            switch (thang)
            {
                case ChiEnum.None:
                    break;
                case ChiEnum.Ti:
                    
                    break;
                case ChiEnum.Suu:
                    break;
                case ChiEnum.Dan:

                    canThienDuc = TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Dinh);
                    canNguyetDuc = TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Binh);
                    canThienDuc.ThanSat.Add(Constants.ThanSat.THIEN_DUC, Constants.ThanSat.THIEN_DUC);
                    canNguyetDuc.ThanSat.Add(Constants.ThanSat.NGUYET_DUC, Constants.ThanSat.NGUYET_DUC);

                    break;
                case ChiEnum.Mao:
                    

                    break;
                case ChiEnum.Thin:
                    break;
                case ChiEnum.Ty:
                    break;
                case ChiEnum.Ngo:
                    break;
                case ChiEnum.Mui:
                    break;
                case ChiEnum.Than:
                    break;
                case ChiEnum.Dau:
                    break;
                case ChiEnum.Tuat:
                    break;
                case ChiEnum.Hoi:
                    break;
                default:
                    break;
            }
        }
    }
}
