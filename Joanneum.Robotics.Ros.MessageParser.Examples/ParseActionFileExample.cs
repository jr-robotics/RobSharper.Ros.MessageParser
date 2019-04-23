using System.IO;

namespace Joanneum.Robotics.Ros.MessageParser.Examples
{
    public class ParseActionFileExample
    {
        public void ParseFileFContent(string filePath)
        {
            var descriptor = ActionParser.Parse(File.ReadAllText(filePath));
        }
        
        public void ParseFileStream(string filePath)
        {
            ActionDescriptor descriptor;
            
            using (var file = File.OpenRead(filePath))
            {
                descriptor = ActionParser.Parse(file);
            }
        }
    }
}