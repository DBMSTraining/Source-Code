using QuanLyDoanVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDoanVien.DAL
{
    public class UserDAL : SQLProvider
    {
        // login vao he thong bang tai khoan user
        public static LoginModel Login(LoginModel login)
        {
            var data = Query("sp_user_login", new Dictionary<string, object>
            {
                {"Activity","Login" },
                {"UserName",login.UserName },
                {"Password",login.Password }
            });
            if (data != null && data.Rows.Count > 0)
            {
                return new LoginModel
                {
                    UserName = data.Rows[0]["UserName"] + string.Empty,
                    Password = data.Rows[0]["Password"] + string.Empty,
                    MaSinhVien = data.Rows[0]["MaSinhVien"] + string.Empty,
                    MaKhoa = data.Rows[0]["MaKhoa"] + string.Empty,
                    MaChiDoan = data.Rows[0]["MaChiDoan"] + string.Empty
                };
            }
            return null;
        }

        // update tai khoan user
        public static LoginModel UpdateAccount(LoginModel login)
        {
            var data = Query("Sp_User", new Dictionary<string, object>
            {
                {"Activity","Update" },
                {"UserName",login.UserName },
                {"Password",login.Password }
            });
            if (data != null && data.Rows.Count > 0)
            {
                return new LoginModel
                {
                    UserName = data.Rows[0]["UserName"] + string.Empty,
                    Password = data.Rows[0]["Password"] +
                  string.Empty
                };
            }
            return null;
        }

        // load thong tin cua user (sinh vien)
        public static SinhVienModel LoadProfile(string mssv)
        {
            var data = Query("sp_Profile_User", new Dictionary<string, object>
            {
                {"MaSinhVien",mssv.Trim() }
            });
            if (data != null && data.Rows.Count > 0)
            {
                return new SinhVienModel
                {
                    MaSinhVien = data.Rows[0]["MaSinhVien"] + string.Empty,
                    TenSinhVien = data.Rows[0]["TenSinhVien"] + string.Empty,
                    NgaySinh = int.Parse(data.Rows[0]["NgaySinh"] + string.Empty),
                    ThangSinh = int.Parse(data.Rows[0]["ThangSinh"] + string.Empty),
                    NamSinh = int.Parse(data.Rows[0]["NamSinh"] + string.Empty),
                    GioiTinh = bool.Parse(data.Rows[0]["GioiTinh"] + string.Empty) ,
                    DiaChi = data.Rows[0]["DiaChi"] + string.Empty,
                    MaDanToc = int.Parse(data.Rows[0]["MaDanToc"] + string.Empty),
                    TonGiao = data.Rows[0]["TonGiao"] + string.Empty,
                    DienThoai = data.Rows[0]["DienThoai"] + string.Empty,
                    Email = data.Rows[0]["Email"] + string.Empty,
                    CMND = data.Rows[0]["CMND"] + string.Empty,
                    MaChiDoan = data.Rows[0]["MaChiDoan"] + string.Empty,
                    MaTinhThanhPho = int.Parse(data.Rows[0]["MaTinhThanhPho"] + string.Empty),
                    MaQuanHuyen = int.Parse(data.Rows[0]["MaQuanHuyen"] + string.Empty),
                    MaPhuongXa = int.Parse(data.Rows[0]["MaPhuongXa"] + string.Empty),
                    Hinh = data.Rows[0]["Hinh"] + string.Empty
                };
            }
            return null;
        }
    }
}
