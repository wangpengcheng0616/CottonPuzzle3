using UnityEngine;
using UnityEngine.UI;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private Button m_BtnGameBack;

    private void Awake()
    {
        m_BtnGameBack.onClick.AddListener(OnClickGameBack);
    }

    private void OnClickGameBack()
    {
        EventHandler.CallGameBackEvent();
        this.gameObject.SetActive(false);
        UIManager.Instance.m_UIGameStart.gameObject.SetActive(false);
        UIManager.Instance.m_UIGameLobby.gameObject.SetActive(true);
    }
}