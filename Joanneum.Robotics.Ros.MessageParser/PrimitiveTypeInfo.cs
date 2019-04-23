using System;
using System.Collections.Generic;
using System.Linq;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public class PrimitiveTypeInfo : IRosTypeInfo
    {
        public static readonly PrimitiveTypeInfo Int8 = new PrimitiveTypeInfo("int8", typeof(sbyte));
        public static readonly PrimitiveTypeInfo Int16 = new PrimitiveTypeInfo("int16", typeof(short));
        public static readonly PrimitiveTypeInfo Int32 = new PrimitiveTypeInfo("int32", typeof(int));
        public static readonly PrimitiveTypeInfo Int64 = new PrimitiveTypeInfo("int64", typeof(long));
        public static readonly PrimitiveTypeInfo UInt8 = new PrimitiveTypeInfo("uint8", typeof(byte));
        public static readonly PrimitiveTypeInfo UInt16 = new PrimitiveTypeInfo("uint16", typeof(ushort));
        public static readonly PrimitiveTypeInfo UInt32 = new PrimitiveTypeInfo("uint32", typeof(uint));
        public static readonly PrimitiveTypeInfo UInt64 = new PrimitiveTypeInfo("uint64", typeof(ulong));
        public static readonly PrimitiveTypeInfo Float32 = new PrimitiveTypeInfo("float32", typeof(float));
        public static readonly PrimitiveTypeInfo Float64 = new PrimitiveTypeInfo("float64", typeof(double));
        public static readonly PrimitiveTypeInfo String = new PrimitiveTypeInfo("string", typeof(string));
        public static readonly PrimitiveTypeInfo Time = new PrimitiveTypeInfo("time", typeof(DateTime));
        public static readonly PrimitiveTypeInfo Duration = new PrimitiveTypeInfo("duration", typeof(TimeSpan));
        public static readonly PrimitiveTypeInfo Bool = new PrimitiveTypeInfo("bool", typeof(bool));

        public static readonly PrimitiveTypeInfo Char = new PrimitiveTypeInfo("char", typeof(byte));
        public static readonly PrimitiveTypeInfo Byte = new PrimitiveTypeInfo("byte", typeof(sbyte));

        public static readonly ICollection<PrimitiveTypeInfo> PrimitiveTypes = new List<PrimitiveTypeInfo>()
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

        public static PrimitiveTypeInfo Parse(string rosPrimitiveType)
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

        public bool IsArray => false;
        public bool IsPrimitive => true;

        private PrimitiveTypeInfo(string rosType, Type clrType)
        {
            RosType = rosType;
            Type = clrType;
        }

        public override string ToString()
        {
            return RosType;
        }

        protected bool Equals(PrimitiveTypeInfo other)
        {
            return Equals(Type, other.Type) && string.Equals(RosType, other.RosType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PrimitiveTypeInfo) obj);
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