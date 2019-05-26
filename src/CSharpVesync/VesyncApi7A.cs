using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using CSharpVesync.Models;
using Newtonsoft.Json;

namespace CSharpVesync
{
    public class VesyncApi7A : VesyncApi
    {
        public VesyncApi7A(VesyncApiConfiguration config) : base(config)
        {
        }

        public async Task TurnOnOrOff(string id, string accountId, string token, bool TurnOn)
        {
            await BaseUrl
                .AppendPathSegments("/v1/wifi-switch-1.3/", id, "/status/", TurnOn ? "on" : "off")
                .AddDefaultHeaders(accountId, token)
                .PutAsync(null)
                .ConfigureAwait(false);
        }

        public async Task<ConfigurationsResponse> GetConfig(string id, string accountId, string token)
        {
            return await BaseUrl
                .AppendPathSegments("/v1/device/", id, "configurations")
                .AddDefaultHeaders(accountId, token)
                .GetAsync()
                .ReceiveJson<ConfigurationsResponse>()
                .ConfigureAwait(false);
        }

        public async Task<DetailResponse> GetDetailsAsync(string id, string accountId, string token)
        {
            var result = await (BaseUrl.AppendPathSegments("/v1/device/", id, "detail"))
                .AddDefaultHeaders(accountId, token)
                .GetAsync()
                //.ReceiveJson<DetailResponse>()
                .ReceiveString()
                .ConfigureAwait(false);

            return JsonConvert.DeserializeObject<DetailResponse>(result);
        }
    }

    public static class FlurlExtensions
    {
        public static IFlurlRequest AddDefaultHeaders(this Url url, string accountId, string token)
        {
            return url
                .WithHeader(Constants.TokenHeader, token)
                .WithHeader(Constants.AccountIdHeader, accountId);
        }
    }
}
