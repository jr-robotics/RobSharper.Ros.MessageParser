using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public class RosbagMessageDefinitionDescriptor
    {
        private readonly IDictionary<RosTypeDescriptor, MessageDescriptor> _nestedMessages = new Dictionary<RosTypeDescriptor, MessageDescriptor>();
        public MessageDescriptor Message { get; }

        public IReadOnlyDictionary<RosTypeDescriptor, MessageDescriptor> NestedMessages
        {
            get { return new ReadOnlyDictionary<RosTypeDescriptor, MessageDescriptor>(_nestedMessages); }
        }

        public RosbagMessageDefinitionDescriptor(MessageDescriptor message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            
            Message = message;
        }

        public void AddNestedMessage(NestedTypeDescriptor nestedMessage)
        {
            if (nestedMessage == null) throw new ArgumentNullException(nameof(nestedMessage));
            
            _nestedMessages.Add(nestedMessage.Type, nestedMessage.MessageDefinition);
        }
    }
}