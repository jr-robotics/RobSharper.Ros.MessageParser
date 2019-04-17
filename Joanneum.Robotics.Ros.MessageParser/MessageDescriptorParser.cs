using System.IO;
using Antlr4.Runtime;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public class MessageDescriptorParser : DescriptorParser<MessageDescriptor>
    {
        public MessageDescriptorParser(ICharStream input) : base(input)
        {
        }

        public override MessageDescriptor ParseDescriptor()
        {
            var visitor = new RosMessageVisitor();
            var context = Parser.ros_message();

            return (MessageDescriptor) visitor.VisitRos_message(context);
        }
        
        public static MessageDescriptor Parse(string input)
        {
            return new MessageDescriptorParser(new AntlrInputStream(input)).ParseDescriptor();
        }

        public static MessageDescriptor Parse(Stream input)
        {
            return new MessageDescriptorParser(new AntlrInputStream(input)).ParseDescriptor();
        }
    }
}