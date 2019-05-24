using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using CSharpVesync.Models;
using System.Diagnostics.CodeAnalysis;

namespace CSharpVesync.VesyncApiIntegrationTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class VesyncApiIntegrationTests
    {
        private static VesyncApiConfiguration Configuration;
        private VesyncApi _api;
        private BaseResponse<LoginResult> _account;

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddUserSecrets("84115b8b-ed4e-4034-b9b4-31fb40357502")
                .Build();

            Configuration = config.GetSection(nameof(VesyncApiConfiguration)).Get<VesyncApiConfiguration>();
        }

        [TestInitialize]
        public void Initialize()
        {
            _api = new VesyncApi(Configuration);
            _account = _api.LoginAsync().Result;
        }

        [TestMethod]
        public void LoginAsync_GivenValidCredentials_ReturnsTokenAndAccountId()
        {
            var api = new VesyncApi(Configuration);
            var account = api.LoginAsync().Result;
            account.Result.Should().NotBeNull();
            account.Result.Token.Should().NotBeNullOrWhiteSpace();
            account.Result.AccountId.Should().NotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public void GetDevices_GivenValidCredentials_ReturnsTokenAndAccountId()
        {
            var devicesResponse = _api.GetDevicesAsync(_account.Result.AccountId, _account.Result.Token).Result;
            devicesResponse.Result.Should().NotBeNull();
            devicesResponse.Result.Total.Should().NotBe(0);
            devicesResponse.Result.List.Should().NotBeNullOrEmpty();
            devicesResponse.Result.List[0].DeviceName.Should().NotBeNullOrWhiteSpace();
        }
    }
}
