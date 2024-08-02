using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ChipUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    protected Image chipImg;
    protected RectTransform rTransform;
    protected Vector2 pointerOffset;
    [SerializeField] protected Image chipTextImage;
    //[SerializeField] protected Image icon;
    protected int chipIndex;
    public virtual void Awake()
    {
        chipImg = GetComponent<Image>();
        rTransform = GetComponent<RectTransform>();
    }
    public void UpdateUI(Chip chipData)
    {
        if (chipData.num == 0)
        {
            chipImg.CrossFadeAlpha(0, 0, true);
            chipImg.raycastTarget = false;
            chipTextImage.CrossFadeAlpha(0, 0, true);
        }
        else
        {
            chipTextImage.sprite = GameData.Singleton.chipTextSprites[chipData.num - 1];
            chipTextImage.color = GameData.Singleton.chipColors[(int)chipData.chipColor];
            chipImg.CrossFadeAlpha(1, 0, true);
            chipImg.raycastTarget = true;
            chipTextImage.CrossFadeAlpha(1, 0, true);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        pointerOffset = -eventData.pressPosition + rTransform.anchoredPosition;
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
