using System.Security.Claims;

namespace API
{
    public static class ClaimsHelpers
    {
        public static Claim GetClaim(string name, ClaimsIdentity principal)
        {
            foreach (Claim claim in principal.Claims)
            {
                if (claim.Type.EndsWith(name))
                    return claim;
            }

            return null;
        }

        public static int GetUserId(ClaimsIdentity principal)
        {
            return int.Parse(principal.FindFirst("sub").Value);
        }
    }
}