using Joanneum.Robotics.Ros.MessageParser.Tests.Helpers;
using Xunit;

namespace Joanneum.Robotics.Ros.MessageParser.Tests
{
    public class ActionParserTests
    {
        [Fact]
        public void Can_parse_empty_action()
        {
            var message = "---\n---";

            var actual = ActionParser.Parse(message);

            Assert.NotNull(actual);
            Assert.NotNull(actual.Goal);
            Assert.NotNull(actual.Feedback);
            Assert.NotNull(actual.Result);

            Assert.True(actual.Goal.IsEmpty);
            Assert.True(actual.Feedback.IsEmpty);
            Assert.True(actual.Result.IsEmpty);
        }

        [Theory]
        [TestMessages("*.action")]
        public void Can_load_srv_file(TestMessage file)
        {
            var actual = ServiceParser.Parse(file.Content.Value);
            
            Assert.NotNull(actual);
        }
    }
}