using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace RefreshToken.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetValues()
        {
            return Ok("allow all");
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult GetSecret()
        {
            return Ok("secret");
        }

        [HttpGet]
        public HttpResponseMessage Logout()
        {
            var authentication = HttpContext.Current.GetOwinContext().Authentication;
            authentication.SignOut(DefaultAuthenticationTypes.ExternalBearer);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult CheckUser()
        {
            return Ok(true);
        }
    }
}
