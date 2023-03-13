using UnityEngine;
using UnityEngine.UI;

public class UIGameLobby : MonoBehaviour
{
    [SerializeField] private Button m_BtnGameStart;
    [SerializeField] private Button m_BtnGameContinue;
    [SerializeField] private Button m_BtnGameAchievement;
    [SerializeField] private Button m_BtnGameAbout;

    private void Awake()
    {
        m_BtnGameStart.onClick.AddListener(OnClickGameStart);
        m_BtnGameContinue.onClick.AddListener(OnClickGameContinue);
        m_BtnGameAchievement.onClick.AddListener(OnClickGameAchievement);
        m_BtnGameAbout.onClick.AddListener(OnClickGameAbout);
    }

    private void OnEnable()
    {
        if (DataManager.GetStringData("CurrentMap") != string.Empty)
        {
            m_BtnGameContinue.interactable = true;
        }
        else
        {
            m_BtnGameContinue.interactable = false;
        }
    }

    private void OnClickGameStart()
    {
        EventHandler.CallGameMusicPlayEvent(AudioClip.Click, AudioPlayType.Play);
        EventHandler.CallGameStartEvent();
        UIManager.Instance.HideUI(UIType.UIGameLobby);
        // UIManager.Instance.ShowUI(UIType.UIGameStart);
    }

    private void OnClickGameContinue()
    {
        EventHandler.CallGameMusicPlayEvent(AudioClip.Click, AudioPlayType.Play);
        EventHandler.CallGameContinueEvent(DataManager.GetStringData("CurrentMap"));
        UIManager.Instance.HideUI(UIType.UIGameLobby);
    }

    private void OnClickGameAchievement()
    {
    }

    private void OnClickGameAbout()
    {
    }
}