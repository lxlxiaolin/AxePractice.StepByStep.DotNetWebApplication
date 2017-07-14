using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace LocalApi.Routing
{
    public class HttpRouteCollection
    {
        #region Please implement the following method to pass the test

        /*
         * An http route collection stores all the routes for application. You can
         * add additional field or private method but you should not modify the 
         * public interfaces.
         */

        readonly List<HttpRoute> routes = new List<HttpRoute>();
        public void Add(HttpRoute route)
        {
            if(route == null)
            {
                throw new ArgumentNullException(nameof(route));
            }
            if(route .UriTemplate == null)
            {
                throw new ArgumentException();
            }
            routes.Add(route);
        }

        public HttpRoute GetRouteData(HttpRequestMessage request)
        {
            if(request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if(!routes.Any(route => route.IsMatch(request.RequestUri, request.Method)))
            {
                return null;
            }
            var types = routes.Where(route => route.IsMatch(request.RequestUri, request.Method)).ToList();

            return types.Count > 0 ? types.First() : null;
        }

        #endregion
    }
}