using Xunit;

namespace Joanneum.Robotics.Ros.MessageParser.Tests
{
    public class RosbagMessageParserTests
    {
        [Fact]
        public void Can_parse_rosbag_message_without_nested_types()
        {
            var input = @"int8 x     # This is a really simple message";

            var actual = RosbagMessageParser.Parse(input);

            Assert.NotNull(actual);
            Assert.NotNull(actual.Message);
            Assert.Empty(actual.NestedMessages);
        }
        
        [Fact]
        public void Can_parse_rosbag_message_with_empty_message()
        {
            var input = string.Empty;

            var actual = RosbagMessageParser.Parse(input);

            Assert.NotNull(actual);
            Assert.NotNull(actual.Message);
            Assert.True(actual.Message.IsEmpty);
            Assert.Empty(actual.NestedMessages);
        }

        [Fact]
        public void Can_parse_rosbag_with_nested_message()
        {
            var input = @"byte DEBUG=1 
byte INFO=2 
byte WARN=4 
byte ERROR=8 
byte FATAL=16 
Header header
byte level
string name 
string msg 
string file 
string function 
uint32 line 
string[] topics 
================================================================================
MSG: std_msgs/Header
uint32 seq
time stamp
string frame_id";
            
            var actual = RosbagMessageParser.Parse(input);

            Assert.NotNull(actual);
            Assert.NotNull(actual.Message);
            Assert.Single(actual.NestedMessages);

            var nestedMessage = actual.NestedMessages[new RosTypeDescriptor("Header", "std_msgs")];

            Assert.NotNull(nestedMessage);
            Assert.False(nestedMessage.IsEmpty);
        }
    }
}