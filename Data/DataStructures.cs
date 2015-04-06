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

    public enum GiaiDoanTruongSinh
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

    /// <summary>
    /// DiaChi with name and hidden Can
    /// </summary>
    public class DiaChi
    {
        public ChiEnum Ten { get; private set; }
        public CanEnum BanKhi { get; private set; }
        public CanEnum TrungKhi { get; private set; }
        public CanEnum TapKhi { get; private set; }

        public DiaChi(ChiEnum chi, CanEnum bankhi, CanEnum trungkhi, CanEnum tapkhi)
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

        public ThienCan(CanEnum can, NguHanhEnum nguHanh, AmDuongEnum amDuong)
        {
            this.Can = can;
            this.NguHanh = nguHanh;
            this.AmDuong = amDuong;
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
            
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Ti, CanEnum.Quy, CanEnum.None, CanEnum.None));
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Suu, CanEnum.Ky, CanEnum.Quy, CanEnum.Tan));
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Dan, CanEnum.Giap, CanEnum.Binh, CanEnum.Mau));
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Mao, CanEnum.At, CanEnum.None, CanEnum.None));
            
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Thin, CanEnum.Mau, CanEnum.At, CanEnum.Quy));
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Ty, CanEnum.Binh, CanEnum.Canh, CanEnum.Mau));
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Ngo, CanEnum.Dinh, CanEnum.Ky, CanEnum.None));
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Mui, CanEnum.Ky, CanEnum.Dinh, CanEnum.At));

            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Than, CanEnum.Canh, CanEnum.Nham, CanEnum.Mau));
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Dau, CanEnum.Tan, CanEnum.None, CanEnum.None));
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Tuat, CanEnum.Mau, CanEnum.Tan, CanEnum.Dinh));
            MuoiHaiDiaChi.Add(new DiaChi(ChiEnum.Hoi, CanEnum.Nham, CanEnum.Giap, CanEnum.None));

            MuoiThienCan = new List<ThienCan>();

            MuoiThienCan.Add(new ThienCan(CanEnum.Giap, NguHanhEnum.Moc, AmDuongEnum.Duong));
            MuoiThienCan.Add(new ThienCan(CanEnum.At, NguHanhEnum.Moc, AmDuongEnum.Am));

            MuoiThienCan.Add(new ThienCan(CanEnum.Binh, NguHanhEnum.Hoa, AmDuongEnum.Duong));
            MuoiThienCan.Add(new ThienCan(CanEnum.Dinh, NguHanhEnum.Hoa, AmDuongEnum.Am));

            MuoiThienCan.Add(new ThienCan(CanEnum.Mau, NguHanhEnum.Tho, AmDuongEnum.Duong));
            MuoiThienCan.Add(new ThienCan(CanEnum.Ky, NguHanhEnum.Tho, AmDuongEnum.Am));

            MuoiThienCan.Add(new ThienCan(CanEnum.Canh, NguHanhEnum.Kim, AmDuongEnum.Duong));
            MuoiThienCan.Add(new ThienCan(CanEnum.Tan, NguHanhEnum.Kim, AmDuongEnum.Am));

            MuoiThienCan.Add(new ThienCan(CanEnum.Nham, NguHanhEnum.Thuy, AmDuongEnum.Duong));
            MuoiThienCan.Add(new ThienCan(CanEnum.Quy, NguHanhEnum.Thuy, AmDuongEnum.Am));
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
