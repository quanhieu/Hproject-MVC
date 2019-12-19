using System.Web;
using System.Web.Mvc;

namespace HProject
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute()); //yêu cầu đăng nhập mới được dùng các tính năng (technically, gọi các actions)
        }
    }
}
