using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkTurnManager : NetworkBehaviour
{
    public static NetworkTurnManager Singleton;
    public Player[] players;
    public bool SeatAvailable
    {
        get
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i] == null) return true;
            }
            return false;
        }
    }
    NetworkVariable<int> turnIndex;
    NetworkVariable<int> gameCost;
    NetworkVariable<float> moveTime;
    NetworkVariable<bool> isPlaying;
    NetworkVariable<bool> hasTakenChip;
    private void Awake()
    {
        players = new Player[4];
        turnIndex = new NetworkVariable<int>(0, readPerm: NetworkVariableReadPermission.Everyone, writePerm: NetworkVariableWritePermission.Server);
        gameCost = new NetworkVariable<int>(0, readPerm: NetworkVariableReadPermission.Everyone, writePerm: NetworkVariableWritePermission.Server);
        moveTime = new NetworkVariable<float>(30, readPerm: NetworkVariableReadPermission.Everyone, writePerm: NetworkVariableWritePermission.Server);
        isPlaying = new NetworkVariable<bool>(false, readPerm: NetworkVariableReadPermission.Everyone, writePerm: NetworkVariableWritePermission.Server);
        hasTakenChip = new NetworkVariable<bool>(false, readPerm: NetworkVariableReadPermission.Everyone, writePerm: NetworkVariableWritePermission.Server);
    }
    public override void OnNetworkSpawn()
    {
        Debug.Log("NetworkSpawn on TurnManager");
        base.OnNetworkSpawn();
        Singleton = this;
        if (IsServer)
        {
            
            // adding the first player etc.
        }
    }
    public void DiscardChipServerOnly(Player playerMoved, int indexOfChip)
    {
        if (hasTakenChip.Value && playerMoved.chips[indexOfChip].num != 0)
        {
            playerMoved.chips.RemoveAt(indexOfChip);
            if (indexOfChip != 0)
            {
                playerMoved.chips.Insert(indexOfChip - 1, new Chip());
            }
            else
            {
                playerMoved.chips.Insert(indexOfChip, new Chip());
            }
        }
        playerMoved.UpdateBoardChipsClientRpc();
    }
    public void PullChip()
    {

    }
    public void MakeSeatForPlayer(Player player)
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] == null)
            {
                players[i] = player;
            }
        }
    }
}
