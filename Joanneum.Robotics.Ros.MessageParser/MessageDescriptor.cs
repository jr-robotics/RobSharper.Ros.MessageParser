using System.Collections.Generic;
using System.Linq;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public class MessageDescriptor
    {
        private readonly ICollection<object> _items = new List<object>();
        private readonly ICollection<FieldDescriptor> _fields = new List<FieldDescriptor>();
        private readonly ICollection<ConstantDescriptor> _constants = new List<ConstantDescriptor>();
        private readonly ICollection<string> _comments = new List<string>();

        public IEnumerable<object> Items => _items;
        
        public IEnumerable<FieldDescriptor> Fields => _fields;

        public IEnumerable<ConstantDescriptor> Constants => _constants;

        public IEnumerable<string> Comments => _comments;

        public bool IsEmpty => _items.Count == 0;


        public void AddField(FieldDescriptor descriptor)
        {
            _items.Add(descriptor);
            _fields.Add(descriptor);
        }

        public void AddConstant(ConstantDescriptor descriptor)
        {
            _items.Add(descriptor);
            _constants.Add(descriptor);
        }

        public void AddComment(string comment)
        {
            _items.Add(comment);
            _comments.Add(comment);
        }
    }
}