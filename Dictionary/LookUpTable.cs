using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookUpTable
{
    public static class LookUpTable
    {
        public static Dictionary<Tuple<Can, Chi>, NguHanh> NapAm;

        public static void Init()
        {
            napAm_Init();
        }

        /// <summary>
        /// Create NapAm dictionary
        /// </summary>
        private static void napAm_Init()
        {
            var napAm = new Dictionary<Tuple<Can, Chi>, NguHanh>();

            //this method will create NapAm table which contains invalid Tru, e.g. At Thin...
            foreach (var chi in CanChi.MuoiHaiDiaChi)
            {
                foreach (var can in CanChi.MuoiThienCan)
                {
                    switch (chi.Ten)
                    {
                        case Chi.Ti:
                        case Chi.Ngo:
                        case Chi.Suu:
                        case Chi.Mui:

                            if (can == Can.Giap || can == Can.At)
                            {
                                napAm.Add(new Tuple<Can, Chi>(can, chi.Ten), NguHanh.Kim);
                            }

                            if (can == Can.Binh || can == Can.Dinh)
                            {
                                napAm.Add(new Tuple<Can, Chi>(can, chi.Ten), NguHanh.Thuy);
                            }

                            if (can == Can.Mau || can == Can.Ky)
                            {
                                napAm.Add(new Tuple<Can, Chi>(can, chi.Ten), NguHanh.Hoa);
                            }

                            if (can == Can.Canh || can == Can.Tan)
                            {
                                napAm.Add(new Tuple<Can, Chi>(can, chi.Ten), NguHanh.Moc);
                            }

                            if (can == Can.Nham || can == Can.Quy)
                            {
                                napAm.Add(new Tuple<Can, Chi>(can, chi.Ten), NguHanh.Tho);
                            }

                            break;

                        case Chi.Dan:
                        case Chi.Than:
                        case Chi.Mao:
                        case Chi.Dau:
                            
                            if (can == Can.Giap || can == Can.At)
                            {
                                napAm.Add(new Tuple<Can, Chi>(can, chi.Ten), NguHanh.Thuy);
                            }

                            if (can == Can.Binh || can == Can.Dinh)
                            {
                                napAm.Add(new Tuple<Can, Chi>(can, chi.Ten), NguHanh.Hoa);
                            }

                            if (can == Can.Mau || can == Can.Ky)
                            {
                                napAm.Add(new Tuple<Can, Chi>(can, chi.Ten), NguHanh.Tho);
                            }

                            if (can == Can.Canh || can == Can.Tan)
                            {
                                napAm.Add(new Tuple<Can, Chi>(can, chi.Ten), NguHanh.Moc);
                            }

                            if (can == Can.Nham || can == Can.Quy)
                            {
                                napAm.Add(new Tuple<Can, Chi>(can, chi.Ten), NguHanh.Kim);
                            }

                            break;

                        case Chi.Thin:
                        case Chi.Tuat:
                        case Chi.Ty:
                        case Chi.Hoi:

                            if (can == Can.Giap || can == Can.At)
                            {
                                napAm.Add(new Tuple<Can, Chi>(can, chi.Ten), NguHanh.Hoa);
                            }

                            if (can == Can.Binh || can == Can.Dinh)
                            {
                                napAm.Add(new Tuple<Can, Chi>(can, chi.Ten), NguHanh.Tho);
                            }

                            if (can == Can.Mau || can == Can.Ky)
                            {
                                napAm.Add(new Tuple<Can, Chi>(can, chi.Ten), NguHanh.Moc);
                            }

                            if (can == Can.Canh || can == Can.Tan)
                            {
                                napAm.Add(new Tuple<Can, Chi>(can, chi.Ten), NguHanh.Kim);
                            }

                            if (can == Can.Nham || can == Can.Quy)
                            {
                                napAm.Add(new Tuple<Can, Chi>(can, chi.Ten), NguHanh.Thuy);
                            }

                            break;
                        default:
                            break;
                    }
                }
            }

            NapAm = napAm;
        }

    }
}
