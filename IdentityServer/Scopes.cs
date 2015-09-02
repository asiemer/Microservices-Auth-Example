using System.Collections.Generic;
using Thinktecture.IdentityServer.Core.Models;

namespace IdentityServer
{
    static class Scopes
    {
        public static List<Scope> Get()
        {
            return new List<Scope>
            {
                //the service that is calling to authenticate
                //one entry here per service that is dependent on the identity server
                new Scope()
                {
                    Name = "api1"
                }
            };
        }
    }
}
