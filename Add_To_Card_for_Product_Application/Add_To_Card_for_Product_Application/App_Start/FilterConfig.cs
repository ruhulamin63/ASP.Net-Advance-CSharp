using System.Web;
using System.Web.Mvc;

namespace Add_To_Card_for_Product_Application
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
