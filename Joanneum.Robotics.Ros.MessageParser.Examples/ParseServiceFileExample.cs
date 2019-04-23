using System.IO;

namespace Joanneum.Robotics.Ros.MessageParser.Examples
{
    public class ParseServiceFileExample
    {
        public void ParseFileFContent(string filePath)
        {
            var descriptor = ServiceParser.Parse(File.ReadAllText(filePath));
        }
        
        public void ParseFileStream(string filePath)
        {
            ServiceDescriptor descriptor;
            
            using (var file = File.OpenRead(filePath))
            {
                descriptor = ServiceParser.Parse(file);
            }
        }
    }
}