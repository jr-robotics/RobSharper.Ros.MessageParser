using System;

namespace RobSharper.Ros.MessageParser
{
    public class ConstantDescriptor
    {
        public RosTypeInfo TypeInfo { get; }
        public string Identifier { get; }
        public object Value { get; }

        protected ConstantDescriptor(RosTypeInfo typeInfo, string identifier, object value)
        {
            if (typeInfo == null) throw new ArgumentNullException(nameof(typeInfo));
            if (identifier == null) throw new ArgumentNullException(nameof(identifier));
            if (value == null) throw new ArgumentNullException(nameof(value));
            
            TypeInfo = typeInfo;
            Identifier = identifier;
            Value = value;
        }

        public static ConstantDescriptor Create(RosTypeInfo typeInfo, string identifier, object value)
        {
            if (typeInfo == null) throw new ArgumentNullException(nameof(typeInfo));
            if (value == null) throw new ArgumentNullException(nameof(value));

            if (typeInfo.IsArray || !typeInfo.IsBuiltInType)
            {
                throw new InvalidOperationException($"Type {typeInfo} is not supported for constant declaration");
            }

            var typeMapping = BuiltInTypeMapping.Create(typeInfo);
            
            if (typeMapping.Type != value.GetType())
            {
                // Fix value type
                var converter = System.ComponentModel.TypeDescriptor.GetConverter(value.GetType());

                if (converter.CanConvertTo(typeMapping.Type))
                {
                    value = converter.ConvertTo(value, typeMapping.Type);
                }
                else
                {
                    throw new InvalidOperationException($"Cannot convert from {value.GetType()} to {typeMapping.Type}");
                }
            }

            return new ConstantDescriptor(typeInfo, identifier, value);
        }
    }
}