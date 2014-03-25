using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace PubSub__NSB_SignalR.SignalRSubscriber1.Infrastructure
{
    public class NServiceBusControllerActivator : IControllerActivator
    {
        public IController Create(RequestContext requestContext, Type controllerType)
        {
            return DependencyResolver.Current.GetService(controllerType) as IController;
        }
    }
}
