using System;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public class NestedTypeDescriptor
    {
        public RosTypeDescriptor Type { get; }
        public MessageDescriptor Descriptor { get; }

        public NestedTypeDescriptor(RosTypeDescriptor type, MessageDescriptor descriptor)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (descriptor == null) throw new ArgumentNullException(nameof(descriptor));
            
            Type = type;
            Descriptor = descriptor;
        }
    }
}