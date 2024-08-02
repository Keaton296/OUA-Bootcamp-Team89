using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Singleton;
    public Color[] chipColors;
    public Sprite[] chipTextSprites;
    private void Awake()
    {
        Singleton = this;
    }
}
