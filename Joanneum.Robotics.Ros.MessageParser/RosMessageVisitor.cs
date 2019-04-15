using Antlr4.Runtime;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public class RosMessageVisitor : RosMessageBaseVisitor<object>
    {

        private static object GetPrimitiveTye(ParserRuleContext context)
        {
            var rosType = context.GetText();
            var t = PrimitiveTypeDescriptor.Parse(rosType);

            return t;
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
            var baseType = (PrimitiveTypeDescriptor) base.VisitBase_type(context);
            baseType = OnVisitBaseType(baseType);
            
            return baseType;
        }

        protected internal virtual PrimitiveTypeDescriptor OnVisitBaseType(PrimitiveTypeDescriptor typeDescriptor)
        {
            return typeDescriptor;
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
            
            var messageType =  new RosTypeDescriptor(typeName, packageName);
            messageType = OnVisitRosType(messageType);
            
            return messageType;
        }

        protected internal virtual RosTypeDescriptor OnVisitRosType(RosTypeDescriptor typeDescriptor)
        {
            return typeDescriptor;
        }


        public override object VisitVariable_array_type(RosMessageParser.Variable_array_typeContext context)
        {
            var type = Visit(context.GetChild(0));
            var arrayDescriptor = ArrayDescriptor.Create(type);

            return arrayDescriptor;
        }

        public override object VisitFixed_array_type(RosMessageParser.Fixed_array_typeContext context)
        {
            var type = Visit(context.GetChild(0));
            var size = int.Parse(context.GetChild(2).GetText());
            var arrayDescriptor = ArrayDescriptor.Create(type, size);

            return arrayDescriptor;
        }

        public override object VisitComment(RosMessageParser.CommentContext context)
        {
            var comment = context.GetText().Substring(1);
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
            var type = Visit(context.GetChild(0));
            var identifier = (string) Visit(context.GetChild(1));

            var fieldDescriptor = new FieldDescriptor(type, identifier);
            return fieldDescriptor;
        }

        public override object VisitConstant_declaration(RosMessageParser.Constant_declarationContext context)
        {
            var type = (PrimitiveTypeDescriptor) Visit(context.GetChild(0));
            var identifier = (string) Visit(context.GetChild(1));
            // child 2 = '='
            var value = Visit(context.GetChild(3));

            var constDescriptor = ConstantDescriptor.Create(type, identifier, value);
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
            var value = int.Parse(strValue);

            return value;
        }

        public override object VisitFloating_point_value(RosMessageParser.Floating_point_valueContext context)
        {
            var strValue = context.GetText();
            var value = double.Parse(strValue);

            return value;
        }
    }
}