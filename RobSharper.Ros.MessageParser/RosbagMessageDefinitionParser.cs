using System.IO;
using Antlr4.Runtime;
using RobSharper.Ros.MessageParser.Antlr;

namespace RobSharper.Ros.MessageParser
{
    public class RosbagMessageDefinitionParser : AbstractParser<RosbagMessageDefinitionDescriptor>
    {
        private RosMessageParser.Rosbag_inputContext _context;

        public RosMessageParser.Rosbag_inputContext Context => _context ?? (_context = Parser.rosbag_input());

        public RosbagMessageDefinitionParser(ICharStream input) : base(input)
        {
        }

        public RosbagMessageDefinitionParser(string input) : this(new AntlrInputStream(input))
        {
        }

        public RosbagMessageDefinitionParser(Stream input) : this(new AntlrInputStream(input))
        {
        }

        public override RosbagMessageDefinitionDescriptor Parse()
        {
            return Parse(null);
        }

        public override RosbagMessageDefinitionDescriptor Parse(IRosMessageVisitorListener listener)
        {
            var visitor = new RosMessageVisitor(listener);

            return (RosbagMessageDefinitionDescriptor) visitor.Visit(Context);
        }
    }
}