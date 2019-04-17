using System;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public class ConstantDescriptor
    {
        public PrimitiveTypeDescriptor TypeDescriptor { get; }

        public Type Type => TypeDescriptor.Type;
        public string Identifier { get; }
        public object Value { get; }

        protected ConstantDescriptor(PrimitiveTypeDescriptor typeDescriptor, string identifier, object value)
        {
            if (typeDescriptor == null) throw new ArgumentNullException(nameof(typeDescriptor));
            if (identifier == null) throw new ArgumentNullException(nameof(identifier));
            if (value == null) throw new ArgumentNullException(nameof(value));
            
            TypeDescriptor = typeDescriptor;
            Identifier = identifier;
            Value = value;
        }

        public static ConstantDescriptor Create(PrimitiveTypeDescriptor type, string identifier, object value)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (value == null) throw new ArgumentNullException(nameof(value));

            // Fix value type
            var converter = System.ComponentModel.TypeDescriptor.GetConverter(value.GetType());
            
            if (converter.CanConvertTo(type.Type))
            {
                value = converter.ConvertTo(value, type.Type);
            }
            else
            {
                throw new InvalidOperationException($"Cannot convert from {value.GetType()} to {type.Type}");
            }

            return new ConstantDescriptor(type, identifier, value);
        }
    }
}