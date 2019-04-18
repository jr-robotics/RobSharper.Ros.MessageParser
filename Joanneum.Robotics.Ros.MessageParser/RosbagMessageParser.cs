using System.IO;
using Antlr4.Runtime;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public class RosbagMessageParser : AbstractParser<RosbagMessageDescriptor>
    {
        public RosbagMessageParser(ICharStream input) : base(input)
        {
        }

        public override RosbagMessageDescriptor Parse()
        {
            var visitor = new RosMessageVisitor();
            var context = Parser.rosbag_input();

            return (RosbagMessageDescriptor) visitor.Visit(context);
        }
        
        public static RosbagMessageDescriptor Parse(string input)
        {
            return new RosbagMessageParser(new AntlrInputStream(input)).Parse();
        }

        public static RosbagMessageDescriptor Parse(Stream input)
        {
            return new RosbagMessageParser(new AntlrInputStream(input)).Parse();
        }
    }
}