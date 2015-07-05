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
}
