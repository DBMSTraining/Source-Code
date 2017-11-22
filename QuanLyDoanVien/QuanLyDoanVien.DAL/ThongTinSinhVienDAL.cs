using QuanLyDoanVien.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDoanVien.DAL
{
    public class ThongTinSinhVienDAL:SQLProvider
    {
        public SinhVienModel ThongTinSinhVien(string masv)
        {
            var data = Query("sp_ThongTinSinhVienTuView", new Dictionary<string, object>
            {
                { "MaSinhVien", masv }
            });
            if(data!=null && data.Rows.Count > 0)
            {
                return new SinhVienModel
                {
                    TenSinhVien = data.Rows[0]["TenSinhVien"] + string.Empty,
                    MaSinhVien = data.Rows[0]["MaSinhVien"] + string.Empty,
                    NgaySinh = int.Parse(data.Rows[0]["NgaySinh"] + string.Empty),
                    ThangSinh = int.Parse(data.Rows[0]["ThangSinh"] + string.Empty),
                    NamSinh = int.Parse(data.Rows[0]["NamSinh"] + string.Empty),
                    GioiTinh = bool.Parse(data.Rows[0]["GioiTinh"] + string.Empty),
                    DiaChi = data.Rows[0]["DiaChi"] + string.Empty,
                    MaDanToc =int.Parse( data.Rows[0]["MadanToc"] + string.Empty),
                    TonGiao = data.Rows[0]["TonGiao"] + string.Empty,
                    DienThoai = data.Rows[0]["DienThoai"] + string.Empty,
                    Email = data.Rows[0]["Email"] + string.Empty,
                    CMND = data.Rows[0]["CMND"] + string.Empty,
                    Hinh = data.Rows[0]["Hinh"] + string.Empty,
                    TinhTrangHD = bool.Parse(data.Rows[0]["TinhTrangHD"] + string.Empty),
                    MaKhoa = data.Rows[0]["MaKhoa"]+string.Empty
                };
            }
            return null;
        }

        public bool CapNhatThongTin(SinhVienModel sv)
        {
            string message = "";
            var data = Execute("sp_CapNhatThongTinCaNhanSinhVien",out message, new Dictionary<string, object> {
                { "MaSinhVien", sv.MaSinhVien.Trim() },
                { "TenSinhVien", sv.TenSinhVien},
                { "NgaySinh", sv.NgaySinh },
                { "ThangSinh", sv.ThangSinh },
                { "NamSinh", sv.NamSinh },
                { "GioiTinh", sv.GioiTinh },
                { "DiaChi", sv.DiaChi},
                { "MaDanToc", sv.MaDanToc },
                { "TonGiao", sv.TonGiao},
                { "DienThoai", sv.DienThoai},
                { "Email", sv.Email.Trim() },
                { "CMND", sv.CMND },
                { "MaChiDoan", sv.MaChiDoan.Trim() },
                { "MaTinhThanhPho", sv.MaTinhThanhPho },
                { "MaQuanHuyen", sv.MaQuanHuyen },
                { "MaPhuongXa", sv.MaPhuongXa },
                { "Hinh", sv.Hinh.Trim()},
                { "TinhTrangHD", sv.TinhTrangHD }

            });
            return data;
        }
     
        public List<DoanKhoaModel> DoanKhoa()
        {
            List<DoanKhoaModel> doanKhoa = new List<DoanKhoaModel>();
            var data = Query("sp_ThongTinKhoaChoSinhVien", null);
            if(data!=null && data.Rows.Count > 0)
            {
                foreach(DataRow dr in data.Rows)
                {
                    doanKhoa.Add(new DoanKhoaModel
                    {
                        MaKhoa = dr["MaKhoa"] + string.Empty,
                        TenKhoa = dr["TenKhoa"] + string.Empty
                    });
                }
            }
            return doanKhoa;
        }
        public List<ChiDoanModel> ChiDoan()
        {
            List<ChiDoanModel> chidoan = new List<ChiDoanModel>();
            var data = Query("sp_ThongTinChiDoanChoSinhVien", null);
            if (data != null && data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    chidoan.Add(new ChiDoanModel
                    {
                        MaChiDoan = dr["MaChiDoan"] + string.Empty,
                        TenChiDoan = dr["TenChiDoan"] + string.Empty
                    });
                }
            }
            return chidoan;
        }
        public List<TinhThanhPhoModel> TinhThanhPho()
        {
            List<TinhThanhPhoModel> tinhthanh = new List<TinhThanhPhoModel>();
            var data = Query("sp_ThongTinTinhThanhPhoChoSinhVien", null);
            if (data != null && data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    tinhthanh.Add(new TinhThanhPhoModel
                    {
                        MaTinh = int.Parse(dr["MaTinhThanhPho"] + string.Empty),
                        TenTinhThanhPho = dr["TenTinh"] + string.Empty
                    });
                }
            }
            return tinhthanh;
        }
        public List<PhuongXaModel> PhuongXa()
        {
            List<PhuongXaModel> phuongxa = new List<PhuongXaModel>();
            var data = Query("sp_ThongTinPhuongXaChoSinhVien", null);
            if (data != null && data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    phuongxa.Add(new PhuongXaModel
                    {
                        MaPhuongXa = int.Parse(dr["MaPhuongXa"] + string.Empty),
                        TenPhuongXa = dr["TenPhuongXa"] + string.Empty
                    });
                }
            }
            return phuongxa;
        }
        public List<QuanHuyenModel> QuanHuyen()
        {
            List<QuanHuyenModel> quanhuyen = new List<QuanHuyenModel>();
            var data = Query("sp_ThongTinQuanHuyenChoSinhVien", null);
            if (data != null && data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    quanhuyen.Add(new QuanHuyenModel
                    {
                        MaQuanHuyen = int.Parse(dr["MaQuanHuyen"] + string.Empty),
                        TenQuanHuyen = dr["TenQuanHuyen"] + string.Empty
                    });
                }
            }
            return quanhuyen;
        }

        public List<DanTocModel> DanToc()
        {
            List<DanTocModel> dantoc = new List<DanTocModel>();
            var data = Query("sp_ThongTinDanTocChoSinhVien", null);
            if (data != null && data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    dantoc.Add(new DanTocModel
                    {
                        MaDanToc = int.Parse(dr["MaDanToc"] + string.Empty),
                        TenDanToc = dr["TenDanToc"] + string.Empty
                    });
                }
            }
            return dantoc;
        }

        public HoSoDoanModel HoSoDoan(string masv)
        {
            var data = Query("sp_HoSoDoanSinhVien", new Dictionary<string, object>
            {
                { "MaSinhVien", masv }
            });
            if (data != null && data.Rows.Count > 0)
            {
                return new HoSoDoanModel
                {
                    MaHoSo = int.Parse(data.Rows[0]["MaHoSo"] + string.Empty),
                    NgayCap = DateTime.Parse(data.Rows[0]["NgayCap"] + string.Empty),
                    NoiCap = data.Rows[0]["NoiCap"] + string.Empty,
                    NgayVaoDoan = DateTime.Parse(data.Rows[0]["NgayVaoDoan"] + string.Empty)
                };
            }
            return null;
        }
        public int TongDiemCTXH(string masv)
        {
            ThongTinSinhVienDAL db = new ThongTinSinhVienDAL();
            SqlParameter maMax = new SqlParameter("maMax", SqlDbType.Int);
            maMax.Direction = ParameterDirection.InputOutput;
            maMax.Value = 0;
            db.ExecuteQueryDataSetWithPra("sp_TinhDienCTXHSinhVien", CommandType.StoredProcedure, maMax);
            return (int)maMax.Value;

        }
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
                    MatKhauCu = data.Rows[0]["PassWord"] + string.Empty,
                };
            }
            return null;
        }

    }
}
