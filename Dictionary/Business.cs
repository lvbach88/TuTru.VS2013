using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Business
{
    public class Business
    {

        public LaSo LaSoCuaToi { get; set; }

        
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

        public void CreateDaiVan(int age = Int16.MinValue)
        {
            if (this.LaSoCuaToi == null)
            {
                return;
            }

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
                    this.LaSoCuaToi.Tuoi.Add(age);
                    age += Constants.NAM_DAI_VAN;
                }
            }

        }
    }
}
