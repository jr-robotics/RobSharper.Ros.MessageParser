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
        public void TypeNode_VisitChildren_retuns_RosPrimitiveType_for_built_in_types(string dataType)
        {
            var message = $"{dataType} fieldName";
            var messageParser = ParserHelper.CreateParserForMessage(message);

            var context = messageParser.ros_message();
            object result = null;
            
            var mock = new Mock<RosMessageVisitor>()
            {
                CallBase = true
            };

            mock.Setup(x => x.VisitType(It.IsAny<RosMessageParser.TypeContext>()))
                .Callback<RosMessageParser.TypeContext>((ctx) => { result = mock.Object.VisitChildren(ctx); })
                .Returns(result);
            
            
            var visitor = mock.Object;
            visitor.Visit(context);

            Assert.NotNull(result);
            Assert.IsType<PrimitiveTypeDescriptor>(result);
        }

        [Fact]
        public void TypeNode_VisitChildren_retuns_RosMessageType_for_external_ros_type()
        {
            var message = $"std_msgs/Bool fieldName";
            var messageParser = ParserHelper.CreateParserForMessage(message);

            var context = messageParser.ros_message();
            object result = null;
            
            var mock = new Mock<RosMessageVisitor>()
            {
                CallBase = true
            };

            mock.Setup(x => x.VisitType(It.IsAny<RosMessageParser.TypeContext>()))
                .Callback<RosMessageParser.TypeContext>((ctx) => { result = mock.Object.VisitChildren(ctx); })
                .Returns(result);
            
            
            var visitor = mock.Object;
            visitor.Visit(context);

            Assert.NotNull(result);
            Assert.IsType<RosTypeDescriptor>(result);

            var type = (RosTypeDescriptor) result;
            
            Assert.Equal("std_msgs", type.PackageName);
            Assert.Equal("Bool", type.TypeName);
            Assert.True(type.HasPackage);
        }

        [Fact]
        public void TypeNode_VisitChildren_retuns_RosMessageType_for_package_ros_type()
        {
            var message = $"MyType fieldName";
            var messageParser = ParserHelper.CreateParserForMessage(message);

            var context = messageParser.ros_message();
            object result = null;
            
            var mock = new Mock<RosMessageVisitor>()
            {
                CallBase = true
            };

            mock.Setup(x => x.VisitType(It.IsAny<RosMessageParser.TypeContext>()))
                .Callback<RosMessageParser.TypeContext>((ctx) => { result = mock.Object.VisitChildren(ctx); })
                .Returns(result);
            
            
            var visitor = mock.Object;
            visitor.Visit(context);

            Assert.NotNull(result);
            Assert.IsType<RosTypeDescriptor>(result);

            var type = (RosTypeDescriptor) result;
            
            Assert.Null(type.PackageName);
            Assert.Equal("MyType", type.TypeName);
            Assert.False(type.HasPackage);
        }

        [Fact]
        public void TypeNode_VisitChildren_retuns_RosMessageType_for_header_ros_type()
        {
            var message = $"Header fieldName";
            var messageParser = ParserHelper.CreateParserForMessage(message);

            var context = messageParser.ros_message();
            object result = null;
            
            var mock = new Mock<RosMessageVisitor>()
            {
                CallBase = true
            };

            mock.Setup(x => x.VisitType(It.IsAny<RosMessageParser.TypeContext>()))
                .Callback<RosMessageParser.TypeContext>((ctx) => { result = mock.Object.VisitChildren(ctx); })
                .Returns(result);
            
            
            var visitor = mock.Object;
            visitor.Visit(context);

            Assert.NotNull(result);
            Assert.IsType<RosTypeDescriptor>(result);

            var type = (RosTypeDescriptor) result;
            
            Assert.Equal("std_msgs", type.PackageName);
            Assert.Equal("Header", type.TypeName);
            Assert.True(type.HasPackage);
        }
        
        [Fact]
        public void Identifier_in_field_declaration_returns_identifier_name()
        {
            var message = $"MyType fieldName";
            
            var messageParser = ParserHelper.CreateParserForMessage(message);

            var context = messageParser.ros_message();
            object fieldName = null;
            
            var mock = new Mock<RosMessageVisitor>()
            {
                CallBase = true
            };

            mock.Setup(x => x.VisitField_declaration(It.IsAny<RosMessageParser.Field_declarationContext>()))
                .Callback<RosMessageParser.Field_declarationContext>(ctx =>
                {
                    fieldName = mock.Object.Visit(ctx.GetChild(1));
                });
            
            var visitor = mock.Object;
            visitor.Visit(context);

            Assert.NotNull(fieldName);
            Assert.IsType<string>(fieldName);
            Assert.Equal("fieldName", (string) fieldName);
        }
        
        [Fact]
        public void Comment_in_field_declaration_strips_sharp()
        {
            const string expectedComment = "This is my Comment";
            var message = $"MyType fieldName        #{expectedComment}";
            
            var messageParser = ParserHelper.CreateParserForMessage(message);

            var context = messageParser.ros_message();
            object comment = null;
            
            var mock = new Mock<RosMessageVisitor>()
            {
                CallBase = true
            };

            mock.Setup(x => x.VisitField_declaration(It.IsAny<RosMessageParser.Field_declarationContext>()))
                .Callback<RosMessageParser.Field_declarationContext>(ctx =>
                {
                    comment = mock.Object.Visit(ctx.GetChild(2));
                });
            
            var visitor = mock.Object;
            visitor.Visit(context);

            Assert.NotNull(comment);
            Assert.IsType<string>(comment);
            Assert.Equal(expectedComment, (string) comment);
        }
    }
}