using Unity.Netcode;
using System;

public struct Chip : INetworkSerializable,IEquatable<Chip>
{
    public short num;
    public ChipColor chipColor;
    public Chip(short number, ChipColor cColor)
    {
        num = number;
        chipColor = cColor;
    }
    public bool Equals(Chip other)
    {
        if(num == other.num && chipColor == other.chipColor) return true;
        else return false;
    }

    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {
        serializer.SerializeValue(ref num);
        serializer.SerializeValue(ref chipColor);
    }
}
public enum ChipColor
{
    Red,
    Black,
    Blue,
    Yellow
}