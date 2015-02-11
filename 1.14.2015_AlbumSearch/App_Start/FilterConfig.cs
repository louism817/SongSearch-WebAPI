using System.Web;
using System.Web.Mvc;

namespace _1._14._2015_AlbumSearch
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
