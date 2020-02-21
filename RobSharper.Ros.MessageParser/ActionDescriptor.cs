using System;

namespace RobSharper.Ros.MessageParser
{
    public class ActionDescriptor
    {
        public MessageDescriptor Goal { get; }
        
        public MessageDescriptor Result { get; }
        
        public MessageDescriptor Feedback { get; }
        
        public ActionDescriptor(MessageDescriptor goal, MessageDescriptor result, MessageDescriptor feedback)
        {
            Goal = goal ?? throw new ArgumentNullException(nameof(goal));
            Result = result ?? throw new ArgumentNullException(nameof(result));
            Feedback = feedback ?? throw new ArgumentNullException(nameof(feedback));
        }
    }
}