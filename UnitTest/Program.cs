using Data;
using LookUpTable;
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
            CanChi.Init();
            LookUpTable.LookUpTable.Init();
            var dan = from chi in CanChi.MuoiHaiDiaChi
                      where chi.Ten == Chi.Dan
                      select chi;

            var ngo = CanChi.MuoiHaiDiaChi.Single(u => u.Ten == Chi.Ngo);

            NguHanh nh;
            LookUpTable.LookUpTable.NapAm.TryGetValue(new Tuple<Can, Chi>(Can.At, Chi.None),out nh);

            Console.ReadKey();
        }
    }
}
