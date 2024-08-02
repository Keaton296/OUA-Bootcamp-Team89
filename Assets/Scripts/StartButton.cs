using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    Button button;
    [SerializeField] NetworkManager networkManager;
    [SerializeField] GameObject popupWindowScreenObject;
    [SerializeField] GameObject turnManager;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnStartClickHandler);
    }
    private void OnStartClickHandler()
    {
        networkManager.StartHost();
    }
}
