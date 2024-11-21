using System.Web;
using System.Web.Mvc;

namespace K22CNT2_TDD_2210900097_Remake
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
