using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace RefreshTokenWeb.Providers
{
    public class AuthorizationProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                //var user = db.TB_Users.Where(u => u.UserName == context.UserName && u.Password1 == context.Password).FirstOrDefault();
                var validatedUser = (context.UserName == "satadmin" && context.Password == "1234");

                if (!validatedUser)
                {
                    context.SetError("invalid_grant", "The username or password is incorrect.");
                    context.Rejected();
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                context.Validated(identity);
            }
            catch (Exception ex)
            {
                context.SetError("Login failed", "Login failed for user");
            }
        }
    }
}
