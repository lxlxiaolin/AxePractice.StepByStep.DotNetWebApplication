using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LocalApi.Routing;

namespace LocalApi
{
    public class HttpServer : HttpMessageHandler
    {
        #region Please implement the following method to pass the test

        /*
         * An http server is an HttpMessageHandler that accept request and create response.
         * You can add non-public fields and members for help but you should not modify
         * the public interfaces.
         */
        public HttpConfiguration Configuration { get; }
        public HttpServer(HttpConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpRoute route = Configuration.Routes.GetRouteData(request);

            return Task.FromResult(route == null
                ? new HttpResponseMessage(HttpStatusCode.NotFound)
                : ControllerActionInvoker.InvokeAction(route, Configuration.CachedControllerTypes, Configuration.DependencyResolver, Configuration.ControllerFactory));
        }

        #endregion
    }
}