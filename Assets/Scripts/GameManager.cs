using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        
    }
    private void Start()
    {
        
    }
    public void StartGame()
    {
        if (NetworkManager.Singleton.IsHost)
        {
            
        }
    }
}
