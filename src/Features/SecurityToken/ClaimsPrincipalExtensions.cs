﻿namespace DentallApp.Features.SecurityToken;

public static class ClaimsPrincipalExtensions
{
    public static int GetUserId(this ClaimsPrincipal claims)
        => int.Parse(claims.FindFirstValue(CustomClaimsType.UserId));

    public static int GetPersonId(this ClaimsPrincipal claims)
    => int.Parse(claims.FindFirstValue(CustomClaimsType.PersonId));

    public static string GetUserName(this ClaimsPrincipal claims)
        => claims.FindFirstValue(CustomClaimsType.UserName);

    public static int GetOfficeId(this ClaimsPrincipal claims)
        => int.Parse(claims.FindFirstValue(CustomClaimsType.OfficeId));

    public static bool IsAdmin(this ClaimsPrincipal claims)
        => claims.IsInRole(RolesName.Admin);
}
