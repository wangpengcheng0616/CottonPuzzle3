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

    /*
     * TODO: Test
     * 通过逻辑
     */
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            EventHandler.CallGamePassEvent(GetSceneName());
        }
    }

    private string GetSceneName()
    {
        m_SceneName = SceneManager.GetActiveScene().name;
        return m_SceneName;
    }

    private void OnClickGameBack()
    {
        EventHandler.CallGameBackEvent();
        this.gameObject.SetActive(false);
        UIManager.Instance.m_UIGameLobby.gameObject.SetActive(true);
    }

    private void OnClickGameSetting()
    {
        this.gameObject.SetActive(false);
        UIManager.Instance.m_UIGameSetting.gameObject.SetActive(true);
    }

    private void OnClickGameRePlay()
    {
        EventHandler.CallGameReplayEvent(GetSceneName());
    }
}