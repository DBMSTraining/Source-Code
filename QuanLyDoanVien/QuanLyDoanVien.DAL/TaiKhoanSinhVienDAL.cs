using QuanLyDoanVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDoanVien.DAL
{
    public class TaiKhoanSinhVienDAL:SQLProvider
    {
        public TaiKhoanSinhVienModel TaiKhoanSV(string masv)
        {
            var data = Query("sp_TaiKhoanSinhVien", new Dictionary<string, object> {
                {"MaSinhVien", masv }
            });
            if (data != null && data.Rows.Count > 0)
            {
                return new TaiKhoanSinhVienModel
                {
                    MaSinhVien = data.Rows[0]["MaSinhVien"] + string.Empty,
                    TenDangNhap = data.Rows[0]["UserName"] + string.Empty,
                    MatKhauCu = data.Rows[0]["PassWord"] + string.Empty
                };
            }
            return null;
        }

        public bool DoiMatKhau(TaiKhoanSinhVienModel sv)
        {
            string message = "";
            var data = Execute("sp_DoiMatKhauSinhVien", out message, new Dictionary<string, object> {
                { "tenDangNhap", sv.TenDangNhap.Trim() },
                { "matKhau", sv.MatKhauMoi.Trim()}
            });
            return data;
        }
    }
}
