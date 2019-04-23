namespace Joanneum.Robotics.Ros.MessageParser
{
    class EmptyRosMessageVisitorListener : IRosMessageVisitorListener
    {
        public static readonly EmptyRosMessageVisitorListener Instance = new EmptyRosMessageVisitorListener();
        
        public void OnVisitRosMessage(MessageDescriptor messageDescriptor)
        {
        }

        public void OnVisitRosService(ServiceDescriptor serviceDescriptor)
        {
        }

        public void OnVisitRosAction(ActionDescriptor actionDescriptor)
        {
        }

        public void OnVisitRosbagInput(RosbagMessageDefinitionDescriptor rosbag)
        {
        }

        public void OnVisitRosbagNestedType(NestedTypeDescriptor descriptor)
        {
        }

        public void OnVisitFieldDeclaration(FieldDescriptor descriptor)
        {
        }

        public void OnVisitConstantDeclaration(ConstantDescriptor descriptor)
        {
        }

        public void OnVisitComment(string comment)
        {
        }

        public void OnVisitIdentifier(string identifier)
        {
        }

        public void OnVisitArrayType(ArrayTypeInfo typeInfo)
        {
        }

        public void OnVisitPrimitiveType(PrimitiveTypeInfo typeInfo)
        {
        }

        public void OnVisitRosType(RosTypeInfo typeInfo)
        {
        }
    }
}