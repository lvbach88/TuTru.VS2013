using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{

    public enum CanEnum
    {
        None = 0,
        Giap,
        At,
        Binh,
        Dinh,
        Mau,
        Ky,
        Canh,
        Tan,
        Nham,
        Quy
    }

    public enum ChiEnum
    {
        None = 0,
        Ti,
        Suu,
        Dan,
        Mao,
        Thin,
        Ty,
        Ngo,
        Mui, 
        Than,
        Dau,
        Tuat,
        Hoi
    }

    public enum NguHanhEnum
    {
        None = 0,
        Kim,
        Thuy,
        Moc,
        Hoa,
        Tho
    }

    public enum AmDuongEnum
    {
        Am = 0,
        Duong = 1
    }

    public enum GiaiDoanTruongSinhEnum
    {
        None = 0,
        TruongSinh = 1,
        MocDuc = 2,
        QuanDoi = 3,
        LamQuan = 4,
        DeVuong = 5,
        Suy = 6,
        Benh = 7,
        Tu = 8,
        Mo = 9,
        Tuyet = 10,
        Thai = 11,
        Duong = 12

    }

    public enum ThapThanEnum
    {
        None = 0,
        TyKien,
        KiepTai,
        ThucThan,
        ThuongQuan,
        ChinhAn,
        ThienAn,
        ChinhTai,
        ThienTai,
        ChinhQuan,
        ThienQuan
    }

    /// <summary>
    /// DiaChi with name and hidden Can
    /// </summary>
    public class DiaChi
    {
        public ChiEnum Ten { get; private set; }
        public ThienCan BanKhi { get; private set; }
        public ThienCan TrungKhi { get; private set; }
        public ThienCan TapKhi { get; private set; }

        public DiaChi(ChiEnum chi, ThienCan bankhi, ThienCan trungkhi, ThienCan tapkhi)
        {
            this.Ten = chi;
            this.BanKhi = bankhi;
            this.TrungKhi = trungkhi;
            this.TapKhi = tapkhi;
        }
    }

    /// <summary>
    /// ThienCan with name and NguHanh, Am Duong
    /// </summary>
    public class ThienCan
    {
        public CanEnum Can { get; private set; }
        public NguHanhEnum NguHanh { get; private set; }
        public AmDuongEnum AmDuong { get; private set; }
        public ThapThanEnum ThapThan { get; set; }

        private ThienCan(CanEnum can, NguHanhEnum nguHanh, AmDuongEnum amDuong)
        {
            this.Can = can;
            this.NguHanh = nguHanh;
            this.AmDuong = amDuong;
            this.ThapThan = ThapThanEnum.None;
        }

        public ThienCan(CanEnum can)
        {
            this.Can = can;
            Init();
        }

        private void Init()
        {
            switch (this.Can)
            {
                case CanEnum.None:
                    break;
                case CanEnum.Giap:
                    this.NguHanh = NguHanhEnum.Moc;
                    this.AmDuong = AmDuongEnum.Duong;
                    break;
                case CanEnum.At:
                    this.NguHanh = NguHanhEnum.Moc;
                    this.AmDuong = AmDuongEnum.Am;
                    break;
                case CanEnum.Binh:
                    this.NguHanh = NguHanhEnum.Hoa;
                    this.AmDuong = AmDuongEnum.Duong;
                    break;
                case CanEnum.Dinh:
                    this.NguHanh = NguHanhEnum.Hoa;
                    this.AmDuong = AmDuongEnum.Am;
                    break;
                case CanEnum.Mau:
                    this.NguHanh = NguHanhEnum.Tho;
                    this.AmDuong = AmDuongEnum.Duong;
                    break;
                case CanEnum.Ky:
                    this.NguHanh = NguHanhEnum.Tho;
                    this.AmDuong = AmDuongEnum.Am;
                    break;
                case CanEnum.Canh:
                    this.NguHanh = NguHanhEnum.Kim;
                    this.AmDuong = AmDuongEnum.Duong;
                    break;
                case CanEnum.Tan:
                    this.NguHanh = NguHanhEnum.Kim;
                    this.AmDuong = AmDuongEnum.Am;
                    break;
                case CanEnum.Nham:
                    this.NguHanh = NguHanhEnum.Thuy;
                    this.AmDuong = AmDuongEnum.Duong;
                    break;
                case CanEnum.Quy:
                    this.NguHanh = NguHanhEnum.Thuy;
                    this.AmDuong = AmDuongEnum.Am;
                    break;
                default:
                    break;
            }

            this.ThapThan = ThapThanEnum.None;
        }
    }

    /// <summary>
    /// This class contains only 2 sets
    /// one is MuoiHaiDiaChi
    /// the other is MuoiThienCan
    /// </summary>
    public static class TongHopCanChi
    {
        public static List<DiaChi> MuoiHaiDiaChi;
        public static List<ThienCan> MuoiThienCan;

        public static void Init()
        {
            MuoiHaiDiaChi = new List<DiaChi>();
            
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Ti,
                                new ThienCan(CanEnum.Quy), 
                                null, 
                                null));
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Suu,
                                new ThienCan(CanEnum.Ky),
                                new ThienCan(CanEnum.Quy),
                                new ThienCan(CanEnum.Tan)));
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Dan, 
                                new ThienCan(CanEnum.Giap), 
                                new ThienCan(CanEnum.Binh), 
                                new ThienCan(CanEnum.Mau)));
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Mao, 
                                new ThienCan(CanEnum.At), 
                                null, 
                                null));
            
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Thin, 
                                new ThienCan(CanEnum.Mau),
                                new ThienCan(CanEnum.At), 
                                new ThienCan(CanEnum.Quy)));
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Ty, 
                                new ThienCan(CanEnum.Binh), 
                                new ThienCan(CanEnum.Canh), 
                                new ThienCan(CanEnum.Mau)));
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Ngo, 
                                new ThienCan(CanEnum.Dinh), 
                                new ThienCan(CanEnum.Ky), 
                                null));
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Mui, 
                                new ThienCan(CanEnum.Ky), 
                                new ThienCan(CanEnum.Dinh), 
                                new ThienCan(CanEnum.At)));

            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Than,
                                new ThienCan(CanEnum.Canh),
                                new ThienCan(CanEnum.Nham),
                                new ThienCan(CanEnum.Mau)));
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Dau,
                                new ThienCan(CanEnum.Tan), 
                                null, 
                                null));
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Tuat,
                                new ThienCan(CanEnum.Mau),
                                new ThienCan(CanEnum.Tan),
                                new ThienCan(CanEnum.Dinh)));
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Hoi,
                                new ThienCan(CanEnum.Nham),
                                new ThienCan(CanEnum.Giap), 
                                null));

            MuoiThienCan = new List<ThienCan>();

            MuoiThienCan.Add(new ThienCan(CanEnum.Giap));
            MuoiThienCan.Add(new ThienCan(CanEnum.At));

            MuoiThienCan.Add(new ThienCan(CanEnum.Binh));
            MuoiThienCan.Add(new ThienCan(CanEnum.Dinh));

            MuoiThienCan.Add(new ThienCan(CanEnum.Mau));
            MuoiThienCan.Add(new ThienCan(CanEnum.Ky));

            MuoiThienCan.Add(new ThienCan(CanEnum.Canh));
            MuoiThienCan.Add(new ThienCan(CanEnum.Tan));

            MuoiThienCan.Add(new ThienCan(CanEnum.Nham));
            MuoiThienCan.Add(new ThienCan(CanEnum.Quy));
        }
    }

    /// <summary>
    /// Represent one Tru
    /// </summary>
    public class Tru
    {
        public ThienCan ThienCan { get; private set; }
        public DiaChi DiaChi { get; private set; }

        public List<string> CanSao;
        public List<string> ChiSao;
        

        public Tru(ThienCan can, DiaChi chi)
        {
            this.ThienCan = can;
            this.DiaChi = chi;

            this.CanSao = new List<string>();
            this.ChiSao = new List<string>();

        }
    }

}
