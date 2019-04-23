namespace Joanneum.Robotics.Ros.MessageParser
{
    public interface IRosArrayTypeInfo : IRosTypeInfo
    {
        bool IsFixedSize { get; }
        int? Size { get; }
        IRosTypeInfo GetUnderlyingType();
    }
}