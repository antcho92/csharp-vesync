using System;
using Xunit;
using FluentAssertions;

namespace CSharpVesync.VesyncApiUnitTests
{
    public class VesyncApiUnitTests
    {
        [Fact]
        public void VesyncApi_ValidConfig_CreatesApi()
        {
            var config = new VesyncApiConfiguration();

            var api = new VesyncApi(config);
            api.Should().NotBeNull();
        }

        [Fact]
        public void VesyncApi_NullConfig_Throws()
        {
            VesyncApiConfiguration config = null;

            Action act = () => new VesyncApi(config);
            act.Should().Throw<ArgumentNullException>().And.Message.Should().Contain(nameof(config));
        }
    }
}
