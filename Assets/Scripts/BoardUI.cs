using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class BoardUI : MonoBehaviour
{
    public static BoardUI Singleton;
    [SerializeField] GameObject chipPrefab;
    [SerializeField] ChipUI[] boardChips;
    private void Awake()
    {
        Singleton = this;
    }
    public void UpdateUI()
    {
        List<NetworkObject> ownedObjects = NetworkManager.Singleton.SpawnManager.GetClientOwnedObjects(NetworkManager.Singleton.LocalClientId);
        foreach (var item in ownedObjects)
        {
            if (item.gameObject.tag == "Player")
            {
                Player ownedPlayer = item.GetComponent<Player>();
                for (int i = 0; i < ownedPlayer.chips.Count; i++)
                {
                    boardChips[i].UpdateUI(ownedPlayer.chips[i]);
                }
            }
        }
    }
    
}
