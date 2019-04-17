using System;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public class ServiceDescriptor
    {
        public MessageDescriptor Request { get; }

        public MessageDescriptor Response { get; }
        
        public ServiceDescriptor(MessageDescriptor request, MessageDescriptor response)
        {
            Request = request ?? throw new ArgumentNullException(nameof(request));
            Response = response ?? throw new ArgumentNullException(nameof(response));
        }
    }
}