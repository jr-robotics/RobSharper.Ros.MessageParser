using System;
using Antlr4.Runtime;
using Moq;
using Xunit;

namespace Joanneum.Robotics.Ros.MessageParser.Tests
{
    public class UnitTest1
    {
        public class CountVisitor : RosMessageBaseVisitor<object>
        {
            public int Fileds { get; private set; }
            public override object VisitRos_message_element(RosMessageParser.Ros_message_elementContext context)
            {
                Fileds++;
                return base.VisitRos_message_element(context);
            }
        }
        
        [Fact]
        public void Test1()
        {
            var message = "int8 fieldName";
            
            var messageParser = CreateParserForMessage(message);

            var context = messageParser.ros_message();
            
            var realVisitor = new CountVisitor();
            realVisitor.Visit(context);
            
            Assert.True(realVisitor.Fileds > 0);
//            
//            
//            var visitorMock = new Mock<RosMessageBaseVisitor<object>>(MockBehavior.Loose);
//            
//            visitorMock.Setup(x => x.VisitRos_message_element(It.IsAny<RosMessageParser.Ros_message_elementContext>())).CallBase().Verifiable();
//            
//            
//            var visitor = visitorMock.Object;
//            
//            visitor.Visit(context);
//            
//            visitorMock.Verify(x => x.VisitRos_message_element(It.IsAny<RosMessageParser.Ros_message_elementContext>()), Times.Once);
        }

        private static RosMessageParser CreateParserForMessage(string message)
        {
            var inputStream = new AntlrInputStream(message);

            var messageLexer = new RosMessageLexer(inputStream);
            var tokenStream = new CommonTokenStream(messageLexer);
            var messageParser = new RosMessageParser(tokenStream);
            return messageParser;
        }
    }
}