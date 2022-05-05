using System.Web;
using System.Web.Mvc;

namespace SFI_Farmacia_Jully
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
