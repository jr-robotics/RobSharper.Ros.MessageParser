using System.IO;
using Antlr4.Runtime;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public class RosbagMessageDefinitionParser : AbstractParser<RosbagMessageDefinitionDescriptor>
    {
        public RosbagMessageDefinitionParser(ICharStream input) : base(input)
        {
        }

        public override RosbagMessageDefinitionDescriptor Parse()
        {
            var visitor = new RosMessageVisitor();
            var context = Parser.rosbag_input();

            return (RosbagMessageDefinitionDescriptor) visitor.Visit(context);
        }
        
        public static RosbagMessageDefinitionDescriptor Parse(string input)
        {
            return new RosbagMessageDefinitionParser(new AntlrInputStream(input)).Parse();
        }

        public static RosbagMessageDefinitionDescriptor Parse(Stream input)
        {
            return new RosbagMessageDefinitionParser(new AntlrInputStream(input)).Parse();
        }
    }
}