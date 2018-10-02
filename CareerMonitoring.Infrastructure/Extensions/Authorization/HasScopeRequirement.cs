using System;
using Microsoft.AspNetCore.Authorization;

namespace CareerMonitoring.Infrastructure.Extension.JWT
{
    public class HasScopeRequirement : IAuthorizationRequirement
    {
        public string Issuer { get; }
        public string Scope { get; }
        
        public HasScopeRequirement(string issuer, string scope)
        {
            Scope = scope ?? throw new ArgumentNullException(nameof(scope));
            Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
        }
        
    }
}