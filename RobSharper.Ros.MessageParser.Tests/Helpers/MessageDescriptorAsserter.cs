using System;
using System.Linq;
using Xunit;

namespace RobSharper.Ros.MessageParser.Tests.Helpers
{
    public class MessageDescriptorAsserter
    {
        private readonly MessageDescriptor _message;

        public MessageDescriptorAsserter(MessageDescriptor message)
        {
            _message = message ?? throw new ArgumentNullException(nameof(message));
        }

        public void FieldNameExists(string expectedIdentifier)
        {
            Assert.True(_message.Fields.Any(f => f.Identifier == expectedIdentifier),
                $"Message should contain a field named {expectedIdentifier}");
        }

        public void ConstantNameExists(string expectedIdentifier)
        {
            Assert.True(_message.Constants.Any(f => f.Identifier == expectedIdentifier),
                $"Message should contain a constant named {expectedIdentifier}");
        }
    }
}