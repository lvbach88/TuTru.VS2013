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
        public static LinkedList<DiaChi> MuoiHaiDiaChi;
        public static LinkedList<ThienCan> MuoiThienCan;

        public static void Init()
        {
            MuoiHaiDiaChi = new LinkedList<DiaChi>();
            
            MuoiHaiDiaChi.AddLast(new DiaChi(ChiEnum.Ti, CanEnum.Quy, CanEnum.None, CanEnum.None));
            MuoiHaiDiaChi.AddLast(new DiaChi(ChiEnum.Suu, CanEnum.Ky, CanEnum.Quy, CanEnum.Tan));
            MuoiHaiDiaChi.AddLast(new DiaChi(ChiEnum.Dan, CanEnum.Giap, CanEnum.Binh, CanEnum.Mau));
            MuoiHaiDiaChi.AddLast(new DiaChi(ChiEnum.Mao, CanEnum.At, CanEnum.None, CanEnum.None));
            
            MuoiHaiDiaChi.AddLast(new DiaChi(ChiEnum.Thin, CanEnum.Mau, CanEnum.At, CanEnum.Quy));
            MuoiHaiDiaChi.AddLast(new DiaChi(ChiEnum.Ty, CanEnum.Binh, CanEnum.Canh, CanEnum.Mau));
            MuoiHaiDiaChi.AddLast(new DiaChi(ChiEnum.Ngo, CanEnum.Dinh, CanEnum.Ky, CanEnum.None));
            MuoiHaiDiaChi.AddLast(new DiaChi(ChiEnum.Mui, CanEnum.Ky, CanEnum.Dinh, CanEnum.At));

            MuoiHaiDiaChi.AddLast(new DiaChi(ChiEnum.Than, CanEnum.Canh, CanEnum.Nham, CanEnum.Mau));
            MuoiHaiDiaChi.AddLast(new DiaChi(ChiEnum.Dau, CanEnum.Tan, CanEnum.None, CanEnum.None));
            MuoiHaiDiaChi.AddLast(new DiaChi(ChiEnum.Tuat, CanEnum.Mau, CanEnum.Tan, CanEnum.Dinh));
            MuoiHaiDiaChi.AddLast(new DiaChi(ChiEnum.Hoi, CanEnum.Nham, CanEnum.Giap, CanEnum.None));

            MuoiThienCan = new LinkedList<ThienCan>();

            MuoiThienCan.AddLast(new ThienCan(CanEnum.Giap, NguHanhEnum.Moc, AmDuongEnum.Duong));
            MuoiThienCan.AddLast(new ThienCan(CanEnum.At, NguHanhEnum.Moc, AmDuongEnum.Am));

            MuoiThienCan.AddLast(new ThienCan(CanEnum.Binh, NguHanhEnum.Hoa, AmDuongEnum.Duong));
            MuoiThienCan.AddLast(new ThienCan(CanEnum.Dinh, NguHanhEnum.Hoa, AmDuongEnum.Am));

            MuoiThienCan.AddLast(new ThienCan(CanEnum.Mau, NguHanhEnum.Tho, AmDuongEnum.Duong));
            MuoiThienCan.AddLast(new ThienCan(CanEnum.Ky, NguHanhEnum.Tho, AmDuongEnum.Am));

            MuoiThienCan.AddLast(new ThienCan(CanEnum.Canh, NguHanhEnum.Kim, AmDuongEnum.Duong));
            MuoiThienCan.AddLast(new ThienCan(CanEnum.Tan, NguHanhEnum.Kim, AmDuongEnum.Am));

            MuoiThienCan.AddLast(new ThienCan(CanEnum.Nham, NguHanhEnum.Thuy, AmDuongEnum.Duong));
            MuoiThienCan.AddLast(new ThienCan(CanEnum.Quy, NguHanhEnum.Thuy, AmDuongEnum.Am));
        }
    }

    /// <summary>
    /// Represent one Tru
    /// </summary>
    public class Tru
    {
        public CanEnum ThienCan { get; private set; }
        public DiaChi DiaChi { get; private set; }

        public List<string> CanSao;
        public List<string> ChiSao;
        

        public Tru(CanEnum can, DiaChi chi)
        {
            this.ThienCan = can;
            this.DiaChi = chi;

            this.CanSao = new List<string>();
            this.ChiSao = new List<string>();

        }
    }

}
