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
        public void OnVisitBuiltInType_called_infield_declaration(string dataType)
        {
            var message = $"{dataType} fieldName";
            var expectedBuiltInType = RosTypeInfo.CreateBuiltIn(dataType);;
            
            var messageParser = ParserHelper.CreateParserForMessage(message);
            var context = messageParser.ros_message();
            
            var mock = new Mock<IRosMessageVisitorListener>();
            var visitor = new RosMessageVisitor(mock.Object);
            
            visitor.Visit(context);
            
            mock.Verify(x => x.OnVisitBuiltInType(expectedBuiltInType));
        }
        
        [Theory]
        [InlineData("int8", 7)]
        [InlineData("int16", 7)]
        [InlineData("int32", 7)]
        [InlineData("int64", 7)]
        [InlineData("uint8", 7)]
        [InlineData("uint16", 7)]
        [InlineData("uint32", 7)]
        [InlineData("uint64", 7)]
        [InlineData("float32", 1.0)]
        [InlineData("float64", 1.0)]
        [InlineData("string", "anystring")]
        [InlineData("bool", "True")]
        [InlineData("char", 8)]
        [InlineData("byte", 8)]
        public void OnVisitBuiltInType_called_in_constant_declaration(string dataType, object value)
        {
            var message = $"{dataType} CONST = {value}";
            var expectedPrimitiveType = RosTypeInfo.CreateBuiltIn(dataType);
            
            var messageParser = ParserHelper.CreateParserForMessage(message);
            var context = messageParser.ros_message();
            
            var mock = new Mock<IRosMessageVisitorListener>();
            var visitor = new RosMessageVisitor(mock.Object);
            
            visitor.Visit(context);
            
            mock.Verify(x => x.OnVisitBuiltInType(expectedPrimitiveType));
        }

        [Fact]
        public void OnVisitRosType_called_in_field_decalaration_for_external_type()
        {
            var message = $"std_msgs/Bool fieldName";
            var expectedTypeDescriptor = RosTypeInfo.CreateRosType("std_msgs", "Bool");
            
            var messageParser = ParserHelper.CreateParserForMessage(message);
            var context = messageParser.ros_message();
            
            var mock = new Mock<IRosMessageVisitorListener>();
            var visitor = new RosMessageVisitor(mock.Object);
            
            visitor.Visit(context);

            mock.Verify(x => x.OnVisitRosType(expectedTypeDescriptor));
        }

        [Fact]
        public void OnVisitRosType_called_in_constant_decalaration_for_external_type()
        {
            var message = $"std_msgs/Bool CONST = True";
            var expectedTypeDescriptor = RosTypeInfo.CreateRosType("std_msgs", "Bool");
            
            var messageParser = ParserHelper.CreateParserForMessage(message);
            var context = messageParser.ros_message();
            
            var mock = new Mock<IRosMessageVisitorListener>();
            var visitor = new RosMessageVisitor(mock.Object);
            
            visitor.Visit(context);

            mock.Verify(x => x.OnVisitRosType(expectedTypeDescriptor));
        }

        [Fact]
        public void OnVisitRosType_called_in_field_decalaration_for_internal_type()
        {
            var message = $"MyType fieldName";
            var expectedTypeDescriptor = RosTypeInfo.CreateRosType("MyType");
            
            var messageParser = ParserHelper.CreateParserForMessage(message);
            var context = messageParser.ros_message();
            
            var mock = new Mock<IRosMessageVisitorListener>();
            var visitor = new RosMessageVisitor(mock.Object);

            visitor.Visit(context);

            mock.Verify(x => x.OnVisitRosType(expectedTypeDescriptor));
        }
        
        [Fact]
        public void OnVisitRosType_called_in_field_decalaration_for_header_type()
        {
            var message = $"Header fieldName";
            var expectedTypeDescriptor = RosTypeInfo.CreateRosType("std_msgs", "Header");
            
            var messageParser = ParserHelper.CreateParserForMessage(message);
            var context = messageParser.ros_message();
            
            var mock = new Mock<IRosMessageVisitorListener>();
            var visitor = new RosMessageVisitor(mock.Object);

            visitor.Visit(context);

            mock.Verify(x => x.OnVisitRosType(expectedTypeDescriptor));
        }
        
        [Fact]
        public void OnVisitIdentifier_called_in_field_declaration()
        {
            var expectedIdentifier = "fieldName";
            var message = $"MyType {expectedIdentifier}";
            
            var messageParser = ParserHelper.CreateParserForMessage(message);
            var context = messageParser.ros_message();
            
            var mock = new Mock<IRosMessageVisitorListener>();
            var visitor = new RosMessageVisitor(mock.Object);

            visitor.Visit(context);

            mock.Verify(x => x.OnVisitIdentifier(expectedIdentifier));
        }
        
        [Fact]
        public void OnVisitIdentifier_called_in_const_declaration()
        {
            var expectedIdentifier = "CONST_NAME";
            var message = $"bool {expectedIdentifier} = True";
            
            var messageParser = ParserHelper.CreateParserForMessage(message);
            var context = messageParser.ros_message();
            
            var mock = new Mock<IRosMessageVisitorListener>();
            var visitor = new RosMessageVisitor(mock.Object);

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
            
            var mock = new Mock<IRosMessageVisitorListener>();
            var visitor = new RosMessageVisitor(mock.Object);
            
            visitor.Visit(context);

            mock.Verify(x => x.OnVisitComment(expectedComment));
        }
        
        [Fact]
        public void Comment_returns_comment_without_leading_and_trailing_whitespaces()
        {
            const string expectedComment = "This is my Comment";
            var message = $"MyType fieldName        #  \t{expectedComment}  \t";
            
            var messageParser = ParserHelper.CreateParserForMessage(message);
            var context = messageParser.ros_message();
            
            var mock = new Mock<IRosMessageVisitorListener>();
            var visitor = new RosMessageVisitor(mock.Object);
            
            visitor.Visit(context);

            mock.Verify(x => x.OnVisitComment(expectedComment));
        }
        
        [Fact]
        public void Empty_comment_returns_empty_string()
        {
            string expectedComment = string.Empty;
            var message = $"MyType fieldName        #";
            
            var messageParser = ParserHelper.CreateParserForMessage(message);
            var context = messageParser.ros_message();
            
            var mock = new Mock<IRosMessageVisitorListener>();
            var visitor = new RosMessageVisitor(mock.Object);
            
            visitor.Visit(context);

            mock.Verify(x => x.OnVisitComment(expectedComment));
        }
    }
}