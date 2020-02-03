using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RobSharper.Ros.MessageParser.Tests.Helpers
{
    public class TestMessageHelper
    {
        private const string TEST_MESSAGES_DIR = "TestMessages/";
        
        public static IEnumerable<TestMessage> GetFiles(string searchPattern)
        {
            if (string.IsNullOrEmpty(searchPattern))
            {
                searchPattern = "*";
            }

            var files = Directory
                .GetFiles(TEST_MESSAGES_DIR, searchPattern, SearchOption.AllDirectories)
                .Select(f => new TestMessage(f))
                .ToList();
            
            return files;
        }
    }
}