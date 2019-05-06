using System;

namespace Joanneum.Robotics.Ros.MessageParser
{
    /// <summary>
    /// Marker Interface for ROS Types (Primitive or Complex)
    /// </summary>
    public interface IRosTypeInfo
    {
        bool IsArray { get; }
        bool IsPrimitive { get; }
    }
}