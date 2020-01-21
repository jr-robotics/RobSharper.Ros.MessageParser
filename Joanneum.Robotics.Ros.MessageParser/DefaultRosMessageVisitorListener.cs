namespace Joanneum.Robotics.Ros.MessageParser
{
    public class DefaultRosMessageVisitorListener : IRosMessageVisitorListener
    {
        public static readonly DefaultRosMessageVisitorListener Default = new DefaultRosMessageVisitorListener();
        
        public virtual void OnVisitRosMessage(MessageDescriptor messageDescriptor)
        {
        }

        public virtual void OnVisitRosService(ServiceDescriptor serviceDescriptor)
        {
        }

        public virtual void OnVisitRosAction(ActionDescriptor actionDescriptor)
        {
        }

        public virtual void OnVisitRosbagInput(RosbagMessageDefinitionDescriptor rosbag)
        {
        }

        public virtual void OnVisitRosbagNestedType(NestedTypeDescriptor descriptor)
        {
        }

        public virtual void OnVisitFieldDeclaration(FieldDescriptor descriptor)
        {
        }

        public virtual void OnVisitConstantDeclaration(ConstantDescriptor descriptor)
        {
        }

        public virtual void OnVisitComment(string comment)
        {
        }

        public virtual void OnVisitIdentifier(string identifier)
        {
        }

        public virtual void OnVisitType(RosTypeInfo typeInfo)
        {
        }

        public virtual void OnVisitRosType(RosTypeInfo typeInfo)
        {
        }

        public virtual void OnVisitArrayType(RosTypeInfo typeInfo)
        {
        }

        public virtual void OnVisitBuiltInType(RosTypeInfo typeInfo)
        {
        }
    }
}