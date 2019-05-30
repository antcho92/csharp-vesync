using CSharpVesync.Models.Requests;
using CSharpVesync.Models.Responses;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CSharpVesync
{
    public class VesyncApi : VesyncApiBase
    {
        protected readonly VesyncApiConfiguration _config;

        public VesyncApi(VesyncApiConfiguration config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public async Task<BaseResponse<LoginResult>> LoginAsync()
        {
            var body = new LoginBody
            {
                Email = _config.Email,
                Password = HashPassword(_config.Password),
                Method = "login"
            };

            var response = await BaseUrl
                .AppendPathSegment("/cloud/v1/user/login")
                .WithHeader("Content-Type", "application/json")
                .PostJsonAsync(body)
                .ReceiveString().
                ConfigureAwait(false);

            return JsonConvert.DeserializeObject<BaseResponse<LoginResult>>(response);
        }

        public async Task<BaseResponse<DevicesResult>> GetDevicesAsync(string accountId, string token)
        {
            var body = new DevicesRequest
            {
                Token = token,
                AccountId = accountId,
            };

            return await BaseUrl
                .AppendPathSegment("cloud/v1/deviceManaged/devices")
                .WithHeader("Content-Type", "application/json")
                .PostJsonAsync(body)
                .ReceiveJson<BaseResponse<DevicesResult>>()
                .ConfigureAwait(false);
        }

        private string HashPassword(string password)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }
    }
}
