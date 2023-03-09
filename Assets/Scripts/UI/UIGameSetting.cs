using UnityEngine;
using UnityEngine.UI;

public class UIGameSetting : MonoBehaviour
{
    [SerializeField] private Button m_BtnSettingExit;
    [SerializeField] private Button m_BtnMusic;
    [SerializeReference] private GameObject m_BtnMusicOff;
    [SerializeField] private Button m_BtnVol;
    [SerializeReference] private GameObject m_BtnVolOff;

    private void Awake()
    {
        m_BtnSettingExit.onClick.AddListener(OnClickSettingExit);
        m_BtnMusic.onClick.AddListener(OnClickMusic);
    }

    private void OnClickSettingExit()
    {
        this.gameObject.SetActive(false);
        UIManager.Instance.m_UIGameStart.gameObject.SetActive(true);
    }

    private void OnClickMusic()
    {
        var value = m_BtnMusicOff.activeSelf;

        var audioPlayType = value ? AudioPlayType.MuteOff : AudioPlayType.MuteOn;

        m_BtnMusicOff.SetActive(!value);
        EventHandler.CallGameMusicPlay(audioPlayType);
    }
}