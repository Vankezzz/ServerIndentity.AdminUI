using Skoruba.IdentityServer4.Shared.Configuration.Configuration.Identity;
using ServerIndentity.STS.Identity.Configuration.Interfaces;

namespace ServerIndentity.STS.Identity.Configuration
{
    public class RootConfiguration : IRootConfiguration
    {      
        public AdminConfiguration AdminConfiguration { get; } = new AdminConfiguration();
        public RegisterConfiguration RegisterConfiguration { get; } = new RegisterConfiguration();
    }
}







