using System;
using System.Text;

namespace RobSharper.Ros.MessageParser
{
    public class RosTypeInfo
    {
        private RosTypeInfo(string packageName, string typeName, bool isBuiltInType, bool isArray, int arraySize)
        {
            PackageName = packageName;
            TypeName = typeName ?? throw new ArgumentNullException(nameof(typeName));
            IsBuiltInType = isBuiltInType;
            IsArray = isArray;
            ArraySize = arraySize;
            
            if (TypeName == string.Empty) throw  new ArgumentException("Empty string is not allowed", nameof(typeName));
        }

        public string PackageName { get; }
        public string TypeName { get; }
        
        public bool HasPackage => PackageName != null;
        
        public bool IsBuiltInType { get; }
        public bool IsArray { get;  }
        public int ArraySize { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (HasPackage)
            {
                sb.Append(PackageName);
                sb.Append("/");
            }

            sb.Append(TypeName);

            if (IsArray)
            {
                sb.Append('[');

                if (ArraySize > 0)
                {
                    sb.Append(ArraySize);
                }
                
                sb.Append(']');
            }
            
            return sb.ToString();
        }

        protected bool Equals(RosTypeInfo other)
        {
            return PackageName == other.PackageName && TypeName == other.TypeName && IsBuiltInType == other.IsBuiltInType && IsArray == other.IsArray && ArraySize == other.ArraySize;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RosTypeInfo) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (PackageName != null ? PackageName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TypeName != null ? TypeName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ IsBuiltInType.GetHashCode();
                hashCode = (hashCode * 397) ^ IsArray.GetHashCode();
                hashCode = (hashCode * 397) ^ ArraySize;
                return hashCode;
            }
        }

        public static RosTypeInfo CreateBuiltIn(string rosType)
        {
            if (rosType == null) throw new ArgumentNullException(nameof(rosType));
            
            return new RosTypeInfo(null, rosType, true, false, 0);
        }

        public static RosTypeInfo CreateRosType(string typeName)
        {
            return CreateRosType(null, typeName);
        }

        public static RosTypeInfo CreateRosType(string packageName, string typeName)
        {
            if (typeName == null) throw new ArgumentNullException(nameof(typeName));
            return new RosTypeInfo(packageName, typeName, false, false, 0);
        }

        public static RosTypeInfo CreateVariableArray(RosTypeInfo type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return new RosTypeInfo(type.PackageName, type.TypeName, type.IsBuiltInType, true, 0);
        }

        public static RosTypeInfo CreateFixedSizeArray(RosTypeInfo type, int size)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size));

            return new RosTypeInfo(type.PackageName, type.TypeName, type.IsBuiltInType, true, size);
        }
    }
}