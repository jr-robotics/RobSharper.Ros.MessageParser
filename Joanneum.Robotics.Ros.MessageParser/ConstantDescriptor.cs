using System;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public class ConstantDescriptor
    {
        public PrimitiveTypeInfo TypeInfo { get; }
        public string Identifier { get; }
        public object Value { get; }

        protected ConstantDescriptor(PrimitiveTypeInfo typeInfo, string identifier, object value)
        {
            if (typeInfo == null) throw new ArgumentNullException(nameof(typeInfo));
            if (identifier == null) throw new ArgumentNullException(nameof(identifier));
            if (value == null) throw new ArgumentNullException(nameof(value));
            
            TypeInfo = typeInfo;
            Identifier = identifier;
            Value = value;
        }

        public static ConstantDescriptor Create(PrimitiveTypeInfo typeInfo, string identifier, object value)
        {
            if (typeInfo == null) throw new ArgumentNullException(nameof(typeInfo));
            if (value == null) throw new ArgumentNullException(nameof(value));

            // Fix value type
            var converter = System.ComponentModel.TypeDescriptor.GetConverter(value.GetType());
            
            if (converter.CanConvertTo(typeInfo.Type))
            {
                value = converter.ConvertTo(value, typeInfo.Type);
            }
            else
            {
                throw new InvalidOperationException($"Cannot convert from {value.GetType()} to {typeInfo.Type}");
            }

            return new ConstantDescriptor(typeInfo, identifier, value);
        }
    }
}