﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Amplifier.EntityFrameworkCore.Identity
{
    /// <summary>
    /// Interface for CustomClaimsCookieSignInHelper class
    /// </summary>
    /// <typeparam name="TIdentityUser">Application user class.</typeparam>
    /// <typeparam name="TKey">User primary key type.</typeparam>
    public interface ICustomClaimsCookieSignInHelper<TIdentityUser, TKey> 
        where TIdentityUser : IdentityUser<TKey> 
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Method for SignIn.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="isPersistent">Set whether the authentication session is persisted across multiple requests.</param>
        /// <param name="customClaims">Custom claims.</param>
        /// <returns></returns>
        Task SignInUserAsync(TIdentityUser user, bool isPersistent, IEnumerable<Claim> customClaims);

        /// <summary>
        /// Signs in the specified <paramref name="user"/>.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="authenticationProperties"></param>
        /// <param name="customClaims"></param>
        /// <returns></returns>
        Task SignInUserAsync(TIdentityUser user, AuthenticationProperties authenticationProperties, IEnumerable<Claim> customClaims);

        /// <summary>
        /// Regenerates the user's application cookie, whilst preserving the existing
        /// AuthenticationProperties like rememberMe, as an asynchronous operation.
        /// </summary>
        /// <param name="user">The user whose sign-in cookie should be refreshed.</param>
        /// <param name="tenantId">The Tenant unique identifier.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task RefreshSignInAsync(TIdentityUser user, string tenantId);
    }
}