namespace RobSharper.Ros.MessageParser.Tests.Helpers
{
    public static class MessageDescriptorExtensions
    {
        public static MessageDescriptorAsserter AssertThat(this MessageDescriptor message)
        {
            return new MessageDescriptorAsserter(message);
        }
    }
}