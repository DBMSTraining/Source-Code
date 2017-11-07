using System.Web.Mvc;

namespace QuanLyDoanVien.UI.Areas.FacultyAdmin
{
    public class FacultyAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "FacultyAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "FacultyAdmin_default",
                "FacultyAdmin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}