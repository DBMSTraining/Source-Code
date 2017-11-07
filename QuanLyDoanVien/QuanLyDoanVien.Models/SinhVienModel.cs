using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDoanVien.Models
{
    public class SinhVienModel
    {
        [Key]
        [StringLength(10)]
        public string MaSinhVien { get; set; }

        public string TenSinhVien { get; set; }

        public int? NgaySinh { get; set; }

        public int? ThangSinh { get; set; }

        public int? NamSinh { get; set; }

        public string GioiTinh { get; set; }

        public string DiaChi { get; set; }

        public int? MaDanToc { get; set; }

        public string TonGiao { get; set; }

        [StringLength(11)]
        public string DienThoai { get; set; }

        public string Email { get; set; }

        [StringLength(10)]
        public string CMND { get; set; }

        [StringLength(10)]
        public string MaChiDoan { get; set; }

        public int? MaTinhThanhPho { get; set; }

        public int? MaQuanHuyen { get; set; }

        public int? MaPhuongXa { get; set; }

        public string Hinh { get; set; }
    }
}
