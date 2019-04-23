using System;
using System.Globalization;
using Antlr4.Runtime;
using Joanneum.Robotics.Ros.MessageParser.Antlr;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public class RosMessageVisitor : RosMessageParserBaseVisitor<object>
    {

        private static object GetPrimitiveTye(ParserRuleContext context)
        {
            var rosType = context.GetText();
            var t = PrimitiveTypeInfo.Parse(rosType);

            return t;
        }

        protected override object AggregateResult(object aggregate, object nextResult)
        {
            if (aggregate != null && nextResult != null)
            {
                throw new InvalidOperationException("Two nodes should not be merged this way!");
            }

            if (nextResult == null)
            {
                return aggregate;
            }

            return nextResult;
        }

        public override object VisitIntegral_type(RosMessageParser.Integral_typeContext context)
        {
            return GetPrimitiveTye(context);
        }

        public override object VisitFloating_point_type(RosMessageParser.Floating_point_typeContext context)
        {
            return GetPrimitiveTye(context);
        }

        public override object VisitTemportal_type(RosMessageParser.Temportal_typeContext context)
        {
            return GetPrimitiveTye(context);
        }

        public override object VisitString_type(RosMessageParser.String_typeContext context)
        {
            return GetPrimitiveTye(context);
        }
        
        public override object VisitBoolean_type(RosMessageParser.Boolean_typeContext context)
        {
            return GetPrimitiveTye(context);
        }

        public override object VisitBase_type(RosMessageParser.Base_typeContext context)
        {
            var baseType = (PrimitiveTypeInfo) base.VisitBase_type(context);
            baseType = OnVisitBaseType(baseType);
            
            return baseType;
        }

        protected internal virtual PrimitiveTypeInfo OnVisitBaseType(PrimitiveTypeInfo typeInfoDescriptor)
        {
            return typeInfoDescriptor;
        }

        public override object VisitRos_type(RosMessageParser.Ros_typeContext context)
        {
            string packageName = null;
            string typeName = null;
            
            if (context.ChildCount == 1)
            {
                typeName = context.GetChild(0).GetText();

                if (typeName == "Header")
                {
                    packageName = "std_msgs";
                }
            }
            else
            {                
                packageName = context.GetChild(0).GetText();
                typeName = context.GetChild(2).GetText();
            }
            
            var messageType =  new RosTypeInfo(typeName, packageName);
            messageType = OnVisitRosType(messageType);
            
            return messageType;
        }

        protected internal virtual RosTypeInfo OnVisitRosType(RosTypeInfo typeInfo)
        {
            return typeInfo;
        }


        public override object VisitVariable_array_type(RosMessageParser.Variable_array_typeContext context)
        {
            var type = (IRosTypeInfo) Visit(context.GetChild(0));
            var arrayDescriptor = ArrayTypeInfo.Create(type);

            return arrayDescriptor;
        }

        public override object VisitFixed_array_type(RosMessageParser.Fixed_array_typeContext context)
        {
            var type = (IRosTypeInfo) Visit(context.GetChild(0));
            var size = int.Parse(context.GetChild(2).GetText());
            var arrayDescriptor = ArrayTypeInfo.Create(type, size);

            return arrayDescriptor;
        }

        public override object VisitArray_type(RosMessageParser.Array_typeContext context)
        {
            var descriptor = (ArrayTypeInfo) base.VisitArray_type(context);
            descriptor = OnVisitArrayType(descriptor);

            return descriptor;
        }

        protected internal virtual ArrayTypeInfo OnVisitArrayType(ArrayTypeInfo arrayTypeInfo)
        {
            return arrayTypeInfo;
        }

        public override object VisitComment(RosMessageParser.CommentContext context)
        {
            string comment;

            if (context.ChildCount == 1)
            {
                comment = string.Empty;
            }
            else
            {
                comment = context.GetChild(1).GetText().Trim();
            }
            
            comment = OnVisitComment(comment);
            return comment;
        }

        protected internal virtual string OnVisitComment(string comment)
        {
            return comment;
        }

        public override object VisitIdentifier(RosMessageParser.IdentifierContext context)
        {
            var identifier = context.GetText();
            identifier = OnVisitIdentifier(identifier);
            return identifier;
        }

        protected internal virtual string OnVisitIdentifier(string identifier)
        {
            return identifier;
        }

        public override object VisitField_declaration(RosMessageParser.Field_declarationContext context)
        {
            var type = (IRosTypeInfo) Visit(context.GetChild(0));
            var identifier = (string) Visit(context.GetChild(1));

            var fieldDescriptor = new FieldDescriptor(type, identifier);
            fieldDescriptor = OnVisitFieldDeclaration(fieldDescriptor);
            
            return fieldDescriptor;
        }

        protected internal virtual  FieldDescriptor OnVisitFieldDeclaration(FieldDescriptor fieldDescriptor)
        {
            return fieldDescriptor;
        }

        public override object VisitConstant_declaration(RosMessageParser.Constant_declarationContext context)
        {
            var type = (PrimitiveTypeInfo) Visit(context.GetChild(0));
            var identifier = (string) Visit(context.GetChild(1));
            // child 2 = '='
            var value = Visit(context.GetChild(3));

            var constDescriptor = ConstantDescriptor.Create(type, identifier, value);

            constDescriptor = OnVisitConstantDeclaration(constDescriptor);
            return constDescriptor;
        }

        protected internal virtual  ConstantDescriptor OnVisitConstantDeclaration(ConstantDescriptor constDescriptor)
        {
            return constDescriptor;
        }

        public override object VisitBool_value(RosMessageParser.Bool_valueContext context)
        {
            var value = bool.Parse(context.GetText().ToLower());
            return value;
        }

        public override object VisitIntegral_value(RosMessageParser.Integral_valueContext context)
        {
            var strValue = context.GetText();
            var value = int.Parse(strValue, CultureInfo.InvariantCulture);

            return value;
        }

        public override object VisitFloating_point_value(RosMessageParser.Floating_point_valueContext context)
        {
            var strValue = context.GetText();
            var value = double.Parse(strValue, CultureInfo.InvariantCulture);

            return value;
        }

        public override object VisitString_value(RosMessageParser.String_valueContext context)
        {
            var strValue = context.GetText().Trim();
            return strValue;
        }

        public override object VisitRos_message(RosMessageParser.Ros_messageContext context)
        {
            var messageDescriptor = new MessageDescriptor();
            
            for (int i = 0; i < context.ChildCount; ++i)
            {
                var result = Visit(context.GetChild(i));

                if (result is FieldDescriptor field)
                {
                    messageDescriptor.AddField(field);
                }

                if (result is ConstantDescriptor constant)
                {
                    messageDescriptor.AddConstant(constant);
                }

                if (result is string comment)
                {
                    messageDescriptor.AddComment(comment);
                }
            }

            messageDescriptor = OnVisitRosMessage(messageDescriptor);
            return messageDescriptor;
        }

        protected internal virtual MessageDescriptor OnVisitRosMessage(MessageDescriptor messageDescriptor)
        {
            return messageDescriptor;
        }

//        public override object VisitRos_message_input(RosMessageParser.Ros_message_inputContext context)
//        {
//            return Visit(context.GetChild(0));
//        }

        public override object VisitRos_service_input(RosMessageParser.Ros_service_inputContext context)
        {
            var request = (MessageDescriptor) Visit(context.GetChild(0));
            var response = (MessageDescriptor) Visit(context.GetChild(2));

            var serviceDescriptor = new ServiceDescriptor(request, response);
            serviceDescriptor = OnVisitRosService(serviceDescriptor);
            
            return serviceDescriptor;
        }

        protected internal virtual  ServiceDescriptor OnVisitRosService(ServiceDescriptor serviceDescriptor)
        {
            return serviceDescriptor;
        }

        public override object VisitRos_action_input(RosMessageParser.Ros_action_inputContext context)
        {
            var goal = (MessageDescriptor) Visit(context.GetChild(0));
            var feedback = (MessageDescriptor) Visit(context.GetChild(2));
            var result = (MessageDescriptor) Visit(context.GetChild(4));

            var actionDescriptor = new ActionDescriptor(goal, feedback, result);
            actionDescriptor = OnVisitRosAction(actionDescriptor);

            return actionDescriptor;
        }

        protected internal virtual ActionDescriptor OnVisitRosAction(ActionDescriptor actionDescriptor)
        {
            return actionDescriptor;
        }

        public override object VisitRosbag_input(RosMessageParser.Rosbag_inputContext context)
        {
            var message = (MessageDescriptor) Visit(context.GetChild(0));
            var rosbag = new RosbagMessageDefinitionDescriptor(message);
            
            for (var i = 1; i < context.ChildCount - 1; i++)
            {
                var nestedMessage = (NestedTypeDescriptor) Visit(context.GetChild(i));
                rosbag.AddNestedMessage(nestedMessage);
            }
            
            // CHILD(n) = <EOF>

            rosbag = OnVisitRosbagInput(rosbag);
            return rosbag;
        }

        protected internal virtual RosbagMessageDefinitionDescriptor OnVisitRosbagInput(RosbagMessageDefinitionDescriptor rosbag)
        {
            return rosbag;
        }

        public override object VisitRosbag_nested_message(RosMessageParser.Rosbag_nested_messageContext context)
        {
            // Child(0) = message separator
            var key = (RosTypeInfo) Visit(context.GetChild(1));
            var value = (MessageDescriptor) Visit(context.GetChild(2));

            var descriptor = new NestedTypeDescriptor(key, value);

            descriptor = OnVisitRosbagNestedType(descriptor);
            
            return descriptor;
        }

        protected internal NestedTypeDescriptor OnVisitRosbagNestedType(NestedTypeDescriptor descriptor)
        {
            return descriptor;
        }
    }
}