using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MikroButik.Common
{        /// <summary>
/// 
/// </summary>
    public class IdentityConfig
    {
        public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope> { new ApiScope("ButikApi", "Butik Data Transfer", new List<string>() { JwtClaimTypes.Email, JwtClaimTypes.Name, JwtClaimTypes.FamilyName, JwtClaimTypes.GivenName }),
                             new ApiScope("openid", "Butik Data Transfer", new List<string>() { JwtClaimTypes.Email, JwtClaimTypes.Name, JwtClaimTypes.FamilyName, JwtClaimTypes.GivenName })};

         /// <summary>
         /// 
         /// </summary>
        public static IEnumerable<Client> Clients => new List<Client>{   new Client
        {

                Enabled = true,
                ClientName = "ButikBackClient",
                ClientId = "ButikBackClient",
                RedirectUris = new  List<string>(){ "https://localhost:44398/signin-oidc", "http://localhost:60478/signin-oidc","https://localhost:44375/swagger/oauth2-redirect.html" },
                ClientSecrets = new List<Secret> {
                new Secret("fa153-xf98-trs26-mm74".Sha256(), "fa153-xf98-trs26-mm74")  },  
                AllowOfflineAccess = true,
                RequireConsent = false,
                AllowedScopes = new List<string>{
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,"ButikApi"},
                AllowedGrantTypes = IdentityServer4.Models.GrantTypes.CodeAndClientCredentials

        }};
    }


}
