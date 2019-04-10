using System;
using System.Linq;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public class RosMessageType
    {
        public string TypeName { get; }
        public string PackageName { get; }
        
        public bool HasPackage
        {
            get { return PackageName != null; }
        }

        public RosMessageType(string typeName, string packageName = null)
        {
            if (typeName == null) throw new ArgumentNullException(nameof(typeName));
            
            if (typeName == string.Empty) throw  new ArgumentException("Empty string is not allowed", nameof(typeName));
            if (packageName != null && packageName == string.Empty) throw  new ArgumentException("Empty string is not allowed", nameof(packageName));
            
            TypeName = typeName;
            PackageName = packageName;
        }
        
        
        protected bool Equals(RosMessageType other)
        {
            return string.Equals(TypeName, other.TypeName) && string.Equals(PackageName, other.PackageName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RosMessageType) obj);
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

        public static RosMessageType Parse(string messageType)
        {
            if (messageType == null) throw new ArgumentNullException(nameof(messageType));

            if (RosMessagePrimitiveType.IsPrimitiveType(messageType))
            {
                throw new InvalidOperationException("Message type is a primitive ros type");
            }

            // Header is a "special" built in type
            if (messageType == "Header")
            {
                return new RosMessageType("std_msgs", "Header");
            }

            var parts = messageType.Split('/')
                .Reverse()
                .ToArray();
            
            return new RosMessageType(parts[0], parts[1]);
        }
    }
}