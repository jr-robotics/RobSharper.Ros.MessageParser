using System.IO;

namespace Joanneum.Robotics.Ros.MessageParser.Examples
{
    public class ParseActionFileExample
    {
        public void ParseFileFContent(string filePath)
        {
            var parser = new ActionParser(File.ReadAllText(filePath));
            var descriptor = parser.Parse();
        }
        
        public void ParseFileStream(string filePath)
        {
            ActionDescriptor descriptor;
            
            using (var file = File.OpenRead(filePath))
            {
                var parser = new ActionParser(file);
                descriptor = parser.Parse();
            }
        }
    }
}