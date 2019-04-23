using System;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public class ArrayTypeInfo : IRosTypeInfo, IRosArrayTypeInfo
    {
        private int? _size;
        private readonly IRosTypeInfo _underlyingType;

        public bool IsArray => true;
        public bool IsPrimitive => false;

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

        public ArrayTypeInfo(PrimitiveTypeInfo primitiveTypeInfo, int? size)
        {
            if (primitiveTypeInfo == null)
            {
                throw new ArgumentNullException(nameof(primitiveTypeInfo));
            }
            
            _underlyingType = primitiveTypeInfo;
            Size = size;
        }

        public ArrayTypeInfo(RosTypeInfo rosTypeInfo, int? size)
        {
            if (rosTypeInfo == null)
            {
                throw new ArgumentNullException(nameof(rosTypeInfo));
            }
            
            _underlyingType = rosTypeInfo;
            Size = size;
        }
        
        public IRosTypeInfo GetUnderlyingType()
        {
            return _underlyingType;
        }

        protected bool Equals(ArrayTypeInfo other)
        {
            return _size == other._size && Equals(_underlyingType, other._underlyingType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ArrayTypeInfo) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_size.GetHashCode() * 397) ^ (_underlyingType != null ? _underlyingType.GetHashCode() : 0);
            }
        }

        public override string ToString()
        {
            var size = string.Empty;
                
            if (Size.HasValue)
            {
                size = Size.Value.ToString();
            }
                
            return $"{_underlyingType}[{size}]";
        }

        public static ArrayTypeInfo Create(object type, int? size = null)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            
            if (type is RosTypeInfo complexDescriptor)
            {
                return new ArrayTypeInfo(complexDescriptor, size);
            }

            if (type is PrimitiveTypeInfo primitiveDescriptor)
            {
                return new ArrayTypeInfo(primitiveDescriptor, size);
            }
            
            throw new ArgumentException($"Type {type.GetType()} is not supported.", nameof(type));
        }
        
        
    }
}