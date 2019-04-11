using System;
using System.Collections.Generic;
using System.Linq;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public class PrimitiveTypeDescriptor
    {
        public static readonly PrimitiveTypeDescriptor Int8 = new PrimitiveTypeDescriptor("int8", typeof(sbyte));
        public static readonly PrimitiveTypeDescriptor Int16 = new PrimitiveTypeDescriptor("int16", typeof(short));
        public static readonly PrimitiveTypeDescriptor Int32 = new PrimitiveTypeDescriptor("int32", typeof(int));
        public static readonly PrimitiveTypeDescriptor Int64 = new PrimitiveTypeDescriptor("int64", typeof(long));
        public static readonly PrimitiveTypeDescriptor UInt8 = new PrimitiveTypeDescriptor("uint8", typeof(byte));
        public static readonly PrimitiveTypeDescriptor UInt16 = new PrimitiveTypeDescriptor("uint16", typeof(ushort));
        public static readonly PrimitiveTypeDescriptor UInt32 = new PrimitiveTypeDescriptor("uint32", typeof(uint));
        public static readonly PrimitiveTypeDescriptor UInt64 = new PrimitiveTypeDescriptor("uint64", typeof(ulong));
        public static readonly PrimitiveTypeDescriptor Float32 = new PrimitiveTypeDescriptor("float32", typeof(float));
        public static readonly PrimitiveTypeDescriptor Float64 = new PrimitiveTypeDescriptor("float64", typeof(double));
        public static readonly PrimitiveTypeDescriptor String = new PrimitiveTypeDescriptor("string", typeof(string));
        public static readonly PrimitiveTypeDescriptor Time = new PrimitiveTypeDescriptor("time", typeof(DateTime));
        public static readonly PrimitiveTypeDescriptor Duration = new PrimitiveTypeDescriptor("duration", typeof(TimeSpan));
        public static readonly PrimitiveTypeDescriptor Bool = new PrimitiveTypeDescriptor("bool", typeof(bool));

        public static readonly PrimitiveTypeDescriptor Char = new PrimitiveTypeDescriptor("char", typeof(byte));
        public static readonly PrimitiveTypeDescriptor Byte = new PrimitiveTypeDescriptor("byte", typeof(sbyte));

        public static readonly ICollection<PrimitiveTypeDescriptor> PrimitiveTypes = new List<PrimitiveTypeDescriptor>()
        {
            Int8,
            Int16,
            Int32,
            Int64,
            UInt8,
            UInt16,
            UInt32,
            UInt64,
            Float32,
            Float64,
            String,
            Time,
            Duration,
            Bool,
            Char,
            Byte
        };

        public static PrimitiveTypeDescriptor Parse(string rosPrimitiveType)
        {
            var t = PrimitiveTypes.FirstOrDefault(x => x.RosType.Equals(rosPrimitiveType));

            if (t == null)
            {
                throw new NotSupportedException($"ROS message primitive type ${rosPrimitiveType} is not supported.");
            }

            return t;
        }

        public static bool IsPrimitiveType(string rosPrimitiveType)
        {
            if (rosPrimitiveType == null) throw new ArgumentNullException(nameof(rosPrimitiveType));

            return PrimitiveTypes.Any(t => t.RosType.Equals(rosPrimitiveType));
        }
        
        
        
        public Type Type { get;  }
        public string RosType { get; }

        private PrimitiveTypeDescriptor(string rosType, Type clrType)
        {
            RosType = rosType;
            Type = clrType;
        }

        public override string ToString()
        {
            return RosType;
        }

        protected bool Equals(PrimitiveTypeDescriptor other)
        {
            return Equals(Type, other.Type) && string.Equals(RosType, other.RosType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PrimitiveTypeDescriptor) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Type != null ? Type.GetHashCode() : 0) * 397) ^ (RosType != null ? RosType.GetHashCode() : 0);
            }
        }
    }
}