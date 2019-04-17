using Joanneum.Robotics.Ros.MessageParser.Tests.Helpers;
using Xunit;

namespace Joanneum.Robotics.Ros.MessageParser.Tests
{
    public class ServiceDescriptorTests
    {
        [Fact]
        public void Can_parse_empty_service()
        {
            var message = "---";

            var actual = ServiceDescriptorParser.Parse(message);

            Assert.NotNull(actual);
            Assert.NotNull(actual.Request);
            Assert.NotNull(actual.Response);

            Assert.True(actual.Request.IsEmpty);
            Assert.True(actual.Response.IsEmpty);
        }

        [Theory]
        [TestMessages("*.srv")]
        public void Can_load_srv_file(TestMessage file)
        {
            var actual = ServiceDescriptorParser.Parse(file.Content.Value);
            
            Assert.NotNull(actual);
        }
    }
}