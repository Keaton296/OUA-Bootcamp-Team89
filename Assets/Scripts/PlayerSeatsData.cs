using Unity.Netcode;

public class PlayerSeatsData : INetworkSerializable
{
    PlayerSeatData player0;
    PlayerSeatData player1;
    PlayerSeatData player2;
    PlayerSeatData player3;
    public PlayerSeatsData()
    {

    }
    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {
        serializer.SerializeValue(ref player0);
        serializer.SerializeValue(ref player1);
        serializer.SerializeValue(ref player2);
        serializer.SerializeValue(ref player3);
    }
}
