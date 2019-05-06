using System;
using System.IO;
using System.Net;

namespace Joanneum.Robotics.Ros.MessageParser.Examples
{
    public class ParseMessageFileExample
    {
        public void ParseFileFContent(string filePath)
        {
            var parser = new MessageParser(File.ReadAllText(filePath));
            var descriptor = parser.Parse();
        }
        
        public void ParseFileStream(string filePath)
        {
            MessageDescriptor descriptor;
            
            using (var file = File.OpenRead(filePath))
            {
                var parser = new MessageParser(file);
                descriptor = parser.Parse();
            }
        }
    }
}