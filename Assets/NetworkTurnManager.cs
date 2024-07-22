using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkTurnManager : NetworkBehaviour
{
    //NetworkList<Player> players;
    NetworkVariable<PlayerSeatsData> players;
    //NetworkList<Board> boards;
    private Board[] boards;
    NetworkVariable<int> turnIndex;
    NetworkVariable<int> gameCost;
    NetworkVariable<float> moveTime;
    NetworkVariable<bool> isPlaying;
    private void Awake()
    {
        players = new NetworkVariable<PlayerSeatsData>(new PlayerSeatsData(), readPerm: NetworkVariableReadPermission.Everyone, writePerm: NetworkVariableWritePermission.Server);
        turnIndex = new NetworkVariable<int>(0, readPerm: NetworkVariableReadPermission.Everyone, writePerm: NetworkVariableWritePermission.Server);
        gameCost = new NetworkVariable<int>(0, readPerm: NetworkVariableReadPermission.Everyone, writePerm: NetworkVariableWritePermission.Server);
        moveTime = new NetworkVariable<float>(30, readPerm: NetworkVariableReadPermission.Everyone, writePerm: NetworkVariableWritePermission.Server);
        isPlaying = new NetworkVariable<bool>(false, readPerm: NetworkVariableReadPermission.Everyone, writePerm: NetworkVariableWritePermission.Server);
    }
    public override void OnNetworkSpawn()
    {
        Debug.Log("NetworkSpawn on TurnManager");
        base.OnNetworkSpawn();
        if (IsServer)
        {
            boards = new Board[4];
            // adding the first player etc.
        }
    }
    [ServerRpc]
    public void DiscardChipServerRpc()
    {

    }
    [ServerRpc]
    public void PullChipServerRpc()
    {

    }
}
