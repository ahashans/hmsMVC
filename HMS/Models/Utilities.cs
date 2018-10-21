using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace HMS.Models
{
    public static class Utilities
    {
        public static string GetFullName(this IPrincipal usr)
        {
            var fullNameClaim = ((ClaimsIdentity)usr.Identity).FindFirst("FullName");
            if (fullNameClaim != null)
                return fullNameClaim.Value;

            return "";
        }
        public static string GetProfileImagePath(this IPrincipal usr)
        {
                var fullNameClaim = ((ClaimsIdentity)usr.Identity).FindFirst("ProfileImagePath");
            if (fullNameClaim != null)
                if (fullNameClaim.Value != null)
                    return fullNameClaim.Value;
                else
                    return "";
            return "";
        }
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunksize)
        {
            while (source.Any())
            {
                yield return source.Take(chunksize);
                source = source.Skip(chunksize);
            }
        }
    }

}