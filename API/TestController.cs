using System.Security.Claims;
using System.Web.Http;

namespace API
{
    [Route("test")]
    public class TestController : ApiController
    {
        public IHttpActionResult Get()
        {
            var caller = User as ClaimsPrincipal;
            var subjectClaim = caller.FindFirst("sub");
            var identity = ((ClaimsIdentity)caller.Identity);
            

            if (subjectClaim != null)
            {
                //we will only have this claim in hand if it was loaded through the filter
                var emailClaim = ClaimsHelpers.GetClaim("emailaddress", identity);

                return Json(new
                {
                    message = "OK user",
                    client = caller.FindFirst("client_id").Value,
                    email = emailClaim.Value,
                    subject = subjectClaim.Value
                });
            }
            else
            {
                return Json(new
                {
                    message = "OK computer",
                    client = caller.FindFirst("client_id").Value
                });
            }
        }
    }
}