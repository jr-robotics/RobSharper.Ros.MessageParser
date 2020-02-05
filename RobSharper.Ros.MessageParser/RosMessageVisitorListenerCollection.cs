using System;
using System.Collections;
using System.Collections.Generic;

namespace RobSharper.Ros.MessageParser
{
    public class RosMessageVisitorListenerCollection : IRosMessageVisitorListener, IEnumerable<IRosMessageVisitorListener>
    {
        private readonly IEnumerable<IRosMessageVisitorListener> _listeners;

        public RosMessageVisitorListenerCollection(IEnumerable<IRosMessageVisitorListener> listeners)
        {
            _listeners = listeners ?? throw new ArgumentNullException(nameof(listeners));
        }
        
        public void OnVisitRosMessage(MessageDescriptor messageDescriptor)
        {
            foreach (var listener in _listeners)
            {
                listener.OnVisitRosMessage(messageDescriptor);
            }
        }

        public void OnVisitRosService(ServiceDescriptor serviceDescriptor)
        {
            foreach (var listener in _listeners)
            {
                listener.OnVisitRosService(serviceDescriptor);
            }
        }

        public void OnVisitRosAction(ActionDescriptor actionDescriptor)
        {
            foreach (var listener in _listeners)
            {
                listener.OnVisitRosAction(actionDescriptor);
            }
        }

        public void OnVisitRosbagInput(RosbagMessageDefinitionDescriptor rosbag)
        {
            foreach (var listener in _listeners)
            {
                listener.OnVisitRosbagInput(rosbag);
            }
        }

        public void OnVisitRosbagNestedType(NestedTypeDescriptor descriptor)
        {
            foreach (var listener in _listeners)
            {
                listener.OnVisitRosbagNestedType(descriptor);
            }
        }

        public void OnVisitFieldDeclaration(FieldDescriptor descriptor)
        {
            foreach (var listener in _listeners)
            {
                listener.OnVisitFieldDeclaration(descriptor);
            }
        }

        public void OnVisitConstantDeclaration(ConstantDescriptor descriptor)
        {
            foreach (var listener in _listeners)
            {
                listener.OnVisitConstantDeclaration(descriptor);
            }
        }

        public void OnVisitComment(string comment)
        {
            foreach (var listener in _listeners)
            {
                listener.OnVisitComment(comment);
            }
        }

        public void OnVisitIdentifier(string identifier)
        {
            foreach (var listener in _listeners)
            {
                listener.OnVisitIdentifier(identifier);
            }
        }

        public void OnVisitType(RosTypeInfo typeInfo)
        {
            foreach (var listener in _listeners)
            {
                listener.OnVisitType(typeInfo);
            }
        }

        public void OnVisitBuiltInType(RosTypeInfo typeInfo)
        {
            foreach (var listener in _listeners)
            {
                listener.OnVisitBuiltInType(typeInfo);
            }
        }

        public void OnVisitRosType(RosTypeInfo typeInfo)
        {
            foreach (var listener in _listeners)
            {
                listener.OnVisitRosType(typeInfo);
            }
        }

        public void OnVisitArrayType(RosTypeInfo typeInfo)
        {
            foreach (var listener in _listeners)
            {
                listener.OnVisitArrayType(typeInfo);
            }
        }

        public IEnumerator<IRosMessageVisitorListener> GetEnumerator()
        {
            return _listeners.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_listeners).GetEnumerator();
        }
    }
}