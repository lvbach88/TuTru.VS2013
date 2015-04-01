using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{

    public enum Can
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

    public enum Chi
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

    public class DiaChi
    {
        public Chi Ten { get; private set; }
        public Can BanKhi { get; private set; }
        public Can TrungKhi { get; private set; }
        public Can TapKhi { get; private set; }

        public DiaChi(Chi chi, Can bankhi, Can trungkhi, Can tapkhi)
        {
            this.Ten = chi;
            this.BanKhi = bankhi;
            this.TrungKhi = trungkhi;
            this.TapKhi = tapkhi;
        }
    }

    public static class CanChi
    {
        public static LinkedList<DiaChi> MuoiHaiDiaChi;
        public static LinkedList<Can> MuoiThienCan;

        public static void Init()
        {
            MuoiHaiDiaChi = new LinkedList<DiaChi>();
            
            MuoiHaiDiaChi.AddLast(new DiaChi(Chi.Ti, Can.Quy, Can.None, Can.None));
            MuoiHaiDiaChi.AddLast(new DiaChi(Chi.Suu, Can.Ky, Can.Quy, Can.Tan));
            MuoiHaiDiaChi.AddLast(new DiaChi(Chi.Dan, Can.Giap, Can.Binh, Can.Mau));
            MuoiHaiDiaChi.AddLast(new DiaChi(Chi.Mao, Can.At, Can.None, Can.None));
            
            MuoiHaiDiaChi.AddLast(new DiaChi(Chi.Thin, Can.Mau, Can.At, Can.Quy));
            MuoiHaiDiaChi.AddLast(new DiaChi(Chi.Ty, Can.Binh, Can.Canh, Can.Mau));
            MuoiHaiDiaChi.AddLast(new DiaChi(Chi.Ngo, Can.Dinh, Can.Ky, Can.None));
            MuoiHaiDiaChi.AddLast(new DiaChi(Chi.Mui, Can.Ky, Can.Dinh, Can.At));

            MuoiHaiDiaChi.AddLast(new DiaChi(Chi.Than, Can.Canh, Can.Nham, Can.Mau));
            MuoiHaiDiaChi.AddLast(new DiaChi(Chi.Dau, Can.Tan, Can.None, Can.None));
            MuoiHaiDiaChi.AddLast(new DiaChi(Chi.Tuat, Can.Mau, Can.Tan, Can.Dinh));
            MuoiHaiDiaChi.AddLast(new DiaChi(Chi.Hoi, Can.Nham, Can.Giap, Can.None));

            MuoiThienCan = new LinkedList<Can>();

            MuoiThienCan.AddLast(Can.Giap);
            MuoiThienCan.AddLast(Can.At);
            MuoiThienCan.AddLast(Can.Binh);
            MuoiThienCan.AddLast(Can.Dinh);

            MuoiThienCan.AddLast(Can.Mau);
            MuoiThienCan.AddLast(Can.Ky);
            MuoiThienCan.AddLast(Can.Canh);
            MuoiThienCan.AddLast(Can.Tan);

            MuoiThienCan.AddLast(Can.Nham);
            MuoiThienCan.AddLast(Can.Quy);
        }
    }

}
