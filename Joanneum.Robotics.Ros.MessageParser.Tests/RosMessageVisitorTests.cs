using System;
using Antlr4.Runtime.Tree;
using Moq;
using Xunit;

namespace Joanneum.Robotics.Ros.MessageParser.Tests
{
    public class RosMessageVisitorTests
    {
        [Theory]
        [InlineData("int8")]
        [InlineData("int16")]
        [InlineData("int32")]
        [InlineData("int64")]
        [InlineData("uint8")]
        [InlineData("uint16")]
        [InlineData("uint32")]
        [InlineData("uint64")]
        [InlineData("float32")]
        [InlineData("float64")]
        [InlineData("string")]
        [InlineData("bool")]
        [InlineData("char")]
        [InlineData("byte")]
        public void VisitBaseType_return_RosPrimitiveType(string dataType)
        {
            var message = $"{dataType} fieldName";
            var expectedPrimitiveType = PrimitiveTypeDescriptor.Parse(dataType);
            
            var messageParser = ParserHelper.CreateParserForMessage(message);
            var context = messageParser.ros_message();
            
            var mock = new Mock<RosMessageVisitor>()
            {
                CallBase = true
            };
            
            var visitor = mock.Object;
            visitor.Visit(context);
            
            mock.Verify(x => x.OnVisitBaseType(expectedPrimitiveType));
        }

        [Fact]
        public void VisitRosType_retuns_RosTypeDescriptor_for_external_external()
        {
            var message = $"std_msgs/Bool fieldName";
            var expectedTypeDescriptor = new RosTypeDescriptor("Bool", "std_msgs");
            
            var messageParser = ParserHelper.CreateParserForMessage(message);
            var context = messageParser.ros_message();
            
            var mock = new Mock<RosMessageVisitor>()
            {
                CallBase = true
            };

            var visitor = mock.Object;
            visitor.Visit(context);

            mock.Verify(x => x.OnVisitRosType(expectedTypeDescriptor));
        }

        [Fact]
        public void VisitRosType_retuns_RosTypeDescriptor_for_internal_type()
        {
            var message = $"MyType fieldName";
            var expectedTypeDescriptor = new RosTypeDescriptor("MyType");
            
            var messageParser = ParserHelper.CreateParserForMessage(message);
            var context = messageParser.ros_message();
            
            var mock = new Mock<RosMessageVisitor>()
            {
                CallBase = true
            };

            var visitor = mock.Object;
            visitor.Visit(context);

            mock.Verify(x => x.OnVisitRosType(expectedTypeDescriptor));
        }

        [Fact]
        public void VisitRosType_retuns_RosTypeDescriptor_for_header_type()
        {
            var message = $"Header fieldName";
            var expectedTypeDescriptor = new RosTypeDescriptor("Header", "std_msgs");
            
            var messageParser = ParserHelper.CreateParserForMessage(message);
            var context = messageParser.ros_message();
            
            var mock = new Mock<RosMessageVisitor>()
            {
                CallBase = true
            };

            var visitor = mock.Object;
            visitor.Visit(context);

            mock.Verify(x => x.OnVisitRosType(expectedTypeDescriptor));
        }
        
        [Fact]
        public void VisitIdentifier_returns_identifier_name()
        {
            var expectedIdentifier = "fieldName";
            var message = $"MyType {expectedIdentifier}";
            
            var messageParser = ParserHelper.CreateParserForMessage(message);
            var context = messageParser.ros_message();
            
            var mock = new Mock<RosMessageVisitor>()
            {
                CallBase = true
            };
            
            var visitor = mock.Object;
            visitor.Visit(context);

            mock.Verify(x => x.OnVisitIdentifier(expectedIdentifier));
        }
        
        [Fact]
        public void Comment_returns_comment_without_sharp()
        {
            const string expectedComment = "This is my Comment";
            var message = $"MyType fieldName        #{expectedComment}";
            
            var messageParser = ParserHelper.CreateParserForMessage(message);

            var context = messageParser.ros_message();
            
            var mock = new Mock<RosMessageVisitor>()
            {
                CallBase = true
            };
            
            var visitor = mock.Object;
            visitor.Visit(context);

            mock.Verify(x => x.OnVisitComment(expectedComment));
        }
    }
}