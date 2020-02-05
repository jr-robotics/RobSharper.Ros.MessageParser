using System.IO;
using Antlr4.Runtime;
using RobSharper.Ros.MessageParser.Antlr;

namespace RobSharper.Ros.MessageParser
{
    public class MessageParser : AbstractParser<MessageDescriptor>
    {
        private RosMessageParser.Ros_message_inputContext _context;

        public RosMessageParser.Ros_message_inputContext Context => _context ?? (_context = Parser.ros_message_input());

        public MessageParser(ICharStream input) : base(input)
        {
        }

        public MessageParser(string input) : this(new AntlrInputStream(input))
        {
        }

        public MessageParser(Stream input) : this(new AntlrInputStream(input))
        {
        }

        public override MessageDescriptor Parse()
        {
            return Parse(null);
        }

        public override MessageDescriptor Parse(IRosMessageVisitorListener listener)
        {
            var visitor = new RosMessageVisitor(listener);

            return (MessageDescriptor) visitor.Visit(Context);
        }
    }
}