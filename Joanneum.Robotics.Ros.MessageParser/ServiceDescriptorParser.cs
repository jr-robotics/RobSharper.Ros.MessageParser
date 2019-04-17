using System.IO;
using Antlr4.Runtime;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public class ServiceDescriptorParser : DescriptorParser<ServiceDescriptor>
    {
        public ServiceDescriptorParser(ICharStream input) : base(input)
        {
        }

        public override ServiceDescriptor ParseDescriptor()
        {
            var visitor = new RosMessageVisitor();
            var context = Parser.ros_service();

            return (ServiceDescriptor) visitor.Visit(context);
        }
        
        public static ServiceDescriptor Parse(string input)
        {
            return new ServiceDescriptorParser(new AntlrInputStream(input)).ParseDescriptor();
        }

        public static ServiceDescriptor Parse(Stream input)
        {
            return new ServiceDescriptorParser(new AntlrInputStream(input)).ParseDescriptor();
        }
    }
}