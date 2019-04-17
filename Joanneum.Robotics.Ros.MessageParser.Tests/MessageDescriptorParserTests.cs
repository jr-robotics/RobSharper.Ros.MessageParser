using System.Linq;
using Joanneum.Robotics.Ros.MessageParser.Tests.Helpers;
using Xunit;

namespace Joanneum.Robotics.Ros.MessageParser.Tests
{
    public class MessageDescriptorParserTests
    {
        [Fact]
        public void Can_parse_simple_message()
        {
            var message = "int8 fooo";

            var actual = MessageDescriptorParser.Parse(message);

            Assert.NotNull(actual);
            Assert.Empty(actual.Comments);
            Assert.Empty(actual.Consts);
            
            Assert.Equal(1, actual.Fields.Count());

            var field = actual.Fields.First();
            
            Assert.Equal(PrimitiveTypeDescriptor.Int8, field.Type);
            Assert.Equal("fooo", field.Identifier);
        }

        [Theory]
        [TestMessages("*.msg")]
        public void Can_load_msg_file(TestMessage file)
        {
            var actual = MessageDescriptorParser.Parse(file.Content.Value);
            
            Assert.NotNull(actual);
        }
    }
}