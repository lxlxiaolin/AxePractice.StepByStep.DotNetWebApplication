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
        readonly HttpConfiguration configuration;

        public HttpServer(HttpConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task<HttpResponseMessage> Process(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            return SendAsync(request, cancellationToken);
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            HttpRoute matchedRoute = configuration.Routes.GetRouteData(request);
            if (matchedRoute == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            HttpResponseMessage response = default(HttpResponseMessage);
            try
            {
                request.SetRequestContext(configuration, matchedRoute);
                response = await ControllerActionInvoker.InvokeAction(request);
                return response;
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                configuration.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}