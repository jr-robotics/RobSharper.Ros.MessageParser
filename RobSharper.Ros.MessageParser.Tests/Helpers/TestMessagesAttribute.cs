using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;

namespace RobSharper.Ros.MessageParser.Tests.Helpers
{
    public class TestMessagesAttribute : DataAttribute
    {
        public string SearchPattern { get; set; }
        
        public TestMessagesAttribute(string searchPattern)
        {
            SearchPattern = searchPattern;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null) { throw new ArgumentNullException(nameof(testMethod)); }
            
            var files = TestMessageHelper.GetFiles(SearchPattern);
            
            if (!files.Any())
            {
                throw new ArgumentException($"Could not find any message files matching {SearchPattern}");
            }

            var fileContents = files
                .Select(f => new object[] {f})
                .ToList();

            return fileContents;
        }
    }
}