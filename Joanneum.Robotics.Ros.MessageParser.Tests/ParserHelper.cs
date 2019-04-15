using Antlr4.Runtime;
using Moq;

namespace Joanneum.Robotics.Ros.MessageParser.Tests
{
    public static class ParserHelper
    {
        public static RosMessageParser CreateParserForMessage(string message)
        {
            var inputStream = new AntlrInputStream(message);

            var messageLexer = new RosMessageLexer(inputStream);
            var tokenStream = new CommonTokenStream(messageLexer);
            var messageParser = new RosMessageParser(tokenStream);
            return messageParser;
        }

        public static Mock<RosMessageParserBaseListener> CreateListenerMock()
        {
            var mock = new Mock<RosMessageParserBaseListener>()
            {
                CallBase = true
            };
            
            return mock;
        }
    }
}