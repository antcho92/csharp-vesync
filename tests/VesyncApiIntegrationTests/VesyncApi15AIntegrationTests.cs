using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.Collections.Generic;
using CSharpVesync.Models.Responses;

namespace CSharpVesync.VesyncApiIntegrationTests
{
    [TestClass]
    public class VesyncApi15AIntegrationTests : TestBase
    {
        private VesyncApi15A Api15A;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            LoadConfig();
        }

        [TestInitialize]
        public async Task TestInit()
        {
            await Initialize();
            Api15A = new VesyncApi15A();
        }

        [TestMethod]
        public async Task Vesync15AOutlet_GetDetails_ReturnsDetails()
        {
            var devicesResponse = await Api.GetDevicesAsync(Account.Result.AccountId, Account.Result.Token);
            var sut = devicesResponse.Result.List.FirstOrDefault(x => x.DeviceType.Equals(Constants.Outlet15ADeviceType, StringComparison.InvariantCultureIgnoreCase));

            var details = await Api15A.GetDetailsAsync(sut.Uuid, Account.Result.AccountId, Account.Result.Token);
            details.Should().NotBeNull();
            details.Power.Should().NotBeNullOrWhiteSpace();
            details.Voltage.Should().NotBeNullOrWhiteSpace();
            (string.Equals(details.DeviceStatus, "on") || string.Equals(details.DeviceStatus, "off")).Should().BeTrue();
            (string.Equals(details.NightLightStatus, "on") || string.Equals(details.NightLightStatus, "off")).Should().BeTrue();
        }

        [TestMethod]
        public async Task Vesync15AOutlet_TurnOnAndOff_SwitchesDeviceOnAndOff()
        {
            var devicesResponse = await Api.GetDevicesAsync(Account.Result.AccountId, Account.Result.Token);
            var sut = devicesResponse.Result.List.LastOrDefault(x => x.DeviceType.Equals(Constants.Outlet15ADeviceType, StringComparison.InvariantCultureIgnoreCase));
            var details = await Api15A.GetDetailsAsync(sut.Uuid, Account.Result.AccountId, Account.Result.Token);
            var status = details.DeviceStatus;

            var firstCommand = status == "on" ? false : true;

            var result1 = await Api15A.TurnOnOrOff(sut.Uuid, Account.Result.AccountId, Account.Result.Token, firstCommand);
            var status2 = (await Api15A.GetDetailsAsync(sut.Uuid, Account.Result.AccountId, Account.Result.Token)).DeviceStatus;
            await Task.Delay(1000);
            var result2 = await Api15A.TurnOnOrOff(sut.Uuid, Account.Result.AccountId, Account.Result.Token, !firstCommand);
            var status3 = (await Api15A.GetDetailsAsync(sut.Uuid, Account.Result.AccountId, Account.Result.Token)).DeviceStatus;

            status.Should().Be(status3);
            status.Should().NotBe(status2);
        }

        [TestMethod]
        public async Task Vesync15AOutlet_GetEnergy_ReturnsEnergy()
        {
            var devicesResponse = await Api.GetDevicesAsync(Account.Result.AccountId, Account.Result.Token);
            var sut = devicesResponse.Result.List.FirstOrDefault(x => x.DeviceType.Equals(Constants.Outlet15ADeviceType, StringComparison.InvariantCultureIgnoreCase));

            var energyResults = new List<EnergyResponse15A>();
            foreach (var period in (EnergyPeriod[])Enum.GetValues(typeof(EnergyPeriod)))
            {
                energyResults.Add(await Api15A.GetEnergy(sut.Uuid, Account.Result.AccountId, Account.Result.Token, period));
            }

            foreach (var result in energyResults)
            {
                result.Should().NotBeNull();
                result.Data.Should().NotBeNullOrEmpty();
            }
        }
    }
}
