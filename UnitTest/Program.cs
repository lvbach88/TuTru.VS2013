using Data;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TongHopCanChi.Init();
            LookUpTable.Init();
            var dan = from chi in TongHopCanChi.MuoiHaiDiaChi
                      where chi.Ten == ChiEnum.Dan
                      select chi;

            var ngo = TongHopCanChi.MuoiHaiDiaChi.Single(u => u.Ten == ChiEnum.Ngo);

            //NguHanhEnum nh;
            //LookUpTable.NapAm.TryGetValue(new Tuple<CanEnum, ChiEnum>(CanEnum.At, ChiEnum.None),out nh);

            var vts = LookUpTable.VongTruongSinh(CanEnum.Quy, ChiEnum.Mao);

            var truNguHoDon = LookUpTable.NguHoDon(CanEnum.Quy, ChiEnum.Hoi);

            var truNguThuDon = LookUpTable.NguThuDon(CanEnum.Quy, ChiEnum.Hoi);

            var canNgay = new ThienCan(CanEnum.At);
            var can = new ThienCan(CanEnum.Giap);

            SettingRules.SetThapThan(canNgay, can);

            Console.ReadKey();
        }
    }
}
