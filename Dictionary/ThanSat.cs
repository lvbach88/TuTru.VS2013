﻿using Data;
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
                truNgay.ThanSat.Add(Constants.ThanSat.KHOI_CANH_QUY_NHAN, Constants.ThanSat.KHOI_CANH_QUY_NHAN);
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
                    break;
                case CanEnum.At:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Mao);
                    break;
                case CanEnum.Binh:
                case CanEnum.Mau:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ty);
                    break;
                case CanEnum.Dinh:
                case CanEnum.Ky:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ngo);
                    break;
                case CanEnum.Canh:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Than);
                    break;
                case CanEnum.Tan:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dau);
                    break;
                case CanEnum.Nham:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Hoi);
                    break;
                case CanEnum.Quy:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ti);
                    break;
                default:
                    break;
            }

            if (dc != null)
            {
                dc.ThanSat.Add(Constants.ThanSat.LOC_THAN, Constants.ThanSat.LOC_THAN);
            }
        }

        private void KinhDuong()
        {
            var canNgay = this.TTM.LaSoCuaToi.TuTru[Constants.TRU_NGAY].ThienCan.Can;

            DiaChi dc = null;
            switch (canNgay)
            {
                case CanEnum.None:
                    break;
                case CanEnum.Giap:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Mao);
                    break;
                case CanEnum.At:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dan);
                    break;
                case CanEnum.Binh:
                case CanEnum.Mau:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ngo);
                    break;
                case CanEnum.Dinh:
                case CanEnum.Ky:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ty);
                    break;
                case CanEnum.Canh:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dau);
                    break;
                case CanEnum.Tan:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Than);
                    break;
                case CanEnum.Nham:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ti);
                    break;
                case CanEnum.Quy:
                    dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Hoi);
                    break;
                default:
                    break;
            }
            if (dc != null)
            {
                dc.ThanSat.Add(Constants.ThanSat.KINH_DUONG, Constants.ThanSat.KINH_DUONG);
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
                dc.ThanSat.Add(Constants.ThanSat.KIM_DU, Constants.ThanSat.KIM_DU);
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
                dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ty);
            }
            if (ngayNam.Contains(CanEnum.At))
            {
                dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ngo);
            }
            if (ngayNam.Contains(CanEnum.Binh))
            {
                dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Than);
            }
            if (ngayNam.Contains(CanEnum.Dinh))
            {
                dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dau);
            }
            if (ngayNam.Contains(CanEnum.Mau))
            {
                dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Than);
            }
            if (ngayNam.Contains(CanEnum.Ky))
            {
                dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dau);
            }
            if (ngayNam.Contains(CanEnum.Canh))
            {
                dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Hoi);
            }
            if (ngayNam.Contains(CanEnum.Tan))
            {
                dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Ti);
            }
            if (ngayNam.Contains(CanEnum.Nham))
            {
                dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Dan);
            }
            if (ngayNam.Contains(CanEnum.Quy))
            {
                dc = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == ChiEnum.Mao);
            }
            

            if (dc != null)
            {
                dc.ThanSat.Add(Constants.ThanSat.VAN_XUONG, Constants.ThanSat.VAN_XUONG);
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
                dc.ThanSat.Add(Constants.ThanSat.THIEN_Y, Constants.ThanSat.THIEN_Y);
            }
        }
    }
}
