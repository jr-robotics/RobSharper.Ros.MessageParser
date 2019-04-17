using System.IO;
using Antlr4.Runtime;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public class MessageParser : DescriptorParser<MessageDescriptor>
    {
        public MessageParser(ICharStream input) : base(input)
        {
        }

        public override MessageDescriptor ParseDescriptor()
        {
            var visitor = new RosMessageVisitor();
            var context = Parser.ros_message();

            return (MessageDescriptor) visitor.Visit(context);
        }
        
        public static MessageDescriptor Parse(string input)
        {
            return new MessageParser(new AntlrInputStream(input)).ParseDescriptor();
        }

        public static MessageDescriptor Parse(Stream input)
        {
            return new MessageParser(new AntlrInputStream(input)).ParseDescriptor();
        }
    }
}