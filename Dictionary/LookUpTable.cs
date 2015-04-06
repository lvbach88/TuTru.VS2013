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
        /// Return the phase of Vong Truong Sinh given "can ngay" and "chi can tim" 
        /// </summary>
        /// <param name="canNgay">"can ngay"</param>
        /// <param name="chi">"chi can tim"</param>
        /// <returns></returns>
        public static GiaiDoanTruongSinh VongTruongSinh(CanEnum canNgay, ChiEnum chi)
        {
            int direction = 1; //1: forward, -1: backward
            int start = 0;

            switch (canNgay)
            {
                case CanEnum.None:
                    break;
                case CanEnum.Giap:
                    start = 11; //Hoi
                    direction = 1;
                    break;
                case CanEnum.At:
                    start = 6; //Ngo
                    direction = -1;
                    break;
                case CanEnum.Binh:
                case CanEnum.Mau:
                    start = 2; //Dan
                    direction = 1;
                    break;
                case CanEnum.Dinh:
                case CanEnum.Ky:
                    start = 9; //Dau
                    direction = -1;
                    break;
                case CanEnum.Canh:
                    start = 5; //Ty
                    direction = 1;
                    break;
                case CanEnum.Tan:
                    start = 0; //Ti
                    direction = -1;
                    break;
                case CanEnum.Nham:
                    start = 8; //Than
                    direction = 1;
                    break;
                case CanEnum.Quy:
                    start = 3; //Mao
                    direction = -1;
                    break;
                default:
                    break;
            }

            int dest = TongHopCanChi.MuoiHaiDiaChi.FindIndex(u => u.Ten == chi);
            int n = TongHopCanChi.MuoiHaiDiaChi.Count;

            int steps = (direction * (dest - start) + n) % n;

            return (GiaiDoanTruongSinh)(steps + 1); //GiaiDoanTruongSinh starts with 1
        }

        /// <summary>
        /// Find the correct Tru with Can and Chi
        /// </summary>
        /// <param name="canNam">finding is based on canNam</param>
        /// <param name="chiToBeFound">to-be-found Chi</param>
        /// <returns>Tru with Can and Chi</returns>
        public static Tru NguHoDon(CanEnum canNam, ChiEnum chiToBeFound)
        {
            CanEnum canStart = CanEnum.None;
            ChiEnum chiStart = ChiEnum.Dan;

            switch (canNam)
            {
                case CanEnum.None:
                    break;
                case CanEnum.Giap:
                case CanEnum.Ky:
                    canStart = CanEnum.Binh;
                    break;
                case CanEnum.At:
                case CanEnum.Canh:
                    canStart = CanEnum.Mau;
                    break;
                case CanEnum.Binh:
                case CanEnum.Tan:
                    canStart = CanEnum.Canh;
                    break;
                case CanEnum.Dinh:
                case CanEnum.Nham:
                    canStart = CanEnum.Nham;
                    break;
                case CanEnum.Mau:
                case CanEnum.Quy:
                    canStart = CanEnum.Giap;
                    break;
                default:
                    break;
            }

            int nChi = TongHopCanChi.MuoiHaiDiaChi.Count;
            int chiStartIndex = TongHopCanChi.MuoiHaiDiaChi.FindIndex(u => u.Ten == chiStart);
            int chiDestIndex = TongHopCanChi.MuoiHaiDiaChi.FindIndex(u => u.Ten == chiToBeFound);
            int steps = (chiDestIndex - chiStartIndex + nChi) % nChi;

            int canStartIndex = TongHopCanChi.MuoiThienCan.FindIndex(u => u.Can == canStart);
            int nCan = TongHopCanChi.MuoiThienCan.Count;
            int canDestIndex = (canStartIndex + steps) % nCan;


            var thienCan = TongHopCanChi.MuoiThienCan[canDestIndex];
            var diaChi = TongHopCanChi.MuoiHaiDiaChi[chiDestIndex];
            

            return new Tru(thienCan, diaChi);
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
