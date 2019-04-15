namespace Joanneum.Robotics.Ros.MessageParser
{
    public abstract class AbstractRosMessageListener : RosMessageParserBaseListener
    {
        public override void EnterConstant_declaration(RosMessageParser.Constant_declarationContext context)
        {
            base.EnterConstant_declaration(context);
        }
    }
}