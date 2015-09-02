using System.Collections.Generic;
using Thinktecture.IdentityServer.Core.Services.InMemory;

namespace IdentityServer
{
    static class Users
    {
        //this can be swapped out for other implementations
        //there is an auth provider for MVC
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>
        {
            new InMemoryUser
            {
                Username = "bob",
                Password = "secret",
                Subject = "1"
            },
            new InMemoryUser
            {
                Username = "alice",
                Password = "secret",
                Subject = "2"
            }
        };
        }
    }
}
