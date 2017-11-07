using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDoanVien.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "UserName is required")]
        [Key]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string MaKhoa { get; set; }
        public string MaChiDoan { get; set; }
        public string MaSinhVien { get; set; }
    }
}
