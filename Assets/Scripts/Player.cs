using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Player : NetworkBehaviour
{
    public NetworkList<Chip> chips;
    private void Awake()
    {
        chips = new NetworkList<Chip>(new Chip[12], readPerm: NetworkVariableReadPermission.Owner, writePerm: NetworkVariableWritePermission.Server);
    }
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        chips.RemoveAt(0);
        chips.Insert(0, new Chip(11, ChipColor.Red));
        if(NetworkManager.Singleton.IsServer) NetworkTurnManager.Singleton.MakeSeatForPlayer(this);
        BoardUI.Singleton.UpdateUI();

    }
    [ServerRpc(RequireOwnership = true)]
    public void DiscardChipServerRpc(int indexOfChip)
    {
        NetworkTurnManager.Singleton.DiscardChipServerOnly(this, indexOfChip);
    }
    [ClientRpc]
    public void UpdateBoardChipsClientRpc()
    {
        BoardUI.Singleton.UpdateUI();
    }
}
