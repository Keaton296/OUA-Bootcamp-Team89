using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class RoomStartScreen : MonoBehaviour
{
    [SerializeField] GameObject turnManager;
    void Start()
    {
        NetworkManager.Singleton.ConnectionApprovalCallback += ApprovalCheck;
        NetworkManager.Singleton.OnServerStarted += OnServerStartedHandler;
        NetworkManager.Singleton.StartHost();
    }

    private void ApprovalCheck(NetworkManager.ConnectionApprovalRequest request, NetworkManager.ConnectionApprovalResponse response)
    {
        if (!NetworkTurnManager.Singleton.SeatAvailable) response.Approved = false;
    }
    private void OnServerStartedHandler()
    {
        NetworkObject spawnedTurnManager = Instantiate(turnManager).GetComponent<NetworkObject>();
        spawnedTurnManager.SpawnWithOwnership(NetworkManager.ServerClientId, true);
        //popupWindowScreenObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
