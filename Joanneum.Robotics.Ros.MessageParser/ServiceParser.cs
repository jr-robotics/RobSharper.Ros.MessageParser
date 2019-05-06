using System;
using System.IO;
using Antlr4.Runtime;
using Joanneum.Robotics.Ros.MessageParser.Antlr;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public class ServiceParser : AbstractParser<ServiceDescriptor>
    {
        private RosMessageParser.Ros_service_inputContext _context;

        public RosMessageParser.Ros_service_inputContext Context => _context ?? (_context = Parser.ros_service_input());

        public ServiceParser(ICharStream input) : base(input)
        {
        }

        public ServiceParser(string input) : this(new AntlrInputStream(input))
        {
        }

        public ServiceParser(Stream input) : this(new AntlrInputStream(input))
        {
        }

        public override ServiceDescriptor Parse()
        {
            return Parse(null);
        }

        public override ServiceDescriptor Parse(IRosMessageVisitorListener listener)
        {
            var visitor = new RosMessageVisitor(listener);

            return (ServiceDescriptor) visitor.Visit(Context);
        }
    }
}