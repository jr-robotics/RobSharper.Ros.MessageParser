using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RobSharper.Ros.MessageParser
{
    public class RosbagMessageDefinitionDescriptor
    {
        private readonly IDictionary<RosTypeInfo, MessageDescriptor> _nestedMessages = new Dictionary<RosTypeInfo, MessageDescriptor>();
        public MessageDescriptor Message { get; }

        public IReadOnlyDictionary<RosTypeInfo, MessageDescriptor> NestedMessages
        {
            get { return new ReadOnlyDictionary<RosTypeInfo, MessageDescriptor>(_nestedMessages); }
        }

        public RosbagMessageDefinitionDescriptor(MessageDescriptor message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            
            Message = message;
        }

        public void AddNestedMessage(NestedTypeDescriptor nestedMessage)
        {
            if (nestedMessage == null) throw new ArgumentNullException(nameof(nestedMessage));
            
            _nestedMessages.Add(nestedMessage.TypeInfo, nestedMessage.MessageDefinition);
        }
    }
}