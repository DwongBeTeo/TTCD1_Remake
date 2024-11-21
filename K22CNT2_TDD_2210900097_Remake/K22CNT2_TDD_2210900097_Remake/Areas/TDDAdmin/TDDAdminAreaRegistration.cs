using System.Web.Mvc;

namespace K22CNT2_TDD_2210900097_Remake.Areas.TDDAdmin
{
    public class TDDAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TDDAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TDDAdmin_default",
                "TDDAdmin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}