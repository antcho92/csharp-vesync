using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using CSharpVesync.Models;

namespace CSharpVesync
{
    public class VesyncApi7A : VesyncApi
    {
        public VesyncApi7A(VesyncApiConfiguration config) : base(config)
        {
        }

        public async Task TurnOn(string id, string token, string accountId)
        {
            await (BaseUrl.AppendPathSegments("/v1/wifi-switch-1.3/", id, "/status/on"))
                .WithHeaders(new Headers()
                {
                    Token = token,
                    AccountId = accountId
                })
                .PutAsync(null);
        }

        public async Task TurnOff(string id, string token, string accountId)
        {
            await (BaseUrl.AppendPathSegments("/v1/wifi-switch-1.3/", id, "/status/on"))
                .WithHeaders(new Headers()
                {
                    Token = token,
                    AccountId = accountId
                })
                .PutAsync(null);
        }

        public async Task<ConfigurationsResponse> GetConfig(string id, string token, string accountId)
        {
            return await (BaseUrl.AppendPathSegments("/v1/device/", id, "configurations"))
                .WithHeaders(new Headers()
                {
                    Token = token,
                    AccountId = accountId
                })
                .GetAsync()
                .ReceiveJson<ConfigurationsResponse>();
        }

        public async Task<DetailResponse> GetDetail(string id, string token, string accountId)
        {
            return await (BaseUrl.AppendPathSegments("/v1/device/", id, "detail"))
                .WithHeaders(new Headers()
                {
                    Token = token,
                    AccountId = accountId
                })
                .GetAsync()
                .ReceiveJson<DetailResponse>();
        }
    }
}
