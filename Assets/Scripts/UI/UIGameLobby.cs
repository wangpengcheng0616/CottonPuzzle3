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
        EventHandler.CallGameMusicPlayEvent(AudioClip.Click,AudioPlayType.Play);
        EventHandler.CallGameStartEvent();
        UIManager.Instance.HideUI(UIType.UIGameLobby);
        UIManager.Instance.ShowUI(UIType.UIGameStart);
    }
}