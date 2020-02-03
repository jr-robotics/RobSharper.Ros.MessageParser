using System;
using System.Collections.Generic;
using System.Linq;

namespace RobSharper.Ros.MessageParser
{
    public class BuiltInTypeMapping
    {
        public static readonly BuiltInTypeMapping Int8 = new BuiltInTypeMapping("int8", typeof(sbyte));
        public static readonly BuiltInTypeMapping Int16 = new BuiltInTypeMapping("int16", typeof(short));
        public static readonly BuiltInTypeMapping Int32 = new BuiltInTypeMapping("int32", typeof(int));
        public static readonly BuiltInTypeMapping Int64 = new BuiltInTypeMapping("int64", typeof(long));
        public static readonly BuiltInTypeMapping UInt8 = new BuiltInTypeMapping("uint8", typeof(byte));
        public static readonly BuiltInTypeMapping UInt16 = new BuiltInTypeMapping("uint16", typeof(ushort));
        public static readonly BuiltInTypeMapping UInt32 = new BuiltInTypeMapping("uint32", typeof(uint));
        public static readonly BuiltInTypeMapping UInt64 = new BuiltInTypeMapping("uint64", typeof(ulong));
        public static readonly BuiltInTypeMapping Float32 = new BuiltInTypeMapping("float32", typeof(float));
        public static readonly BuiltInTypeMapping Float64 = new BuiltInTypeMapping("float64", typeof(double));
        public static readonly BuiltInTypeMapping String = new BuiltInTypeMapping("string", typeof(string));
        public static readonly BuiltInTypeMapping Time = new BuiltInTypeMapping("time", typeof(DateTime));
        public static readonly BuiltInTypeMapping Duration = new BuiltInTypeMapping("duration", typeof(TimeSpan));
        public static readonly BuiltInTypeMapping Bool = new BuiltInTypeMapping("bool", typeof(bool));

        public static readonly BuiltInTypeMapping Char = new BuiltInTypeMapping("char", typeof(byte));
        public static readonly BuiltInTypeMapping Byte = new BuiltInTypeMapping("byte", typeof(sbyte));

        public static readonly ICollection<BuiltInTypeMapping> PrimitiveTypes = new List<BuiltInTypeMapping>()
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

        public static BuiltInTypeMapping Create(string rosPrimitiveType)
        {
            if (rosPrimitiveType == null) throw new ArgumentNullException(nameof(rosPrimitiveType));
            
            var t = PrimitiveTypes.FirstOrDefault(x => x.RosType.Equals(rosPrimitiveType));

            if (t == null)
            {
                throw new NotSupportedException($"ROS message primitive type ${rosPrimitiveType} is not supported.");
            }

            return t;
        }

        public static BuiltInTypeMapping Create(RosTypeInfo primitiveRosType)
        {
            if (primitiveRosType == null) throw new ArgumentNullException(nameof(primitiveRosType));
            
            if (!primitiveRosType.IsBuiltInType)
                throw new InvalidOperationException($"ROS type {primitiveRosType} is no primitive type.");
            
            return Create(primitiveRosType.TypeName);
        }

        public static bool IsBuiltInType(string builtInType)
        {
            if (builtInType == null) throw new ArgumentNullException(nameof(builtInType));

            return PrimitiveTypes.Any(t => t.RosType.Equals(builtInType));
        }
        
        public Type Type { get;  }
        
        public string RosType { get; }

        private BuiltInTypeMapping(string rosType, Type clrType)
        {
            RosType = rosType;
            Type = clrType;
        }

        public override string ToString()
        {
            return RosType;
        }

        protected bool Equals(BuiltInTypeMapping other)
        {
            return Equals(Type, other.Type) && string.Equals(RosType, other.RosType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BuiltInTypeMapping) obj);
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