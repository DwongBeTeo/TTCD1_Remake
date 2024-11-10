using System.Web.Mvc;

namespace K22CNT_TranDangDuong_2210900097.Areas.AdminTDD
{
    public class AdminTDDAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminTDD";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminTDD_default",
                "AdminTDD/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}