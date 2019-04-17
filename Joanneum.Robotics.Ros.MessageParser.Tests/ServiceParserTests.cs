using Joanneum.Robotics.Ros.MessageParser.Tests.Helpers;
using Xunit;

namespace Joanneum.Robotics.Ros.MessageParser.Tests
{
    public class ServiceParserTests
    {
        [Fact]
        public void Can_parse_empty_service()
        {
            var message = "---";

            var actual = ServiceParser.Parse(message);

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
            var actual = ServiceParser.Parse(file.Content.Value);
            
            Assert.NotNull(actual);
        }
    }
}