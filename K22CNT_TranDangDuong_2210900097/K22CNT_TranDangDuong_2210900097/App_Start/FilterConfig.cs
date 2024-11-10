using System.Web;
using System.Web.Mvc;

namespace K22CNT_TranDangDuong_2210900097
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
