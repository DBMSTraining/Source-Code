using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDoanVien.UI.Commons
{
    [Serializable]
    public class UserLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string MaSinhVien { get; set; }
        public string MaChiDoan { get; set; }
        public string MaKhoa { get; set; }
    }
}