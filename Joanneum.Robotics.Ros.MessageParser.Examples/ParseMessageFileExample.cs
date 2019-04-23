using System;
using System.IO;
using System.Net;

namespace Joanneum.Robotics.Ros.MessageParser.Examples
{
    public class ParseMessageFileExample
    {
        public void ParseFileFContent(string filePath)
        {
            var descriptor = MessageParser.Parse(File.ReadAllText(filePath));
        }
        
        public void ParseFileStream(string filePath)
        {
            MessageDescriptor descriptor;
            
            using (var file = File.OpenRead(filePath))
            {
                descriptor = MessageParser.Parse(file);
            }
        }
    }
}