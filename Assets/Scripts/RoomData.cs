using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class RoomData : NetworkBehaviour
{
    
    PlayerSeatData[] Oyuncular;
    
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

    }
}
