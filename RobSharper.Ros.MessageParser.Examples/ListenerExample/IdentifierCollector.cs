using System;
using System.Collections.Generic;
using RobSharper.Ros.MessageParser;

namespace RobSharper.Ros.MessageParser.Examples.ListenerExample
{
    public class IdentifierCollector : DefaultRosMessageVisitorListener 
    {
        private readonly List<string> _identifiers = new List<string>();

        public List<string> Identifiers => _identifiers;
        
        public override void OnVisitIdentifier(string identifier)
        {
            _identifiers.Add(identifier);
        }
    }
}