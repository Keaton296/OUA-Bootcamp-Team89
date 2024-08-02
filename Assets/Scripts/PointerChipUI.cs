using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PointerChipUI : ChipUI
{
    public static PointerChipUI Singleton;
    public override void Awake()
    {
        base.Awake();
        Singleton = this;
    }
    public void UpdatePosition(Vector2 newPosition)
    {
        rTransform.anchoredPosition = newPosition;
    }
}
