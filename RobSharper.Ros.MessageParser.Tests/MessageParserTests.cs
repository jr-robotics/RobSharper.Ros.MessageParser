using System.Linq;
using RobSharper.Ros.MessageParser;
using RobSharper.Ros.MessageParser.Tests.Helpers;
using Xunit;

namespace RobSharper.Ros.MessageParser.Tests
{
    public class MessageParserTests
    {
        [Fact]
        public void Can_parse_simple_message()
        {
            var message = "int8 fooo";

            var actual = new RobSharper.Ros.MessageParser.MessageParser(message).Parse();;

            Assert.NotNull(actual);
            Assert.Empty(actual.Comments);
            Assert.Empty(actual.Constants);
            
            Assert.Single(actual.Fields);

            var field = actual.Fields.First();
            var typeMapping = BuiltInTypeMapping.Create(field.TypeInfo);
            
            Assert.Equal(BuiltInTypeMapping.Int8, typeMapping);
            Assert.Equal("fooo", field.Identifier);
        }

        [Fact]
        public void Can_parse_empty_message()
        {
            var message = string.Empty;

            var actual = new RobSharper.Ros.MessageParser.MessageParser(message).Parse();

            Assert.NotNull(actual);
            Assert.True(actual.IsEmpty);
            
            Assert.Empty(actual.Comments);
            Assert.Empty(actual.Constants);
            Assert.Empty(actual.Fields);
        }

        [Theory]
        [TestMessages("*.msg")]
        public void Can_load_msg_file(TestMessage file)
        {
            var actual = new RobSharper.Ros.MessageParser.MessageParser(file.Content.Value).Parse();
            
            Assert.NotNull(actual);
        }
    }
}