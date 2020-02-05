using System;
using System.IO;

namespace RobSharper.Ros.MessageParser.Tests.Helpers
{
    public class TestMessage
    {
        private Lazy<string> _content;
        
        public string FilePath { get; }
        
        public Lazy<string> Content
        {
            get { return _content; }
        }

        public TestMessage(string path)
        {
            FilePath = path;
            _content = new Lazy<string>(() => File.ReadAllText(path));
        }

        public override string ToString()
        {
            return FilePath;
        }
    }
}