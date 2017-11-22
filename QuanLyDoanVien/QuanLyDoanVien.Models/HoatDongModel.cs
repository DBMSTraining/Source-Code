using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDoanVien.Models
{
    public class HoatDongModel
    {
        public int MaHD { get; set; }
        public string TenHoatDong { get; set; }
        public int CapHoatDong { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int DiemRenLuyen { get; set; }
        public int DiemCTXH { get; set; }
        public int DiemKetThuc { get; set; }
        public DateTime NgayMoDangky { get; set; }
        public DateTime NgayKetThucDangKy { get; set; }
        public string NoiDung { get; set; }
        public int SoLuong { get; set; }
    }
}
