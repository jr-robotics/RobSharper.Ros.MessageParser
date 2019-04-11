using System;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public class FieldDescriptor
    {
        public object Type { get; }
        public object UnderlyingType { get; }
        
        public bool IsArray { get; }

        public int? ArraySize
        {
            get
            {
                if (!IsArray)
                    throw new InvalidOperationException();

                return ((ArrayDescriptor) Type).Size;
            }
        }

        public bool IsPrimitiveType => PrimitiveUnderlyingType != null;

        public PrimitiveTypeDescriptor PrimitiveUnderlyingType => UnderlyingType as PrimitiveTypeDescriptor;
        public RosTypeDescriptor RosUnderlyingType => UnderlyingType as RosTypeDescriptor;

        public string Identifier { get; }
        public string Comment { get; }

        public FieldDescriptor(object type, string identifier, string comment)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (identifier == null) throw new ArgumentNullException(nameof(identifier));

            Type = type;
            Identifier = identifier;
            Comment = comment;

            if (type is ArrayDescriptor arrayType)
            {
                IsArray = true;
                UnderlyingType = arrayType.Type;
            }
            else
            {
                UnderlyingType = type;
            }
        }
        
        
    }
}