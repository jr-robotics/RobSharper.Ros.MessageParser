using Antlr4.Runtime;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public abstract class AbstractParser<TDescriptor>
    {
        protected RosMessageParser Parser { get; }

        public AbstractParser(ICharStream input)
        {
            var messageLexer = new RosMessageLexer(input);
            var tokenStream = new CommonTokenStream(messageLexer);
            
            Parser = new RosMessageParser(tokenStream);
        }

        public abstract TDescriptor Parse();
    }
}