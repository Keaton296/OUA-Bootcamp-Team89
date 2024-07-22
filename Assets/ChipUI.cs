using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ChipUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Image chipImg;
    private RectTransform rTransform;
    private Vector2 pointerOffset;
    [SerializeField] private TMP_Text chipText;
    [SerializeField] private Image icon;
    private Chip chipData;
    public Chip ChipData
    {
        get { return chipData; }
        set {
            chipData = value;
            UpdateUI();           
        }

    }
    private void Awake()
    {
        chipImg = GetComponent<Image>();
        rTransform = GetComponent<RectTransform>();
    }
    void Start()
    {
        ChipData = new Chip(13,ChipColor.Kirmizi);
    }
    void UpdateUI()
    {
        chipText.text = chipData.sayi.ToString();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        
        //rTransform.SetParent(rTransform.parent.parent.parent,true);
        //rTransform.anchorMax = Vector2.zero;
        //rTransform.anchorMin = Vector2.zero;
        pointerOffset = -eventData.pressPosition + rTransform.anchoredPosition;
        //Debug.Log(eventData.pressPosition + " " + rTransform.anchoredPosition);
    }

    public void OnDrag(PointerEventData eventData)
    {
        chipImg.raycastTarget = false;
        rTransform.anchoredPosition = eventData.position + pointerOffset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        chipImg.raycastTarget = true;
    }
}
