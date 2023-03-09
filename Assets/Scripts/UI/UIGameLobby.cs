using UnityEngine;
using UnityEngine.UI;

public class UIGameLobby : MonoBehaviour
{
    [SerializeField] private Button m_BtnGameStart;

    private void Awake()
    {
        m_BtnGameStart.onClick.AddListener(OnClickGameStart);
    }

    private void OnClickGameStart()
    {
        EventHandler.CallGameStartEvent();
        this.gameObject.SetActive(false);
        UIManager.Instance.m_UIGameStart.gameObject.SetActive(true);
    }
}