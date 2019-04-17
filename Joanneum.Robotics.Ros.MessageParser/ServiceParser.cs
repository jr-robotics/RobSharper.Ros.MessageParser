using System.IO;
using Antlr4.Runtime;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public class ServiceParser : AbstractParser<ServiceDescriptor>
    {
        public ServiceParser(ICharStream input) : base(input)
        {
        }

        public override ServiceDescriptor Parse()
        {
            var visitor = new RosMessageVisitor();
            var context = Parser.ros_service();

            return (ServiceDescriptor) visitor.Visit(context);
        }
        
        public static ServiceDescriptor Parse(string input)
        {
            return new ServiceParser(new AntlrInputStream(input)).Parse();
        }

        public static ServiceDescriptor Parse(Stream input)
        {
            return new ServiceParser(new AntlrInputStream(input)).Parse();
        }
    }
}