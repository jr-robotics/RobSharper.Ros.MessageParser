using System;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public class ActionDescriptor
    {
        public MessageDescriptor Goal { get; }
        
        public MessageDescriptor Feedback { get; }
        
        public MessageDescriptor Result { get; }
        
        public ActionDescriptor(MessageDescriptor goal, MessageDescriptor feedback, MessageDescriptor result)
        {
            Goal = goal ?? throw new ArgumentNullException(nameof(goal));
            Feedback = feedback ?? throw new ArgumentNullException(nameof(feedback));
            Result = result ?? throw new ArgumentNullException(nameof(result));
        }
    }
}