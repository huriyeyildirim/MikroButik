using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IdentityModel.OidcConstants;

namespace MikroButik.Site.Models
{
 
    public class PasswordOwnerCustom : IResourceOwnerPasswordValidator
       
    {
        private readonly IEventService _events;

        public PasswordOwnerCustom(IEventService events )
        {
            this._events = events;
        }
      
        /// <summary>
        /// Validates the resource owner password credential
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public virtual async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {

        //    var result = null;//Kullanıcı durumuna gör egeri bildirim
        //    if (result.Succeeded)
        //    {
        //        
        //        context.Result = new GrantValidationResult(sub, AuthenticationMethods.Password);

        //        return;
        //    }
        //    else if (result.IsLockedOut)
        //        
        //}
        //        else if (result.IsNotAllowed)
        //        {                                                                                  
        //            await _events.RaiseAsync(new UserLoginFailureEvent(context.UserName, "not allowed", interactive: false));
        //        }
        //        else
        //        {                                                                               
        //            await _events.RaiseAsync(new UserLoginFailureEvent(context.UserName, "invalid credentials", interactive: false));
        //        }



context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant);

           

        }
    }
}
