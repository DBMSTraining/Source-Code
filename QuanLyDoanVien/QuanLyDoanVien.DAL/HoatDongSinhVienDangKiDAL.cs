using QuanLyDoanVien.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDoanVien.DAL
{
    public class HoatDongSinhVienDangKiDAL:SQLProvider
    {
        public List<HoatDongSinhVienModel> HoatDongSinhVien(string masinhvien)
        {
            List<HoatDongSinhVienModel> hd = new List<HoatDongSinhVienModel>();
            var data = Query("sp_HoatDongSinhVienDangKy", new Dictionary<string, object> {
                {"MaSinhvien", masinhvien }
            });
            if(data!=null && data.Rows.Count > 0)
            {
               foreach(DataRow dr in data.Rows)
                {
                    int ctxh = 0;
                    int rl = 0;
                    try
                    {
                        ctxh = int.Parse(dr["DiemCTXH"] + string.Empty);
                    }
                    catch(Exception ex){}
                    
                    try
                    {
                        rl = int.Parse(dr["DiemCTXH"] + string.Empty);
                    }
                    catch (Exception ex) { }

                    hd.Add(new HoatDongSinhVienModel
                    {
                        MaHoatDong = int.Parse(dr["MaHD"] + string.Empty),
                        MaSinhVien = dr["MaSV"] + string.Empty,
                        DiemCTXH = ctxh,
                        DiemRenLuyen = rl
                    });
                }
            }
            return hd;
        }
        public bool XoaHoatDongDangky(string masv, int mahd)
        {
            string message = "";
            var data = Execute("sp_XoaDangKihoatDong", out message, new Dictionary<string, object> {
                {"MaSinhVien", masv },
                {"MaHoatDong", mahd }
            });
            return data;
        }
        public HoatDongModel ThongTinHoatDong(int MaHoatDong)
        {
            var data = Query("sp_ThongTinHoatDong", new Dictionary<string, object>
            {
                {"MaHoatDong", MaHoatDong }
            });
            if (data != null && data.Rows.Count > 0)
            {
                int drl = 0;
                int ctxh = 0;
                string nd = "NULL";
                try
                {
                    drl = int.Parse(data.Rows[0]["DiemRenLuyen"] + string.Empty);
                }
                catch (Exception) { }
                try
                {
                    ctxh = int.Parse(data.Rows[0]["DiemCTXH"] + string.Empty);
                }
                catch (Exception) { }
                try
                {
                    nd = data.Rows[0]["NoiDung"] + string.Empty;
                }
                catch (Exception) { }
                return new HoatDongModel
                {
                    MaHD = int.Parse(data.Rows[0]["MaHD"] + string.Empty),
                    TenHoatDong = data.Rows[0]["TenHD"] + string.Empty,
                    CapHoatDong = int.Parse(data.Rows[0]["CapHD"] + string.Empty),
                    NgayBatDau = DateTime.Parse(data.Rows[0]["NgayBatDau"] + string.Empty),
                    NgayKetThuc = DateTime.Parse(data.Rows[0]["NgayKetThuc"] + string.Empty),
                    DiemRenLuyen = drl,
                    DiemCTXH = ctxh,
                    NgayMoDangky = DateTime.Parse(data.Rows[0]["NgayMoDangKi"] + string.Empty),
                    NgayKetThucDangKy = DateTime.Parse(data.Rows[0]["NgayKetThucDangki"] + string.Empty),
                    NoiDung = nd,
                    SoLuong = int.Parse(data.Rows[0]["SoLuong"] + string.Empty)
                };
            }
            return null;
        }
        public List<CapHoatDongModel> CapHD()
        {
            List<CapHoatDongModel> hd = new List<CapHoatDongModel>();
            var data = Query("sp_DanhSachCapHD", new Dictionary<string, object> {});
            if (data != null && data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {

                    hd.Add(new CapHoatDongModel
                    {
                        MaCap = int.Parse(dr["MaCapHD"]+string.Empty),
                        TenCap = dr["TenCapHD"]+string.Empty
                    });
                }
            }
            return hd;
        }

    }
}
