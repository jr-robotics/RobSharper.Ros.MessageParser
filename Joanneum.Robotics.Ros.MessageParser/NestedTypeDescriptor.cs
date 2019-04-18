using System;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public class NestedTypeDescriptor
    {
        public RosTypeDescriptor Type { get; }
        public MessageDescriptor MessageDefinition { get; }

        public NestedTypeDescriptor(RosTypeDescriptor type, MessageDescriptor messageDefinition)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (messageDefinition == null) throw new ArgumentNullException(nameof(messageDefinition));
            
            Type = type;
            MessageDefinition = messageDefinition;
        }
    }
}