using System;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public class ConstantDescriptor
    {
        public PrimitiveTypeDescriptor TypeDescriptor { get; }

        public Type Type => TypeDescriptor.Type;
        public string Identifier { get; }
        public object Value { get; }
        public string Comment { get; }

        protected ConstantDescriptor(PrimitiveTypeDescriptor typeDescriptor, string identifier, object value, string comment)
        {
            if (typeDescriptor == null) throw new ArgumentNullException(nameof(typeDescriptor));
            if (identifier == null) throw new ArgumentNullException(nameof(identifier));
            if (value == null) throw new ArgumentNullException(nameof(value));
            
            TypeDescriptor = typeDescriptor;
            Identifier = identifier;
            Value = value;
            Comment = comment;
        }

        public static ConstantDescriptor Create(PrimitiveTypeDescriptor type, string identifier, object value, string comment)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (value == null) throw new ArgumentNullException(nameof(value));

            // Fix value type
            var converter = System.ComponentModel.TypeDescriptor.GetConverter(type.Type);

            if (!converter.CanConvertFrom(value.GetType()))
            {
                throw new InvalidOperationException($"Cannot convert from {value.GetType()} to {type.Type}");
            }

            value = converter.ConvertFrom(value);

            return new ConstantDescriptor(type, identifier, value, comment);
        }
    }
}