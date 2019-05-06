using System;

namespace Joanneum.Robotics.Ros.MessageParser.Examples.ListenerExample
{
    public class ConsolePrinterExample
    {
        public void PrintMessageIdentifiers(string message)
        {
            var listener = new IdentifierCollector();
            var parser = new MessageParser(message);
 
            parser.Parse(listener);
            
            Console.WriteLine($"Found {listener.Identifiers.Count} identifiers in message definition:");

            
            foreach (var identifier in listener.Identifiers)
            {
                Console.WriteLine(identifier);
            }
        }
    }
}