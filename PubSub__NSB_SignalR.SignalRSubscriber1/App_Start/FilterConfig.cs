using System.Web;
using System.Web.Mvc;

namespace PubSub__NSB_SignalR.SignalRSubscriber1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}