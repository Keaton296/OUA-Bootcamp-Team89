using System;
using Unity.Collections;
using Unity.Netcode;
public struct PlayerSeatData : INetworkSerializable, IEquatable<PlayerSeatData>
{
    public bool isAvailable;
    public FixedString32Bytes PlayerName;
    //resim
    public int Money;
    public PlayerSeatData(string isim,int para, bool isAvailabel)
    {
        isAvailable = isAvailabel;
        PlayerName = isim;
        Money = para;
    }

    public bool Equals(PlayerSeatData other)
    {
        if (other.PlayerName == PlayerName && other.Money == Money) return true;
        else return false;
    }

    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {
        serializer.SerializeValue(ref isAvailable);
        serializer.SerializeValue(ref PlayerName);
        serializer.SerializeValue(ref Money);
    }
}
