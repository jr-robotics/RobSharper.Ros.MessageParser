using Antlr4.Runtime;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public abstract class RosMessageVisitor : RosMessageBaseVisitor<object>
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
            return messageType;
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
            return context.GetText().Substring(1);
        }

        public override object VisitIdentifier(RosMessageParser.IdentifierContext context)
        {
            return context.GetText();
        }

        public override object VisitField_declaration(RosMessageParser.Field_declarationContext context)
        {
            var type = Visit(context.GetChild(0));
            var identifier = (string) Visit(context.GetChild(1));
            string comment = null;

            if (context.ChildCount > 2)
            {
                comment = (string) Visit(context.GetChild(2));
            }

            var fieldDescriptor = new FieldDescriptor(type, identifier, comment);
            return fieldDescriptor;
        }

        public override object VisitConstant_declaration(RosMessageParser.Constant_declarationContext context)
        {
            var type = (PrimitiveTypeDescriptor) Visit(context.GetChild(0));
            var identifier = (string) Visit(context.GetChild(1));
            // child 2 = '='
            var value = Visit(context.GetChild(3));
            
            string comment = null;

            if (context.ChildCount > 4)
            {
                comment = (string) Visit(context.GetChild(4));
            }

            var constDescriptor = ConstantDescriptor.Create(type, identifier, value, comment);
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