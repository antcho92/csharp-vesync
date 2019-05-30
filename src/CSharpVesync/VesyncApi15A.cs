using System.Threading.Tasks;
using CSharpVesync.Models;
using CSharpVesync.Models.Requests;
using CSharpVesync.Models.Responses;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;

namespace CSharpVesync
{
    public class VesyncApi15A : VesyncApiBase
    {
        public async Task<Detail15AResponse> GetDetailsAsync(string id, string accountId, string token)
        {
            var body = new DetailRequest
            {
                Uuid = id,
                AccountId = accountId,
                Token = token
            };

            var result = await BaseUrl
                .AppendPathSegments("15a/v1/device/devicedetail")
                .PostJsonAsync(body)
                .ReceiveString()
                .ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Detail15AResponse>(result);
        }
        public async Task<BaseResponse<object>> TurnOnOrOff(string id, string accountId, string token, bool turnOn)
        {
            var body = new DeviceStatusRequest
            {
                Uuid = id,
                AccountId = accountId,
                Token = token,
                Status = turnOn ? "on" : "off"
            };

            var response = await BaseUrl
                .AppendPathSegments("15a/v1/device/devicestatus")
                .PutJsonAsync(body)
                .ReceiveString()
                .ConfigureAwait(false);

            return JsonConvert.DeserializeObject<BaseResponse<object>>(response);
        }

        public async Task<EnergyResponse15A> GetEnergy(string id, string accountId, string token, EnergyPeriod period)
        {
            var body = new RequestBody()
            {
                Uuid = id,
                Token = token,
                AccountId = accountId
            };

            var result = await BaseUrl
                .AppendPathSegments($"15a/v1/device/energy{period.ToString()}")
                .PostJsonAsync(body)
                .ReceiveString()
                .ConfigureAwait(false);

            return JsonConvert.DeserializeObject<EnergyResponse15A>(result);
        }
    }
}
