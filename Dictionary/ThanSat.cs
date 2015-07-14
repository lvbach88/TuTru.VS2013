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
    }
}
