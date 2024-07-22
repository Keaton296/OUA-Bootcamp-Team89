using Unity.Netcode;
using System;

public struct Chip : INetworkSerializable,IEquatable<Chip>
{
    public short sayi;
    public ChipColor tasRengi;
    public Chip(short number, ChipColor cColor)
    {
        sayi = number;
        tasRengi = cColor;
    }
    public bool Equals(Chip other)
    {
        if(sayi == other.sayi && tasRengi == other.tasRengi) return true;
        else return false;
    }

    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {
        serializer.SerializeValue(ref sayi);
        serializer.SerializeValue(ref tasRengi);
    }
}
public enum ChipColor
{
    Kirmizi,
    Siyah,
    Mavi,
    Sari
}