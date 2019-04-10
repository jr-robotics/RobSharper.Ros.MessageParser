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
        
        public static Mock<RosMessageBaseVisitor<object>> CreateVisitorMock()
        {
            var mock = new Mock<RosMessageBaseVisitor<object>>()
            {
                CallBase = true
            };
            return mock;
        }

        public static Mock<RosMessageBaseListener> CreateListenerMock()
        {
            var mock = new Mock<RosMessageBaseListener>()
            {
                CallBase = true
            };
            
            return mock;
        }
    }
}