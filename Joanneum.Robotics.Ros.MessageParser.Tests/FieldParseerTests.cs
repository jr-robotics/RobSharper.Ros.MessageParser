using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Moq;
using Xunit;

namespace Joanneum.Robotics.Ros.MessageParser.Tests
{
    public class FieldParseerTests
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
        public void CanParseIntegralField(string dataType)
        {
            Assert.NotNull(dataType);
            
            var message = $"{dataType} FooBarField";
            var messageParser = ParserHelper.CreateParserForMessage(message);

            var context = messageParser.ros_message();
            var mock = ParserHelper.CreateListenerMock();
            
            var listener = mock.Object;
            var treeWalker = new ParseTreeWalker();
            
            treeWalker.Walk(listener, context);
            
            mock.Verify(x => x.EnterIntegral_type(It.Is<RosMessageParser.Integral_typeContext>(c => dataType.Equals(c.GetText()))));
            mock.Verify(x => x.EnterIdentifier(It.Is<RosMessageParser.IdentifierContext>(c => "FooBarField".Equals(c.GetText()))));
        }
        
        [Fact]
        public void CanParseStringField()
        {
            var message = "string FooBarField";
            var messageParser = ParserHelper.CreateParserForMessage(message);

            var context = messageParser.ros_message();
            var mock = ParserHelper.CreateListenerMock();
            
            var listener = mock.Object;
            var treeWalker = new ParseTreeWalker();
            
            treeWalker.Walk(listener, context);
            
            mock.Verify(x => x.EnterString_type(It.Is<RosMessageParser.String_typeContext>(c => "string".Equals(c.GetText()))));
            mock.Verify(x => x.EnterIdentifier(It.Is<RosMessageParser.IdentifierContext>(c => "FooBarField".Equals(c.GetText()))));
        }
        
        [Fact]
        public void CanParseBooleanField()
        {
            var message = "bool FooBarField";
            var messageParser = ParserHelper.CreateParserForMessage(message);

            var context = messageParser.ros_message();
            var mock = ParserHelper.CreateListenerMock();
            
            var listener = mock.Object;
            var treeWalker = new ParseTreeWalker();
            
            treeWalker.Walk(listener, context);
            
            mock.Verify(x => x.EnterBoolean_type(It.Is<RosMessageParser.Boolean_typeContext>(c => "bool".Equals(c.GetText()))));
            mock.Verify(x => x.EnterIdentifier(It.Is<RosMessageParser.IdentifierContext>(c => "FooBarField".Equals(c.GetText()))));
        }
        
        [Theory]
        [InlineData("time")]
        [InlineData("duration")]
        public void CanParseTemporalField(string dataType)
        {
            Assert.NotNull(dataType);
            
            var message = $"{dataType} FooBarField";
            var messageParser = ParserHelper.CreateParserForMessage(message);

            var context = messageParser.ros_message();
            var mock = ParserHelper.CreateListenerMock();
            
            var listener = mock.Object;
            var treeWalker = new ParseTreeWalker();
            
            treeWalker.Walk(listener, context);
            
            mock.Verify(x => x.EnterTemportal_type(It.Is<RosMessageParser.Temportal_typeContext>(c => dataType.Equals(c.GetText()))));
            mock.Verify(x => x.EnterIdentifier(It.Is<RosMessageParser.IdentifierContext>(c => "FooBarField".Equals(c.GetText()))));
        }
        
        [Fact]
        public void CanParseInternalPackageTypeField()
        {
            var message = "MyCustomType FooBarField";
            var messageParser = ParserHelper.CreateParserForMessage(message);

            var context = messageParser.ros_message();
            var mock = ParserHelper.CreateListenerMock();
            
            var listener = mock.Object;
            var treeWalker = new ParseTreeWalker();
            
            treeWalker.Walk(listener, context);
            
            mock.Verify(x => x.EnterRos_type(It.Is<RosMessageParser.Ros_typeContext>(c => "MyCustomType".Equals(c.GetText()))));
            mock.Verify(x => x.EnterIdentifier(It.Is<RosMessageParser.IdentifierContext>(c => "FooBarField".Equals(c.GetText()))));
        }
        
        [Fact]
        public void CanParseExternalPackageTypeField()
        {
            var message = "my_packae_msgs/MyCustomType FooBarField";
            var messageParser = ParserHelper.CreateParserForMessage(message);

            var context = messageParser.ros_message();
            var mock = ParserHelper.CreateListenerMock();
            
            var listener = mock.Object;
            var treeWalker = new ParseTreeWalker();
            
            treeWalker.Walk(listener, context);
            
            mock.Verify(x => x.EnterRos_type(It.Is<RosMessageParser.Ros_typeContext>(c => "my_packae_msgs/MyCustomType".Equals(c.GetText()))));
            mock.Verify(x => x.EnterIdentifier(It.Is<RosMessageParser.IdentifierContext>(c => "FooBarField".Equals(c.GetText()))));
        }
    }
}