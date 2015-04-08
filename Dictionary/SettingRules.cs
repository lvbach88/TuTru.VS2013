using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class SettingRules
    {

        /// <summary>
        /// Set Thap Than based on "can ngay"
        /// </summary>
        /// <param name="canNgay">to be based on</param>
        /// <param name="can">to set Thap Than property</param>
        public static void SetThapThan(ThienCan canNgay, ThienCan can)
        {
            var sinhKhac = LookUpTable.NguHanhSinhKhac[canNgay.NguHanh];
            var nhSinh = sinhKhac.Item1;
            var nhDuocSinh = sinhKhac.Item2;
            var nhKhac = sinhKhac.Item3;
            var nhBiKhac = sinhKhac.Item4;

            if (can.NguHanh == nhSinh)
            {
                if (canNgay.AmDuong == can.AmDuong)
                {
                    can.ThapThan = ThapThanEnum.ThucThan;
                }
                else
                {
                    can.ThapThan = ThapThanEnum.ThuongQuan;
                }
            }
            else if (can.NguHanh == nhDuocSinh)
            {
                if (canNgay.AmDuong == can.AmDuong)
                {
                    can.ThapThan = ThapThanEnum.ThienAn;
                }
                else
                {
                    can.ThapThan = ThapThanEnum.ChinhAn;
                }
            }
            else if (can.NguHanh == nhKhac)
            {
                if (canNgay.AmDuong == can.AmDuong)
                {
                    can.ThapThan = ThapThanEnum.ThienTai;
                }
                else
                {
                    can.ThapThan = ThapThanEnum.ChinhTai;
                }
            }
            else if (can.NguHanh == nhBiKhac)
            {
                if (canNgay.AmDuong == can.AmDuong)
                {
                    can.ThapThan = ThapThanEnum.ThienQuan;
                }
                else
                {
                    can.ThapThan = ThapThanEnum.ChinhQuan;
                }
            }
            else //same Ngu Hanh
            {
                if (canNgay.AmDuong == can.AmDuong)
                {
                    can.ThapThan = ThapThanEnum.TyKien;
                }
                else
                {
                    can.ThapThan = ThapThanEnum.KiepTai;
                }
            }
        }
    }
}
