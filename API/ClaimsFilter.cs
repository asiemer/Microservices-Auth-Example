using System;
using System.Security.Claims;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace API
{
    public class ClaimsFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var caller = actionContext.RequestContext.Principal as ClaimsPrincipal;
            var identity = ((ClaimsIdentity)caller.Identity);
            var userId = ClaimsHelpers.GetUserId(identity);

            //if claims are loaded, carry on -- the majority use case is authenticated traffic
            if (ClaimsHelpers.GetClaim("emailaddress", identity) != null)
            {
                //the claim already exists...party on
            }
            else
            {
                //load claims from somewhere (like in API project currently)

                //use the userId from identity server to load claims in this context (API, or Admin)

                ////add static claim when claim does not exist
                identity.AddClaim(new Claim(ClaimTypes.Email, "asiemer@hotmail.com" + userId));
                
                //the claim should now exist...party on
            }
        }
    }
}