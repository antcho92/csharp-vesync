using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpVesync.Models;

namespace CSharpVesync.VesyncApiIntegrationTests
{
    public class TestBase
    {
        protected static VesyncApiConfiguration Configuration;
        protected VesyncApi Api;
        protected BaseResponse<LoginResult> Account;

        protected static void LoadConfig()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddUserSecrets("84115b8b-ed4e-4034-b9b4-31fb40357502")
                .Build();

            Configuration = config.GetSection(nameof(VesyncApiConfiguration)).Get<VesyncApiConfiguration>();
        }

        public async Task Initialize()
        {
            Api = new VesyncApi(Configuration);
            Account = await Api.LoginAsync();
        }
    }
}