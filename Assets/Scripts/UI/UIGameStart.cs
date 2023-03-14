using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGameStart : MonoBehaviour
{
    [SerializeField] private Button m_BtnGameBack;
    [SerializeField] private Button m_BtnGameSetting;
    [SerializeField] private Button m_BtnGameRePlay;

    private string m_SceneName;

    private void Awake()
    {
        m_BtnGameBack.onClick.AddListener(OnClickGameBack);
        m_BtnGameSetting.onClick.AddListener(OnClickGameSetting);
        m_BtnGameRePlay.onClick.AddListener(OnClickGameRePlay);
    }

    private void OnClickGameBack()
    {
        EventHandler.CallGameMusicPlayEvent(AudioClip.Click, AudioPlayType.Play);
        EventHandler.CallGameBackEvent();
        UIManager.Instance.HideUI(UIType.UIGameStart);
        UIManager.Instance.ShowUI(UIType.UIGameLobby);
    }

    private void OnClickGameSetting()
    {
        EventHandler.CallGameUISettingEvent(false);
        EventHandler.CallGameMusicPlayEvent(AudioClip.Click, AudioPlayType.Play);
        UIManager.Instance.HideUI(UIType.UIGameStart);
        UIManager.Instance.ShowUI(UIType.UIGameSetting);
    }

    private void OnClickGameRePlay()
    {
        EventHandler.CallGameMusicPlayEvent(AudioClip.Click, AudioPlayType.Play);
        UIManager.Instance.HideUI(UIType.UIGameStart);
        EventHandler.CallGameReplayEvent(SceneManager.GetActiveScene().name);
    }
}