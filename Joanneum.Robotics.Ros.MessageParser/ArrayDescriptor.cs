using System;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public class ArrayDescriptor
    {
        private int? _size;
        
        public object Type { get; }
        public bool IsFixedSize => Size.HasValue;

        public int? Size
        {
            get
            {
                return _size; 
            }
            private set
            {
                if (value.HasValue && value.Value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Array size must be larger than zero");
                }
                
                _size = value;
            }
        }

        public ArrayDescriptor(PrimitiveTypeDescriptor primitiveType, int? size)
        {
            if (primitiveType == null)
            {
                throw new ArgumentNullException(nameof(primitiveType));
            }
            
            Type = primitiveType;
            Size = size;
        }

        public ArrayDescriptor(RosTypeDescriptor rosType, int? size)
        {
            if (rosType == null)
            {
                throw new ArgumentNullException(nameof(rosType));
            }
            
            Type = rosType;
            Size = size;
        }

        public static ArrayDescriptor Create(object type, int? size = null)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            
            if (type is RosTypeDescriptor complexDescriptor)
            {
                return new ArrayDescriptor(complexDescriptor, size);
            }

            if (type is PrimitiveTypeDescriptor primitiveDescriptor)
            {
                return new ArrayDescriptor(primitiveDescriptor, size);
            }
            
            throw new ArgumentException($"Type {type.GetType()} is not supported.", nameof(type));
        }
    }
}