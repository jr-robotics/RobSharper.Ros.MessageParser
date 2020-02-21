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

        public static TestMessage GetActionFile(string packageName, string actionName)
        {
            var path = Path.Combine(TEST_MESSAGES_DIR, packageName, "action", $"{actionName}.action");
            return new TestMessage(path);
        }

        public static TestMessage GetMessageFile(string packageName, string messageName)
        {
            var path = Path.Combine(TEST_MESSAGES_DIR, packageName, "msg", $"{messageName}.msg");
            return new TestMessage(path);
        }

        public static TestMessage GetServiceFile(string packageName, string serviceName)
        {
            var path = Path.Combine(TEST_MESSAGES_DIR, packageName, "srv", $"{serviceName}.srv");
            return new TestMessage(path);
        }
    }
}