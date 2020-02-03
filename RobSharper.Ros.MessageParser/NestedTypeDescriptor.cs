using System;

namespace RobSharper.Ros.MessageParser
{
    public class NestedTypeDescriptor
    {
        public RosTypeInfo TypeInfo { get; }
        public MessageDescriptor MessageDefinition { get; }

        public NestedTypeDescriptor(RosTypeInfo typeInfo, MessageDescriptor messageDefinition)
        {
            if (typeInfo == null) throw new ArgumentNullException(nameof(typeInfo));
            if (messageDefinition == null) throw new ArgumentNullException(nameof(messageDefinition));
            
            TypeInfo = typeInfo;
            MessageDefinition = messageDefinition;
        }
    }
}