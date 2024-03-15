using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace UserApi.Authorization;

public class AgeAuthorization : AuthorizationHandler<MinimumAge>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAge requirement)
    {
        var DateBirthClaim = context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);

        if (DateBirthClaim is null)
            return Task.CompletedTask;

        var DateBirth = Convert.ToDateTime(DateBirthClaim.Value);
        var AgeUser = DateTime.Today.Year - DateBirth.Year;

        if(DateBirth > DateTime.Today.AddYears(-AgeUser))
            AgeUser--;

        if (AgeUser >= requirement.Age)
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}
