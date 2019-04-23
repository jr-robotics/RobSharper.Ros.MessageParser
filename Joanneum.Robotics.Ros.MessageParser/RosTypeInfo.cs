using System;
using System.Linq;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public class RosTypeInfo : IRosTypeInfo
    {
        public string TypeName { get; }
        public string PackageName { get; }
        
        public bool HasPackage
        {
            get { return PackageName != null; }
        }

        public bool IsArray => false;
        public bool IsPrimitive => false;

        public RosTypeInfo(string typeName, string packageName = null)
        {
            if (typeName == null) throw new ArgumentNullException(nameof(typeName));
            
            if (typeName == string.Empty) throw  new ArgumentException("Empty string is not allowed", nameof(typeName));
            if (packageName != null && packageName == string.Empty) throw  new ArgumentException("Empty string is not allowed", nameof(packageName));
            
            TypeName = typeName;
            PackageName = packageName;
        }
        
        protected bool Equals(RosTypeInfo other)
        {
            return string.Equals(TypeName, other.TypeName) && string.Equals(PackageName, other.PackageName);
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
                return ((TypeName != null ? TypeName.GetHashCode() : 0) * 397) ^ (PackageName != null ? PackageName.GetHashCode() : 0);
            }
        }

        public override string ToString()
        {
            if (HasPackage)
            {
                return PackageName + "/" + TypeName;
            }
            else
            {
                return TypeName;
            }
        }

        public static RosTypeInfo Parse(string messageType)
        {
            if (messageType == null) throw new ArgumentNullException(nameof(messageType));

            if (PrimitiveTypeInfo.IsPrimitiveType(messageType))
            {
                throw new InvalidOperationException("Message type is a primitive ros type");
            }

            // Header is a "special" built in type
            if (messageType == "Header")
            {
                return new RosTypeInfo("std_msgs", "Header");
            }

            var parts = messageType.Split('/')
                .Reverse()
                .ToArray();
            
            return new RosTypeInfo(parts[0], parts[1]);
        }
    }
}