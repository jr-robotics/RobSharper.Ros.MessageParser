using System.IO;

namespace Joanneum.Robotics.Ros.MessageParser.Examples
{
    public class ParseServiceFileExample
    {
        public void ParseFileFContent(string filePath)
        {
            var parser = new ServiceParser(File.ReadAllText(filePath));
            var descriptor = parser.Parse();
        }
        
        public void ParseFileStream(string filePath)
        {
            ServiceDescriptor descriptor;
            
            using (var file = File.OpenRead(filePath))
            {
                
                var parser = new ServiceParser(file);
                descriptor = parser.Parse();
            }
        }
    }
}