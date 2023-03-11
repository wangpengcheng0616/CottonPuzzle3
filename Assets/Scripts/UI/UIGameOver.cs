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
        EventHandler.CallGameMusicPlayEvent(AudioClip.Click, AudioPlayType.Play);
        EventHandler.CallGameBackEvent();
        UIManager.Instance.HideUI(UIType.UIGameOver);
        UIManager.Instance.HideUI(UIType.UIGameStart);
        UIManager.Instance.ShowUI(UIType.UIGameLobby);
    }
}