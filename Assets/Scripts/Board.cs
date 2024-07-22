using System;
using Unity.Netcode;
public class Board : INetworkSerializable, IEquatable<Board>
{
    Chip[] chipRow0;
    Chip[] chipRow1;

    public bool Equals(Board other)
    {
        if (chipRow0 == other.chipRow0 && chipRow1 == other.chipRow1) return true;
        else return false;
    }
    public Board(Chip[] temp0, Chip[] temp1)
    {
        chipRow0 = temp0;
        chipRow1 = temp1;   
    }
    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {
        serializer.SerializeValue(ref chipRow0);
        serializer.SerializeValue(ref chipRow1);
    }
}
