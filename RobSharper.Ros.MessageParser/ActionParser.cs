using System.IO;
using Antlr4.Runtime;
using RobSharper.Ros.MessageParser.Antlr;

namespace RobSharper.Ros.MessageParser
{
    public class ActionParser : AbstractParser<ActionDescriptor>
    {
        private RosMessageParser.Ros_action_inputContext _context;

        public RosMessageParser.Ros_action_inputContext Context => _context ?? (_context = Parser.ros_action_input());

        public ActionParser(ICharStream input) : base(input)
        {
        }

        public ActionParser(string input) : this(new AntlrInputStream(input))
        {
        }

        public ActionParser(Stream input) : this(new AntlrInputStream(input))
        {
        }

        public override ActionDescriptor Parse()
        {
            return Parse(null);
        }

        public override ActionDescriptor Parse(IRosMessageVisitorListener listener)
        {
            var visitor = new RosMessageVisitor(listener);

            return (ActionDescriptor) visitor.Visit(Context);
        }
    }
}