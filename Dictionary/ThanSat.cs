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
                    chiThienDuc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ty);
                    chiThienDuc.ThanSat.Add(Constants.ThanSat.THIEN_DUC, Constants.ThanSat.THIEN_DUC);

                    canNguyetDuc = TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Nham);
                    canNguyetDuc.ThanSat.Add(Constants.ThanSat.NGUYET_DUC, Constants.ThanSat.NGUYET_DUC);
                    break;
                case ChiEnum.Suu:
                    canThienDuc = TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Canh);
                    canThienDuc.ThanSat.Add(Constants.ThanSat.THIEN_DUC, Constants.ThanSat.THIEN_DUC);

                    canNguyetDuc = TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Canh);
                    canNguyetDuc.ThanSat.Add(Constants.ThanSat.NGUYET_DUC, Constants.ThanSat.NGUYET_DUC);
                    break;
                case ChiEnum.Dan:

                    canThienDuc = TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Dinh);
                    canNguyetDuc = TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Binh);
                    canThienDuc.ThanSat.Add(Constants.ThanSat.THIEN_DUC, Constants.ThanSat.THIEN_DUC);
                    canNguyetDuc.ThanSat.Add(Constants.ThanSat.NGUYET_DUC, Constants.ThanSat.NGUYET_DUC);

                    break;
                case ChiEnum.Mao:
                    chiThienDuc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Than);
                    chiThienDuc.ThanSat.Add(Constants.ThanSat.THIEN_DUC, Constants.ThanSat.THIEN_DUC);

                    canNguyetDuc = TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Giap);
                    canNguyetDuc.ThanSat.Add(Constants.ThanSat.NGUYET_DUC, Constants.ThanSat.NGUYET_DUC);

                    break;
                case ChiEnum.Thin:
                    canThienDuc = TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Nham);
                    canThienDuc.ThanSat.Add(Constants.ThanSat.THIEN_DUC, Constants.ThanSat.THIEN_DUC);

                    canNguyetDuc = TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Nham);
                    canNguyetDuc.ThanSat.Add(Constants.ThanSat.NGUYET_DUC, Constants.ThanSat.NGUYET_DUC);
                    break;
                case ChiEnum.Ty:
                    canThienDuc = TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Tan);
                    canThienDuc.ThanSat.Add(Constants.ThanSat.THIEN_DUC, Constants.ThanSat.THIEN_DUC);

                    canNguyetDuc = TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Canh);
                    canNguyetDuc.ThanSat.Add(Constants.ThanSat.NGUYET_DUC, Constants.ThanSat.NGUYET_DUC);
                    break;
                case ChiEnum.Ngo:
                    chiThienDuc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Hoi);
                    chiThienDuc.ThanSat.Add(Constants.ThanSat.THIEN_DUC, Constants.ThanSat.THIEN_DUC);

                    canNguyetDuc = TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Binh);
                    canNguyetDuc.ThanSat.Add(Constants.ThanSat.NGUYET_DUC, Constants.ThanSat.NGUYET_DUC);
                    break;
                case ChiEnum.Mui:
                    canThienDuc = TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Giap);
                    canThienDuc.ThanSat.Add(Constants.ThanSat.THIEN_DUC, Constants.ThanSat.THIEN_DUC);

                    canNguyetDuc = TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Giap);
                    canNguyetDuc.ThanSat.Add(Constants.ThanSat.NGUYET_DUC, Constants.ThanSat.NGUYET_DUC);
                    break;
                case ChiEnum.Than:
                    canThienDuc = TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Quy);
                    canThienDuc.ThanSat.Add(Constants.ThanSat.THIEN_DUC, Constants.ThanSat.THIEN_DUC);

                    canNguyetDuc = TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Nham);
                    canNguyetDuc.ThanSat.Add(Constants.ThanSat.NGUYET_DUC, Constants.ThanSat.NGUYET_DUC);
                    break;
                case ChiEnum.Dau:
                    chiThienDuc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dan);
                    chiThienDuc.ThanSat.Add(Constants.ThanSat.THIEN_DUC, Constants.ThanSat.THIEN_DUC);

                    canNguyetDuc = TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Canh);
                    canNguyetDuc.ThanSat.Add(Constants.ThanSat.NGUYET_DUC, Constants.ThanSat.NGUYET_DUC);
                    break;
                case ChiEnum.Tuat:
                    canThienDuc = TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Binh);
                    canThienDuc.ThanSat.Add(Constants.ThanSat.THIEN_DUC, Constants.ThanSat.THIEN_DUC);

                    canNguyetDuc = TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Binh);
                    canNguyetDuc.ThanSat.Add(Constants.ThanSat.NGUYET_DUC, Constants.ThanSat.NGUYET_DUC);
                    break;
                case ChiEnum.Hoi:
                    canThienDuc = TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.At);
                    canThienDuc.ThanSat.Add(Constants.ThanSat.THIEN_DUC, Constants.ThanSat.THIEN_DUC);

                    canNguyetDuc = TongHopCanChi.MuoiThienCan.Find(u => u.Can == CanEnum.Giap);
                    canNguyetDuc.ThanSat.Add(Constants.ThanSat.NGUYET_DUC, Constants.ThanSat.NGUYET_DUC);
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
                truNgay.DiaChi.ThanSat.Add(Constants.ThanSat.KHOI_CANH_QUY_NHAN, Constants.ThanSat.KHOI_CANH_QUY_NHAN);
            }
        }

        private void LocThan()
        {
            var canNgay = this.TTM.LaSoCuaToi.TuTru[Constants.TRU_NGAY].ThienCan.Can;

            DiaChi dc = null;
            switch (canNgay)
            {
                case CanEnum.None:
                    break;
                case CanEnum.Giap:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dan);
                    dc.ThanSat.Add(Constants.ThanSat.LOC_THAN, Constants.ThanSat.LOC_THAN);
                    break;
                case CanEnum.At:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Mao);
                    dc.ThanSat.Add(Constants.ThanSat.LOC_THAN, Constants.ThanSat.LOC_THAN);
                    break;
                case CanEnum.Binh:
                case CanEnum.Mau:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ty);
                    dc.ThanSat.Add(Constants.ThanSat.LOC_THAN, Constants.ThanSat.LOC_THAN);
                    break;
                case CanEnum.Dinh:
                case CanEnum.Ky:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ngo);
                    dc.ThanSat.Add(Constants.ThanSat.LOC_THAN, Constants.ThanSat.LOC_THAN);
                    break;
                case CanEnum.Canh:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Than);
                    dc.ThanSat.Add(Constants.ThanSat.LOC_THAN, Constants.ThanSat.LOC_THAN);
                    break;
                case CanEnum.Tan:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dau);
                    dc.ThanSat.Add(Constants.ThanSat.LOC_THAN, Constants.ThanSat.LOC_THAN);
                    break;
                case CanEnum.Nham:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Hoi);
                    dc.ThanSat.Add(Constants.ThanSat.LOC_THAN, Constants.ThanSat.LOC_THAN);
                    break;
                case CanEnum.Quy:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ti);
                    dc.ThanSat.Add(Constants.ThanSat.LOC_THAN, Constants.ThanSat.LOC_THAN);
                    break;
                default:
                    break;
            }
        }
    }
}
