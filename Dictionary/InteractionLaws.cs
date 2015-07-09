using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public abstract class InteractionLaws
    {
        public List<string> GeneralGuidelines { get; private set; }
        public List<Tru> TatcaTru { get; private set; }

        public List<Tru> TuTru { get; private set; }

        protected void Init(TuTruMap ttm)
        {
            var laso = ttm.LaSoCuaToi;
            TatcaTru = new List<Tru>();
            TuTru = new List<Tru>();

            TuTru.AddRange(laso.TuTru.Values.ToList<Tru>());

            TatcaTru.AddRange(laso.TuTru.Values.ToList<Tru>());
            TatcaTru.Add(ttm.DaiVanHienTai);
            TatcaTru.Add(LookUpTable.TruOfTheYear());
        }

        abstract public void SetLaw();
    }

    public class DiaChiLucHop : InteractionLaws
    {
        public DiaChiLucHop(TuTruMap ttm)
        {
            base.Init(ttm);
        }

        public override void SetLaw()
        {
            this.CheckLucHop(ChiEnum.Ti, ChiEnum.Suu);
            this.CheckLucHop(ChiEnum.Dan, ChiEnum.Hoi);
            this.CheckLucHop(ChiEnum.Mao, ChiEnum.Tuat);
            
            this.CheckLucHop(ChiEnum.Thin, ChiEnum.Dau);
            this.CheckLucHop(ChiEnum.Ty, ChiEnum.Than);
            this.CheckLucHop(ChiEnum.Ngo, ChiEnum.Mui);
        }

        private void CheckLucHop(ChiEnum chi1, ChiEnum chi2)
        {
            var chi1Id = TatcaTru.FindIndex(u => u.DiaChi.Ten == chi1);
            var chi2Id = TatcaTru.FindIndex(u => u.DiaChi.Ten == chi2);

            if (chi1Id != -1 && chi2Id != -1)
            {
                var diaChi1 = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == chi1);
                var diaChi2 = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == chi2);
                var nguHanhChi1 = diaChi1.BanKhi.NguHanh;
                var nguHanhChi2 = diaChi2.BanKhi.NguHanh;

                var sinhKhac = LookUpTable.NguHanhSinhKhac[nguHanhChi1];
                var nhSinh = sinhKhac.Item1;
                var nhDuocSinh = sinhKhac.Item2;
                var nhKhac = sinhKhac.Item3;
                var nhBiKhac = sinhKhac.Item4;

                string thuocTinh = string.Empty;
                if (nguHanhChi2 == nhSinh || nguHanhChi2 == nhDuocSinh)
                {
                    thuocTinh = Constants.ThuocTinh.LUC_HOP_SINH;
                }
                else if (nguHanhChi2 == nhKhac || nguHanhChi2 == nhBiKhac)
                {
                    thuocTinh = Constants.ThuocTinh.LUC_HOP_KHAC;
                }

                var lucHop = NguHanhEnum.None;
                var lucHopTho = new List<ChiEnum> { ChiEnum.Ti, ChiEnum.Suu, ChiEnum.Ngo, ChiEnum.Mui };
                var lucHopMoc = new List<ChiEnum> { ChiEnum.Dan, ChiEnum.Hoi };
                var lucHopHoa = new List<ChiEnum> { ChiEnum.Mao, ChiEnum.Tuat };
                var lucHopKim = new List<ChiEnum> { ChiEnum.Thin, ChiEnum.Dau };
                var lucHopThuy = new List<ChiEnum> { ChiEnum.Ty, ChiEnum.Than };
                if (lucHopTho.Contains(chi1))
                {
                    lucHop = NguHanhEnum.Tho;
                }
                else if (lucHopMoc.Contains(chi1))
                {
                    lucHop = NguHanhEnum.Moc;
                }
                else if (lucHopHoa.Contains(chi1))
                {
                    lucHop = NguHanhEnum.Hoa;
                }
                else if (lucHopKim.Contains(chi1))
                {
                    lucHop = NguHanhEnum.Kim;
                }
                else if (lucHopThuy.Contains(chi1))
                {
                    lucHop = NguHanhEnum.Thuy;
                }

                if (!diaChi1.ThuocTinh.Keys.Contains(thuocTinh))
                {
                    diaChi1.ThuocTinh.Add(thuocTinh, lucHop);
                }

                if (!diaChi2.ThuocTinh.Keys.Contains(thuocTinh))
                {
                    diaChi2.ThuocTinh.Add(thuocTinh, lucHop);
                }

            }
        }
    }

    public class DiaChiLucXung : InteractionLaws
    {
        public DiaChiLucXung(TuTruMap ttm)
        {
            base.Init(ttm);
        }

        public override void SetLaw()
        {
            this.CheckLucXung(ChiEnum.Ti, ChiEnum.Ngo);
            this.CheckLucXung(ChiEnum.Suu, ChiEnum.Mui);
            this.CheckLucXung(ChiEnum.Dan, ChiEnum.Than);

            this.CheckLucXung(ChiEnum.Mao, ChiEnum.Dau);
            this.CheckLucXung(ChiEnum.Thin, ChiEnum.Tuat);
            this.CheckLucXung(ChiEnum.Ty, ChiEnum.Hoi);
        }

        private void CheckLucXung(ChiEnum chi1, ChiEnum chi2)
        {
            var chi1Id = TatcaTru.FindIndex(u => u.DiaChi.Ten == chi1);
            var chi2Id = TatcaTru.FindIndex(u => u.DiaChi.Ten == chi2);

            if (chi1Id != -1 && chi2Id != -1)
            {
                var diaChi1 = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == chi1);
                var diaChi2 = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == chi2);
               
                string thuocTinh = Constants.ThuocTinh.LUC_XUNG;
         
                var lucXung = string.Empty;
                var tiNgo = new List<ChiEnum> { ChiEnum.Ti, ChiEnum.Ngo};
                var suuMui = new List<ChiEnum> { ChiEnum.Suu, ChiEnum.Mui };
                var danThan = new List<ChiEnum> { ChiEnum.Dan, ChiEnum.Than };

                var maoDau = new List<ChiEnum> { ChiEnum.Mao, ChiEnum.Dau };
                var thinTuat = new List<ChiEnum> { ChiEnum.Thin, ChiEnum.Tuat};
                var tyHoi = new List<ChiEnum> { ChiEnum.Ty, ChiEnum.Hoi };

                if (tiNgo.Contains(chi1))
                {
                    lucXung = Constants.DiaChiLucXung.TI_NGO;
                }
                else if (suuMui.Contains(chi1))
                {
                    lucXung = Constants.DiaChiLucXung.SUU_MUI;
                }
                else if (danThan.Contains(chi1))
                {
                    lucXung = Constants.DiaChiLucXung.DAN_THAN;
                }
                else if (maoDau.Contains(chi1))
                {
                    lucXung = Constants.DiaChiLucXung.MAO_DAU;
                }
                else if (thinTuat.Contains(chi1))
                {
                    lucXung = Constants.DiaChiLucXung.THIN_TUAT;
                }
                else if (tyHoi.Contains(chi1))
                {
                    lucXung = Constants.DiaChiLucXung.TY_HOI;
                }

                if (!diaChi1.ThuocTinh.Keys.Contains(thuocTinh))
                {
                    diaChi1.ThuocTinh.Add(thuocTinh, lucXung);
                }

                if (!diaChi2.ThuocTinh.Keys.Contains(thuocTinh))
                {
                    diaChi2.ThuocTinh.Add(thuocTinh, lucXung);
                }

            }
        }
    }

    public class DiaChiLucHai : InteractionLaws
    {
        public DiaChiLucHai(TuTruMap ttm)
        {
            base.Init(ttm);
        }

        public override void SetLaw()
        {
            this.CheckLucHai(ChiEnum.Ti, ChiEnum.Mui);
            this.CheckLucHai(ChiEnum.Suu, ChiEnum.Ngo);
            this.CheckLucHai(ChiEnum.Dan, ChiEnum.Ty);

            this.CheckLucHai(ChiEnum.Mao, ChiEnum.Thin);
            this.CheckLucHai(ChiEnum.Than, ChiEnum.Hoi);
            this.CheckLucHai(ChiEnum.Dau, ChiEnum.Tuat);
        }

        private void CheckLucHai(ChiEnum chi1, ChiEnum chi2)
        {
            var chi1Id = TatcaTru.FindIndex(u => u.DiaChi.Ten == chi1);
            var chi2Id = TatcaTru.FindIndex(u => u.DiaChi.Ten == chi2);

            if (chi1Id != -1 && chi2Id != -1)
            {
                var diaChi1 = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == chi1);
                var diaChi2 = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == chi2);

                string thuocTinh = Constants.ThuocTinh.LUC_HAI;

                var lucHai = string.Empty;
                var tiMui = new List<ChiEnum> { ChiEnum.Ti, ChiEnum.Mui };
                var suuNgo = new List<ChiEnum> { ChiEnum.Suu, ChiEnum.Ngo };
                var danTy = new List<ChiEnum> { ChiEnum.Dan, ChiEnum.Ty };

                var maoThin = new List<ChiEnum> { ChiEnum.Mao, ChiEnum.Thin };
                var dauTuat = new List<ChiEnum> { ChiEnum.Dau, ChiEnum.Tuat };
                var thanHoi = new List<ChiEnum> { ChiEnum.Than, ChiEnum.Hoi };

                if (tiMui.Contains(chi1))
                {
                    lucHai = Constants.DiaChiLucHai.TI_MUI;
                }
                else if (suuNgo.Contains(chi1))
                {
                    lucHai = Constants.DiaChiLucHai.SUU_NGO;
                }
                else if (danTy.Contains(chi1))
                {
                    lucHai = Constants.DiaChiLucHai.DAN_TY;
                }
                else if (maoThin.Contains(chi1))
                {
                    lucHai = Constants.DiaChiLucHai.MAO_THIN;
                }
                else if (dauTuat.Contains(chi1))
                {
                    lucHai = Constants.DiaChiLucHai.DAU_TUAT;
                }
                else if (thanHoi.Contains(chi1))
                {
                    lucHai = Constants.DiaChiLucHai.THAN_HOI;
                }

                if (!diaChi1.ThuocTinh.Keys.Contains(thuocTinh))
                {
                    diaChi1.ThuocTinh.Add(thuocTinh, lucHai);
                }

                if (!diaChi2.ThuocTinh.Keys.Contains(thuocTinh))
                {
                    diaChi2.ThuocTinh.Add(thuocTinh, lucHai);
                }

            }
        }
    }

    public class DiaChiTamHoi : InteractionLaws
    {
        public DiaChiTamHoi(TuTruMap ttm)
        {
            base.Init(ttm);
        }

        public override void SetLaw()
        {
            //throw new NotImplementedException();
            this.CheckTamHoi(ChiEnum.Dan, ChiEnum.Mao, ChiEnum.Thin);
            this.CheckTamHoi(ChiEnum.Ty, ChiEnum.Ngo, ChiEnum.Mui);
            this.CheckTamHoi(ChiEnum.Than, ChiEnum.Dau, ChiEnum.Tuat);
            this.CheckTamHoi(ChiEnum.Hoi, ChiEnum.Ti, ChiEnum.Suu);
        }

        private void CheckTamHoi(ChiEnum chi1, ChiEnum chi2, ChiEnum chi3)
        {
            int count = 0;
            DiaChi dc1 = null, dc2 = null, dc3 = null;
            var chi1Id = TatcaTru.FindIndex(u => u.DiaChi.Ten == chi1);
            var chi2Id = TatcaTru.FindIndex(u => u.DiaChi.Ten == chi2);
            var chi3Id = TatcaTru.FindIndex(u => u.DiaChi.Ten == chi3);

            if (chi1Id != -1)
            {
                count++;
                dc1 = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == chi1);
            }

            if (chi2Id != -1)
            {
                count++;
                dc2 = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == chi2);
            }

            if (chi3Id != -1)
            {
                count++;
                dc3 = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == chi3);
            }

            string thuocTinh = string.Empty;
            if (count == 2)
            {
                thuocTinh = Constants.ThuocTinh.BAN_TAM_HOI;
            }

            if (count == 3)
            {
                thuocTinh = Constants.ThuocTinh.TAM_HOI;
            }

            if (dc1 != null)
            {
                this.SetThuocTinh(dc1, thuocTinh);
            }

            if (dc2 != null)
            {
                this.SetThuocTinh(dc2, thuocTinh);
            }

            if (dc3 != null)
            {
                this.SetThuocTinh(dc3, thuocTinh);
            }
        }

        private void SetThuocTinh(DiaChi dc, string thuocTinh)
        {
            var xuan = new List<ChiEnum> { ChiEnum.Dan, ChiEnum.Mao, ChiEnum.Thin };
            var ha = new List<ChiEnum> { ChiEnum.Ty, ChiEnum.Ngo, ChiEnum.Mui };
            var thu = new List<ChiEnum> { ChiEnum.Than, ChiEnum.Dau, ChiEnum.Tuat };
            var dong = new List<ChiEnum> { ChiEnum.Hoi, ChiEnum.Ti, ChiEnum.Suu };

            if (xuan.Contains(dc.Ten))
            {
                dc.ThuocTinh.Add(thuocTinh, NguHanhEnum.Moc);
            }
            else if (ha.Contains(dc.Ten))
            {
                dc.ThuocTinh.Add(thuocTinh, NguHanhEnum.Hoa);
            }
            else if (thu.Contains(dc.Ten))
            {
                dc.ThuocTinh.Add(thuocTinh, NguHanhEnum.Kim);
            }
            else if (dong.Contains(dc.Ten))
            {
                dc.ThuocTinh.Add(thuocTinh, NguHanhEnum.Thuy);
            }
        }
    }

    public class DiaChiTamHop : InteractionLaws
    {
        public DiaChiTamHop(TuTruMap ttm)
        {
            base.Init(ttm);
        }

        public override void SetLaw()
        {
            //throw new NotImplementedException();
            this.CheckTamHop(ChiEnum.Dan, ChiEnum.Ngo, ChiEnum.Tuat);
            this.CheckTamHop(ChiEnum.Ty, ChiEnum.Dau, ChiEnum.Suu);
            this.CheckTamHop(ChiEnum.Than, ChiEnum.Ti, ChiEnum.Thin);
            this.CheckTamHop(ChiEnum.Hoi, ChiEnum.Mao, ChiEnum.Mui);
        }

        private void CheckTamHop(ChiEnum chi1, ChiEnum chi2, ChiEnum chi3)
        {
            int count = 0;
            DiaChi dc1 = null, dc2 = null, dc3 = null;
            var chi1Id = TatcaTru.FindIndex(u => u.DiaChi.Ten == chi1);
            var chi2Id = TatcaTru.FindIndex(u => u.DiaChi.Ten == chi2);
            var chi3Id = TatcaTru.FindIndex(u => u.DiaChi.Ten == chi3);

            if (chi1Id != -1)
            {
                count++;
                dc1 = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == chi1);
            }

            if (chi2Id != -1)
            {
                count++;
                dc2 = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == chi2);
            }

            if (chi3Id != -1)
            {
                count++;
                dc3 = TongHopCanChi.MuoiHaiDiaChi.Find(u => u.Ten == chi3);
            }

            string thuocTinh = string.Empty;
            if (count == 2)
            {
                thuocTinh = Constants.ThuocTinh.BAN_TAM_HOP;
            }

            if (count == 3)
            {
                thuocTinh = Constants.ThuocTinh.TAM_HOP;
            }

            if (dc1 != null)
            {
                this.SetThuocTinh(dc1, thuocTinh);
            }

            if (dc2 != null)
            {
                this.SetThuocTinh(dc2, thuocTinh);
            }

            if (dc3 != null)
            {
                this.SetThuocTinh(dc3, thuocTinh);
            }
        }

        private void SetThuocTinh(DiaChi dc, string thuocTinh)
        {
            this.CheckTamHop(ChiEnum.Dan, ChiEnum.Ngo, ChiEnum.Tuat);
            this.CheckTamHop(ChiEnum.Ty, ChiEnum.Dau, ChiEnum.Suu);
            this.CheckTamHop(ChiEnum.Than, ChiEnum.Ti, ChiEnum.Thin);
            this.CheckTamHop(ChiEnum.Hoi, ChiEnum.Mao, ChiEnum.Mui);

            var hoa = new List<ChiEnum> { ChiEnum.Dan, ChiEnum.Ngo, ChiEnum.Tuat };
            var kim = new List<ChiEnum> { ChiEnum.Ty, ChiEnum.Dau, ChiEnum.Suu };
            var thuy = new List<ChiEnum> { ChiEnum.Than, ChiEnum.Ti, ChiEnum.Thin };
            var moc = new List<ChiEnum> { ChiEnum.Hoi, ChiEnum.Mao, ChiEnum.Mui };

            if (hoa.Contains(dc.Ten))
            {
                dc.ThuocTinh.Add(thuocTinh, NguHanhEnum.Hoa);
            }
            else if (kim.Contains(dc.Ten))
            {
                dc.ThuocTinh.Add(thuocTinh, NguHanhEnum.Kim);
            }
            else if (thuy.Contains(dc.Ten))
            {
                dc.ThuocTinh.Add(thuocTinh, NguHanhEnum.Thuy);
            }
            else if (moc.Contains(dc.Ten))
            {
                dc.ThuocTinh.Add(thuocTinh, NguHanhEnum.Moc);
            }
        }
    }

    public class DiaChiTuongHinh : InteractionLaws
    {
        public DiaChiTuongHinh(TuTruMap ttm)
        {
            base.Init(ttm);
        }

        public override void SetLaw()
        {
            //throw new NotImplementedException();
            this.CheckTuHinh();
            this.CheckNhiHinh();
            this.CheckTamHinh();
        }

        #region Tu Hinh
        private void CheckTuHinh()
        {
            this.CheckTuHinhTheoChi(ChiEnum.Thin);
            this.CheckTuHinhTheoChi(ChiEnum.Ngo);
            this.CheckTuHinhTheoChi(ChiEnum.Dau);
            this.CheckTuHinhTheoChi(ChiEnum.Hoi);
        }

        private void CheckTuHinhTheoChi(ChiEnum chi)
        {
            for (int i = 0; i < this.TuTru.Count-1; i++)
            {
                var currTru = this.TuTru[i];
                var nextTru = this.TuTru[i + 1];
                if (currTru.DiaChi.Ten == chi && nextTru.DiaChi.Ten == chi)
                {
                    //Tu Hinh se la thuoc tinh cua Tru. 
                    //This is a work-around.
                    if (!currTru.ThuocTinh.ContainsKey(Constants.ThuocTinh.TU_HINH))
                    {
                        currTru.ThuocTinh.Add(Constants.ThuocTinh.TU_HINH, Constants.DiaChiTuongHinh.TU_HINH);
                    }


                    if (!nextTru.ThuocTinh.ContainsKey(Constants.ThuocTinh.TU_HINH))
                    {
                        nextTru.ThuocTinh.Add(Constants.ThuocTinh.TU_HINH, Constants.DiaChiTuongHinh.TU_HINH);
                    }
                }
            }
        }

        #endregion Tu Hinh

        #region Nhi Hinh
        private void CheckNhiHinh()
        {
            var tiId = this.TuTru.FindIndex(u => u.DiaChi.Ten == ChiEnum.Ti);
            var maoId = this.TuTru.FindIndex(u => u.DiaChi.Ten == ChiEnum.Mao);

            DiaChi ti = null, mao = null;
            if (tiId != -1 && maoId != -1)
            {
                ti = this.TuTru[tiId].DiaChi;
                mao = this.TuTru[maoId].DiaChi;
                var thuocTinh = Constants.ThuocTinh.NHI_HINH;
                ti.ThuocTinh.Add(thuocTinh, Constants.DiaChiTuongHinh.NHI_HINH);
                mao.ThuocTinh.Add(thuocTinh, Constants.DiaChiTuongHinh.NHI_HINH);
            }
        }

        #endregion Nhi Hinh

        #region Tam Hinh
        private void CheckTamHinh()
        {
            this.CheckTamHinhTheoChi(ChiEnum.Dan, ChiEnum.Ty, ChiEnum.Than);
            this.CheckTamHinhTheoChi(ChiEnum.Suu, ChiEnum.Tuat, ChiEnum.Mui);
        }

        private void CheckTamHinhTheoChi(ChiEnum chi1, ChiEnum chi2, ChiEnum chi3)
        {
            var chi1Id = this.TuTru.FindIndex(u => u.DiaChi.Ten == chi1);
            var chi2Id = this.TuTru.FindIndex(u => u.DiaChi.Ten == chi2);
            var chi3Id = this.TuTru.FindIndex(u => u.DiaChi.Ten == chi3);

            if (chi1Id != -1 && chi2Id != -1 && chi3Id != -1)
            {
                var dc1 = this.TuTru[chi1Id].DiaChi;
                var dc2 = this.TuTru[chi2Id].DiaChi;
                var dc3 = this.TuTru[chi3Id].DiaChi;

                var dantythan = new List<ChiEnum> {ChiEnum.Dan, ChiEnum.Ty, ChiEnum.Than };
                var suutuatmui = new List<ChiEnum> { ChiEnum.Suu, ChiEnum.Tuat, ChiEnum.Mui };

                if (dantythan.Contains(chi1))
                {
                    dc1.ThuocTinh.Add(Constants.ThuocTinh.TAM_HINH, Constants.DiaChiTuongHinh.DAN_TY_THAN);
                    dc2.ThuocTinh.Add(Constants.ThuocTinh.TAM_HINH, Constants.DiaChiTuongHinh.DAN_TY_THAN);
                    dc3.ThuocTinh.Add(Constants.ThuocTinh.TAM_HINH, Constants.DiaChiTuongHinh.DAN_TY_THAN);
                }
                else if (suutuatmui.Contains(chi1))
                {
                    dc1.ThuocTinh.Add(Constants.ThuocTinh.TAM_HINH, Constants.DiaChiTuongHinh.SUU_TUAT_MUI);
                    dc2.ThuocTinh.Add(Constants.ThuocTinh.TAM_HINH, Constants.DiaChiTuongHinh.SUU_TUAT_MUI);
                    dc3.ThuocTinh.Add(Constants.ThuocTinh.TAM_HINH, Constants.DiaChiTuongHinh.SUU_TUAT_MUI);
                }
               
            }

        }

        #endregion Tam Hinh
    }

    public class DiaChiTuongLien : InteractionLaws
    {
        public DiaChiTuongLien(TuTruMap ttm)
        {
            base.Init(ttm);
        }

        public override void SetLaw()
        {
            //throw new NotImplementedException();
            var chiList = new List<ChiEnum> {ChiEnum.Ti, ChiEnum.Suu, ChiEnum.Dan, 
                ChiEnum.Mao, ChiEnum.Ty, ChiEnum.Ngo,
                ChiEnum.Mui, ChiEnum.Than, ChiEnum.Dau, ChiEnum.Hoi};
            foreach (var chi in chiList)
            {
                this.CheckTuongLien(chi);
            }
        }

        private void CheckTuongLien(ChiEnum chi)
        {
            int count = 0;
            foreach (var item in this.TuTru)
            {
                if (item.DiaChi.Ten == chi)
                {
                    count++;
                }
            }

            if (count == Constants.DiaChiTuongLien.SO_TUONG_LIEN)
            {
                var dc = this.TuTru.Find(u => u.DiaChi.Ten == chi);
                var thuocTinh = Constants.ThuocTinh.TUONG_LIEN;
                switch (chi)
                {
                    case ChiEnum.None:
                        break;
                    case ChiEnum.Ti:
                        dc.ThuocTinh.Add(thuocTinh, Constants.DiaChiTuongLien.TAM_TI);
                        break;
                    case ChiEnum.Suu:
                        dc.ThuocTinh.Add(thuocTinh, Constants.DiaChiTuongLien.TAM_SUU);
                        break;
                    case ChiEnum.Dan:
                        dc.ThuocTinh.Add(thuocTinh, Constants.DiaChiTuongLien.TAM_DAN);
                        break;
                    case ChiEnum.Mao:
                        dc.ThuocTinh.Add(thuocTinh, Constants.DiaChiTuongLien.TAM_MAO);
                        break;
                    case ChiEnum.Thin:
                        break;
                    case ChiEnum.Ty:
                        dc.ThuocTinh.Add(thuocTinh, Constants.DiaChiTuongLien.TAM_TY);
                        break;
                    case ChiEnum.Ngo:
                        dc.ThuocTinh.Add(thuocTinh, Constants.DiaChiTuongLien.TAM_NGO);
                        break;
                    case ChiEnum.Mui:
                        dc.ThuocTinh.Add(thuocTinh, Constants.DiaChiTuongLien.TAM_MUI);
                        break;
                    case ChiEnum.Than:
                        dc.ThuocTinh.Add(thuocTinh, Constants.DiaChiTuongLien.TAM_THAN);
                        break;
                    case ChiEnum.Dau:
                        dc.ThuocTinh.Add(thuocTinh, Constants.DiaChiTuongLien.TAM_DAU);
                        break;
                    case ChiEnum.Tuat:
                        break;
                    case ChiEnum.Hoi:
                        dc.ThuocTinh.Add(thuocTinh, Constants.DiaChiTuongLien.TAM_HOI);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
