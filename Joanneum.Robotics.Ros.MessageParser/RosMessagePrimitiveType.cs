using System;
using System.Collections.Generic;
using System.Linq;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public class RosMessagePrimitiveType
    {
        public static readonly RosMessagePrimitiveType Int8 = new RosMessagePrimitiveType("int8", typeof(sbyte));
        public static readonly RosMessagePrimitiveType Int16 = new RosMessagePrimitiveType("int16", typeof(short));
        public static readonly RosMessagePrimitiveType Int32 = new RosMessagePrimitiveType("int32", typeof(int));
        public static readonly RosMessagePrimitiveType Int64 = new RosMessagePrimitiveType("int64", typeof(long));
        public static readonly RosMessagePrimitiveType UInt8 = new RosMessagePrimitiveType("uint8", typeof(byte));
        public static readonly RosMessagePrimitiveType UInt16 = new RosMessagePrimitiveType("uint16", typeof(ushort));
        public static readonly RosMessagePrimitiveType UInt32 = new RosMessagePrimitiveType("uint32", typeof(uint));
        public static readonly RosMessagePrimitiveType UInt64 = new RosMessagePrimitiveType("uint64", typeof(ulong));
        public static readonly RosMessagePrimitiveType Float32 = new RosMessagePrimitiveType("float32", typeof(float));
        public static readonly RosMessagePrimitiveType Float64 = new RosMessagePrimitiveType("float64", typeof(double));
        public static readonly RosMessagePrimitiveType String = new RosMessagePrimitiveType("string", typeof(string));
        public static readonly RosMessagePrimitiveType Time = new RosMessagePrimitiveType("time", typeof(DateTime));
        public static readonly RosMessagePrimitiveType Duration = new RosMessagePrimitiveType("duration", typeof(TimeSpan));
        public static readonly RosMessagePrimitiveType Bool = new RosMessagePrimitiveType("bool", typeof(bool));

        public static readonly RosMessagePrimitiveType Char = new RosMessagePrimitiveType("char", typeof(byte));
        public static readonly RosMessagePrimitiveType Byte = new RosMessagePrimitiveType("byte", typeof(sbyte));

        public static readonly ICollection<RosMessagePrimitiveType> PrimitiveTypes = new List<RosMessagePrimitiveType>()
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

        public static RosMessagePrimitiveType Parse(string rosPrimitiveType)
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

        private RosMessagePrimitiveType(string rosType, Type clrType)
        {
            RosType = rosType;
            Type = clrType;
        }

        public override string ToString()
        {
            return RosType;
        }

        protected bool Equals(RosMessagePrimitiveType other)
        {
            return Equals(Type, other.Type) && string.Equals(RosType, other.RosType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RosMessagePrimitiveType) obj);
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