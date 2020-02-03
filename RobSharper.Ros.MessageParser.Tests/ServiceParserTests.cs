using RobSharper.Ros.MessageParser;
using RobSharper.Ros.MessageParser.Tests.Helpers;
using Xunit;

namespace RobSharper.Ros.MessageParser.Tests
{
    public class ServiceParserTests
    {
        [Fact]
        public void Can_parse_empty_service()
        {
            var message = "---";

            var parser = new ServiceParser(message);
            var actual = parser.Parse();

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
            var parser = new ServiceParser(file.Content.Value);
            var actual = parser.Parse();
            
            Assert.NotNull(actual);
        }
    }
}