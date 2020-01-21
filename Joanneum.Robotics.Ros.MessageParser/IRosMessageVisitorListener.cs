using System;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public interface IRosMessageVisitorListener
    {
        void OnVisitRosMessage(MessageDescriptor messageDescriptor);
        void OnVisitRosService(ServiceDescriptor serviceDescriptor);
        void OnVisitRosAction(ActionDescriptor actionDescriptor);

        void OnVisitRosbagInput(RosbagMessageDefinitionDescriptor rosbag);
        void OnVisitRosbagNestedType(NestedTypeDescriptor descriptor);
        
        void OnVisitFieldDeclaration(FieldDescriptor descriptor);
        void OnVisitConstantDeclaration(ConstantDescriptor descriptor);
        void OnVisitComment(string comment);
        
        void OnVisitIdentifier(string identifier);

        void OnVisitType(RosTypeInfo typeInfo);
        void OnVisitBuiltInType(RosTypeInfo typeInfo);
        void OnVisitRosType(RosTypeInfo typeInfo);
        void OnVisitArrayType(RosTypeInfo typeInfo);
    }
}