namespace Joanneum.Robotics.Ros.MessageParser
{
    public abstract class AbstractRosMessageListener : RosMessageBaseListener
    {
        public override void EnterConstant_declaration(RosMessageParser.Constant_declarationContext context)
        {
            base.EnterConstant_declaration(context);
        }
    }
}