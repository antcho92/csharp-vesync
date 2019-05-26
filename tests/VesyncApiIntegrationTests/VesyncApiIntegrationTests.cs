using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace CSharpVesync.VesyncApiIntegrationTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class VesyncApiIntegrationTests : TestBase
    {
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            LoadConfig();
        }

        [TestInitialize]
        public async Task TestInit()
        {
            await Initialize();
        }

        [TestMethod]
        public async Task LoginAsync_GivenValidCredentials_ReturnsTokenAndAccountId()
        {
            var api = new VesyncApi(Configuration);
            var account = await api.LoginAsync();
            account.Result.Should().NotBeNull();
            account.Result.Token.Should().NotBeNullOrWhiteSpace();
            account.Result.AccountId.Should().NotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public async Task GetDevices_GivenValidCredentials_ReturnsTokenAndAccountId()
        {
            var devicesResponse = await Api.GetDevicesAsync(Account.Result.AccountId, Account.Result.Token);
            devicesResponse.Result.Should().NotBeNull();
            devicesResponse.Result.Total.Should().NotBe(0);
            devicesResponse.Result.List.Should().NotBeNullOrEmpty();
            devicesResponse.Result.List[0].DeviceName.Should().NotBeNullOrWhiteSpace();
        }
    }
}
