using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpVesync.VesyncApiIntegrationTests
{
    [TestClass]
    public class VesyncApi7AIntegrationTests : TestBase
    {
        private VesyncApi7A Api7A;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            LoadConfig();
        }

        [TestInitialize]
        public async Task TestInit()
        {
            await Initialize();
            Api7A = new VesyncApi7A(Configuration);
        }

        [TestMethod]
        public async Task Vesync7AOutlet_GetConfig()
        {
            var devicesResponse = await Api.GetDevicesAsync(Account.Result.AccountId, Account.Result.Token);
            var sut = devicesResponse.Result.List.FirstOrDefault(x => x.DeviceType.Equals(Constants.Outlet7ADeviceType, StringComparison.InvariantCultureIgnoreCase));

            var config = await Api7A.GetConfig(sut.Cid, Account.Result.AccountId, Account.Result.Token);
            config.Should().NotBeNull();
            config.DeviceName.Should().NotBeNullOrWhiteSpace();
            config.DeviceImg.Should().NotBeNullOrWhiteSpace();
            config.AllowNotify.Should().NotBeNullOrWhiteSpace();
            config.LatestFirmVersion.Should().NotBeNullOrWhiteSpace();
            config.OwnerShip.Should().BeTrue();
            config.EnergySavingStatus.Should().NotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public async Task Vesync7AOutlet_GetDetails()
        {
            var devicesResponse = await Api.GetDevicesAsync(Account.Result.AccountId, Account.Result.Token);
            var sut = devicesResponse.Result.List.FirstOrDefault(x => x.DeviceType.Equals(Constants.Outlet7ADeviceType, StringComparison.InvariantCultureIgnoreCase));

            var details = await Api7A.GetDetailsAsync(sut.Cid, Account.Result.AccountId, Account.Result.Token);
            details.Should().NotBeNull();
            details.DeviceStatus.Should().NotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public async Task Vesync7AOutlet_TurnOnAndOff()
        {
            var devicesResponse = await Api.GetDevicesAsync(Account.Result.AccountId, Account.Result.Token);
            var sut = devicesResponse.Result.List.FirstOrDefault(x => x.DeviceType.Equals(Constants.Outlet7ADeviceType, StringComparison.InvariantCultureIgnoreCase));
            var details = await Api7A.GetDetailsAsync(sut.Cid, Account.Result.AccountId, Account.Result.Token);
            var status = details.DeviceStatus;

            var firstCommand = status == "on" ? false : true;

            await Api7A.TurnOnOrOff(sut.Cid, Account.Result.AccountId, Account.Result.Token, firstCommand);
            var status2 = (await Api7A.GetDetailsAsync(sut.Cid, Account.Result.AccountId, Account.Result.Token)).DeviceStatus;
            await Task.Delay(1000);
            await Api7A.TurnOnOrOff(sut.Cid, Account.Result.AccountId, Account.Result.Token, !firstCommand);
            var status3 = (await Api7A.GetDetailsAsync(sut.Cid, Account.Result.AccountId, Account.Result.Token)).DeviceStatus;

            status.Should().Be(status3);
            status.Should().NotBe(status2);
        }
    }
}
