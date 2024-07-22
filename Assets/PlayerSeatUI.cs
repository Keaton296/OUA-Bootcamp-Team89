using System.Text;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSeatUI : MonoBehaviour
{
    private void Start()
    {
        //NetworkManager.Singleton.On
    }
    private PlayerSeatData oyuncuRef;
    public PlayerSeatData OyuncuRef
    {
        get
        {
            return oyuncuRef;
        }
        set
        {
            oyuncuRef = value;
            if (!oyuncuRef.isAvailable)
            {
                image_self.color = stateColors[0];
                isimText.text = oyuncuRef.PlayerName.ToString();
                paraText.text = "$" + oyuncuRef.Money;
                oyuncuResimObjesi.SetActive(true);
                isimText.gameObject.SetActive(true);
                paraText.gameObject.SetActive(true);
            }
            else
            {
                oyuncuResimObjesi.SetActive(false);
                isimText.gameObject.SetActive(false);
                paraText.gameObject.SetActive(false);
                image_self.color = stateColors[1];
            }
        }
    }
    
    [SerializeField] private Color[] stateColors;
    [SerializeField] private GameObject oyuncuResimObjesi;
    [SerializeField] private Image image_self;
    [SerializeField] private Image resimImage;
    [SerializeField] private TMP_Text isimText;
    [SerializeField] private TMP_Text paraText;
}
