using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using CSharpVesync.Models;

namespace CSharpVesync
{
    public class VesyncApi
    {
        private const string BaseUrl = "https://smartapi.vesync.com";
        private readonly VesyncApiConfiguration _config;

        public VesyncApi(VesyncApiConfiguration config)
        {
            _config = config;
        }

        public async Task<AccountResponse> GetAccount()
        {
            string encodedPw;

            using (MD5 md5Hash = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(_config.Password));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                encodedPw = sBuilder.ToString();
            }

            var body = new { username = _config.Username, password = encodedPw };

            return await (BaseUrl.AppendPathSegment("/vold/user/login"))
                .PostJsonAsync(body)
                .ReceiveJson<AccountResponse>();
        }

        public void GetDevices()
        {

        }

    }
}
