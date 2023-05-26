using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace UsuariosApi.Authorization
{
    public class AgeAuthorization : AuthorizationHandler<MinimumAge>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAge requirement)
        {
            var datebirthClaim = context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);

            if (datebirthClaim is null )
                return Task.CompletedTask;

            var datebirth = Convert.ToDateTime(datebirthClaim.Value);

            int userAge = DateTime.Today.Year - datebirth.Year;

            if (datebirth > DateTime.Today.AddYears(-userAge))
                userAge--;

            if (userAge >= requirement.Idade)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
