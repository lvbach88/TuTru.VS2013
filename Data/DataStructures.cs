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
        None = 0,
        Am,
        Duong
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

    public enum GioiTinhEnum
    {
        None = 0,
        Nu,
        Nam
    }

    public enum SinhKhac
    {
        None = 0,
        Sinh,
        Khac
    }

    public class TruCanChiBase
    {
        public Dictionary<string, object> ThuocTinh { get; set; }
        public Dictionary<string, object> ThanSat { get; set; }

        public TruCanChiBase()
        {
            this.ThuocTinh = new Dictionary<string, object>();
            this.ThanSat = new Dictionary<string, object>();
        }

        public void AddThanSat(string thansat)
        {
            if (!this.ThanSat.ContainsKey(thansat))
            {
                this.ThanSat.Add(thansat, thansat);
            }
        }
    }

    /// <summary>
    /// DiaChi with name and hidden Can
    /// </summary>
    public class DiaChi : TruCanChiBase
    {
        public ChiEnum Ten { get; private set; }
        public ThienCan BanKhi { get; private set; }
        public ThienCan TrungKhi { get; private set; }
        public ThienCan TapKhi { get; private set; }
        
        public DiaChi(ChiEnum chi, ThienCan bankhi, ThienCan trungkhi, ThienCan tapkhi) : base()
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
    public class ThienCan : TruCanChiBase
    {
        public CanEnum Can { get; private set; }
        public NguHanhEnum NguHanh { get; private set; }
        public AmDuongEnum AmDuong { get; private set; }
        public ThapThanEnum ThapThan { get; set; }

        public ThienCan(CanEnum can) : base()
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
            #region MuoiThienCan

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
            #endregion MuoiThienCan

            #region MuoiHaiDiaChi

            MuoiHaiDiaChi = new List<DiaChi>();

            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Ti,
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.Quy),//new ThienCan(CanEnum.Quy), 
                                null,
                                null));
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Suu,
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.Ky), //new ThienCan(CanEnum.Ky),
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.Quy), //new ThienCan(CanEnum.Quy),
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.Tan) //new ThienCan(CanEnum.Tan)
                                ));
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Dan,
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.Giap),//new ThienCan(CanEnum.Giap), 
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.Binh),//new ThienCan(CanEnum.Binh), 
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.Mau)//new ThienCan(CanEnum.Mau)
                                ));
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Mao,
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.At), //new ThienCan(CanEnum.At), 
                                null,
                                null));

            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Thin,
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.Mau), //new ThienCan(CanEnum.Mau),
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.At), //new ThienCan(CanEnum.At), 
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.Quy) //new ThienCan(CanEnum.Quy)
                                ));
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Ty,
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.Binh), //new ThienCan(CanEnum.Binh), 
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.Canh), //new ThienCan(CanEnum.Canh), 
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.Mau) //, new ThienCan(CanEnum.Mau)
                                ));
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Ngo,
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.Dinh), //new ThienCan(CanEnum.Dinh), 
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.Ky), //new ThienCan(CanEnum.Ky), 
                                null));
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Mui,
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.Ky), //new ThienCan(CanEnum.Ky), 
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.Dinh), //new ThienCan(CanEnum.Dinh), 
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.At) //, new ThienCan(CanEnum.At)
                                ));

            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Than,
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.Canh), //new ThienCan(CanEnum.Canh),
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.Nham), //new ThienCan(CanEnum.Nham),
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.Mau) //, new ThienCan(CanEnum.Mau)
                                ));
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Dau,
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.Tan), //new ThienCan(CanEnum.Tan), 
                                null,
                                null));
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Tuat,
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.Mau), //new ThienCan(CanEnum.Mau),
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.Tan), //new ThienCan(CanEnum.Tan),
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.Dinh) //, new ThienCan(CanEnum.Dinh)
                                ));
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Hoi,
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.Nham), //new ThienCan(CanEnum.Nham),
                                MuoiThienCan.Single<ThienCan>(u => u.Can == CanEnum.Giap), //new ThienCan(CanEnum.Giap), 
                                null));
            #endregion MuoiHaiDiaChi

        }
    }

    /// <summary>
    /// Represent one Tru
    /// </summary>
    public class Tru : TruCanChiBase
    {
        public ThienCan ThienCan { get; private set; }
        public DiaChi DiaChi { get; private set; }

        public Tru(ThienCan can, DiaChi chi) : base()
        {
            this.ThienCan = can;
            this.DiaChi = chi;
        }
    }

    public class LaSo
    {
        public GioiTinhEnum GioiTinh { get; set; }
        public Dictionary<string, Tru> TuTru { get; set; }
        public List<Tru> DaiVan { get; set; }
        public List<Tru> TieuVan { get; set; }
        public List<int> TuoiDaiVan { get; set; }
        public Tru CungMenh { get; set; }
        public Tru ThaiNguyen { get; set; }

        public LaSo()
        {
            GioiTinh = GioiTinhEnum.None;
            TuTru = new Dictionary<string, Tru>();
            DaiVan = new List<Tru>();
            TieuVan = new List<Tru>();
            TuoiDaiVan = new List<int>();
        }
    }

}
