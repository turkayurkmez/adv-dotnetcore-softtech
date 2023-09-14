using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text.Encodings.Web;

namespace eshop.API.Security
{
    public class BasicHandler : AuthenticationHandler<BasicOption>
    {
        public BasicHandler(IOptionsMonitor<BasicOption> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (Request.Headers.ContainsKey("Authorization"))
            {
                var parameter = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var scheme = parameter.Scheme;
            }
            return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(null, null)));
        }
    }
}
