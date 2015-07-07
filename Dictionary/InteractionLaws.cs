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

        protected void Init(TuTruMap ttm)
        {
            var laso = ttm.LaSoCuaToi;
            TatcaTru = new List<Tru>();
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
}
