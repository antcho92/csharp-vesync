﻿using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using CSharpVesync.Models.Responses;

namespace CSharpVesync
{
    public class VesyncApi7A : VesyncApiBase
    {
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

        public async Task<Detail7AResponse> GetDetailsAsync(string id, string accountId, string token)
        {
            var result = await BaseUrl
                .AppendPathSegments("/v1/device/", id, "detail")
                .AddDefaultHeaders(accountId, token)
                .GetAsync()
                .ReceiveString()
                .ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Detail7AResponse>(result);
        }

        public async Task<EnergyResponse7A> GetEnergy(string id, string accountId, string token, EnergyPeriod period)
        {
            var result = await BaseUrl
                .AppendPathSegments("/v1/device/", id, "/energy/", period.ToString())
                .AddDefaultHeaders(accountId, token)
                .GetAsync()
                .ReceiveString()
                .ConfigureAwait(false);

            return JsonConvert.DeserializeObject<EnergyResponse7A>(result);
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
