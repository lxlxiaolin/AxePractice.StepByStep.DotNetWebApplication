using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleSolution.WebApp
{
    public class ResourceController : ApiController
    {
        [AcceptVerbs("GET", "PUT", "POST", "DELETE")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}