using System.Web.Http;
using Owin;
using Thinktecture.IdentityServer.AccessTokenValidation;

namespace API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // accept access tokens from identityserver and require a scope of 'api1'
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://localhost:44333", //this is the URL of the identity server
                RequiredScopes = new[] { "api1" } //this is the key that is provided from the identity server to the calling service
            });

            // configure web api
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            // require authentication for all controllers
            config.Filters.Add(new AuthorizeAttribute());

            // add the claims filter so that all end point access goes through here
            config.Filters.Add(new ClaimsFilter());

            app.UseWebApi(config);
        }
    }
}