using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleSolution.WebApp
{
    public class UsersController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get(string userId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new {message=$"{userId}"});
        }

        [HttpGet]
        public HttpResponseMessage AnotherGet(string userId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new {message=$"{userId}"});
        }
    }
}