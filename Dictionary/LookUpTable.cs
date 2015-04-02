using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class LookUpTable
    {
        /// <summary>
        /// To be used for Tru
        /// Return NguHanh given Can and Chi
        /// </summary>
        public static Dictionary<Tuple<CanEnum, ChiEnum>, NguHanhEnum> NapAm;

        /// <summary>
        /// To be used for Ngu Hanh Tuong Sinh Tuong Khac
        /// Return Sinh, Duoc Sinh, Khac, Bi Khac respectively
        /// </summary>
        public static Dictionary<NguHanhEnum, Tuple<NguHanhEnum, NguHanhEnum, NguHanhEnum, NguHanhEnum>> NguHanhSinhKhac;

        public static void Init()
        {
            napAm_Init();
            nguHanhSinhKhac_Init();
        }

        /// <summary>
        /// Create NapAm dictionary
        /// </summary>
        private static void napAm_Init()
        {
            var napAm = new Dictionary<Tuple<CanEnum, ChiEnum>, NguHanhEnum>();

            //this method will create NapAm table which contains invalid Tru, e.g. At Thin...
            foreach (var diaChi in TongHopCanChi.MuoiHaiDiaChi)
            {
                foreach (var thienCan in TongHopCanChi.MuoiThienCan)
                {
                    switch (diaChi.Ten)
                    {
                        case ChiEnum.Ti:
                        case ChiEnum.Ngo:
                        case ChiEnum.Suu:
                        case ChiEnum.Mui:

                            if (thienCan.Can == CanEnum.Giap || thienCan.Can == CanEnum.At)
                            {
                                napAm.Add(new Tuple<CanEnum, ChiEnum>(thienCan.Can, diaChi.Ten), NguHanhEnum.Kim);
                            }

                            if (thienCan.Can == CanEnum.Binh || thienCan.Can == CanEnum.Dinh)
                            {
                                napAm.Add(new Tuple<CanEnum, ChiEnum>(thienCan.Can, diaChi.Ten), NguHanhEnum.Thuy);
                            }

                            if (thienCan.Can == CanEnum.Mau || thienCan.Can == CanEnum.Ky)
                            {
                                napAm.Add(new Tuple<CanEnum, ChiEnum>(thienCan.Can, diaChi.Ten), NguHanhEnum.Hoa);
                            }

                            if (thienCan.Can == CanEnum.Canh || thienCan.Can == CanEnum.Tan)
                            {
                                napAm.Add(new Tuple<CanEnum, ChiEnum>(thienCan.Can, diaChi.Ten), NguHanhEnum.Moc);
                            }

                            if (thienCan.Can == CanEnum.Nham || thienCan.Can == CanEnum.Quy)
                            {
                                napAm.Add(new Tuple<CanEnum, ChiEnum>(thienCan.Can, diaChi.Ten), NguHanhEnum.Tho);
                            }

                            break;

                        case ChiEnum.Dan:
                        case ChiEnum.Than:
                        case ChiEnum.Mao:
                        case ChiEnum.Dau:
                            
                            if (thienCan.Can == CanEnum.Giap || thienCan.Can == CanEnum.At)
                            {
                                napAm.Add(new Tuple<CanEnum, ChiEnum>(thienCan.Can, diaChi.Ten), NguHanhEnum.Thuy);
                            }

                            if (thienCan.Can == CanEnum.Binh || thienCan.Can == CanEnum.Dinh)
                            {
                                napAm.Add(new Tuple<CanEnum, ChiEnum>(thienCan.Can, diaChi.Ten), NguHanhEnum.Hoa);
                            }

                            if (thienCan.Can == CanEnum.Mau || thienCan.Can == CanEnum.Ky)
                            {
                                napAm.Add(new Tuple<CanEnum, ChiEnum>(thienCan.Can, diaChi.Ten), NguHanhEnum.Tho);
                            }

                            if (thienCan.Can == CanEnum.Canh || thienCan.Can == CanEnum.Tan)
                            {
                                napAm.Add(new Tuple<CanEnum, ChiEnum>(thienCan.Can, diaChi.Ten), NguHanhEnum.Moc);
                            }

                            if (thienCan.Can == CanEnum.Nham || thienCan.Can == CanEnum.Quy)
                            {
                                napAm.Add(new Tuple<CanEnum, ChiEnum>(thienCan.Can, diaChi.Ten), NguHanhEnum.Kim);
                            }

                            break;

                        case ChiEnum.Thin:
                        case ChiEnum.Tuat:
                        case ChiEnum.Ty:
                        case ChiEnum.Hoi:

                            if (thienCan.Can == CanEnum.Giap || thienCan.Can == CanEnum.At)
                            {
                                napAm.Add(new Tuple<CanEnum, ChiEnum>(thienCan.Can, diaChi.Ten), NguHanhEnum.Hoa);
                            }

                            if (thienCan.Can == CanEnum.Binh || thienCan.Can == CanEnum.Dinh)
                            {
                                napAm.Add(new Tuple<CanEnum, ChiEnum>(thienCan.Can, diaChi.Ten), NguHanhEnum.Tho);
                            }

                            if (thienCan.Can == CanEnum.Mau || thienCan.Can == CanEnum.Ky)
                            {
                                napAm.Add(new Tuple<CanEnum, ChiEnum>(thienCan.Can, diaChi.Ten), NguHanhEnum.Moc);
                            }

                            if (thienCan.Can == CanEnum.Canh || thienCan.Can == CanEnum.Tan)
                            {
                                napAm.Add(new Tuple<CanEnum, ChiEnum>(thienCan.Can, diaChi.Ten), NguHanhEnum.Kim);
                            }

                            if (thienCan.Can == CanEnum.Nham || thienCan.Can == CanEnum.Quy)
                            {
                                napAm.Add(new Tuple<CanEnum, ChiEnum>(thienCan.Can, diaChi.Ten), NguHanhEnum.Thuy);
                            }

                            break;
                        default:
                            break;
                    }
                }
            }

            NapAm = napAm;
        }

        private static void nguHanhSinhKhac_Init()
        {
            NguHanhSinhKhac = new Dictionary<NguHanhEnum, Tuple<NguHanhEnum, NguHanhEnum, NguHanhEnum, NguHanhEnum>>();
            NguHanhSinhKhac.Add(NguHanhEnum.Kim,
                new Tuple<NguHanhEnum, NguHanhEnum, NguHanhEnum, NguHanhEnum>(NguHanhEnum.Thuy, NguHanhEnum.Tho, NguHanhEnum.Moc, NguHanhEnum.Hoa));
            NguHanhSinhKhac.Add(NguHanhEnum.Thuy,
                new Tuple<NguHanhEnum, NguHanhEnum, NguHanhEnum, NguHanhEnum>(NguHanhEnum.Moc, NguHanhEnum.Kim, NguHanhEnum.Hoa, NguHanhEnum.Tho));
            NguHanhSinhKhac.Add(NguHanhEnum.Moc,
                new Tuple<NguHanhEnum, NguHanhEnum, NguHanhEnum, NguHanhEnum>(NguHanhEnum.Hoa, NguHanhEnum.Thuy, NguHanhEnum.Tho, NguHanhEnum.Kim));
            NguHanhSinhKhac.Add(NguHanhEnum.Hoa,
                new Tuple<NguHanhEnum, NguHanhEnum, NguHanhEnum, NguHanhEnum>(NguHanhEnum.Tho, NguHanhEnum.Moc, NguHanhEnum.Kim, NguHanhEnum.Thuy));
            NguHanhSinhKhac.Add(NguHanhEnum.Tho,
                new Tuple<NguHanhEnum, NguHanhEnum, NguHanhEnum, NguHanhEnum>(NguHanhEnum.Kim, NguHanhEnum.Hoa, NguHanhEnum.Thuy, NguHanhEnum.Moc));
        }

    }
}
