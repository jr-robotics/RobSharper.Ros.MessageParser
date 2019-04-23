using System;

namespace Joanneum.Robotics.Ros.MessageParser
{
    public class FieldDescriptor
    {
        public IRosTypeInfo TypeInfo { get; }

        public string Identifier { get; }

        public FieldDescriptor(IRosTypeInfo typeInfo, string identifier)
        {
            if (typeInfo == null) throw new ArgumentNullException(nameof(typeInfo));
            if (identifier == null) throw new ArgumentNullException(nameof(identifier));

            TypeInfo = typeInfo;
            Identifier = identifier;
        }

        public override string ToString()
        {
            return $"{TypeInfo} {Identifier}";
        }

        protected bool Equals(FieldDescriptor other)
        {
            return Equals(TypeInfo, other.TypeInfo) && string.Equals(Identifier, other.Identifier);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((FieldDescriptor) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((TypeInfo != null ? TypeInfo.GetHashCode() : 0) * 397) ^ (Identifier != null ? Identifier.GetHashCode() : 0);
            }
        }
    }
}