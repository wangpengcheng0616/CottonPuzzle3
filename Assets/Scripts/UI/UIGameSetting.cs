using System;
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
        m_BtnVol.onClick.AddListener(OnClickVol);
        EventHandler.GameBackEvent += OnGameBackEvent;
    }

    private void OnDestroy()
    {
        EventHandler.GameBackEvent -= OnGameBackEvent;
    }

    private void OnGameBackEvent()
    {
        m_BtnMusicOff.SetActive(false);
        m_BtnVolOff.SetActive(false);
    }

    private void OnClickSettingExit()
    {
        EventHandler.CallGameMusicPlay(AudioClip.Click, AudioPlayType.Play);
        this.gameObject.SetActive(false);
        UIManager.Instance.ShowUI(UIType.UIGameStart);
    }

    private void OnClickMusic()
    {
        EventHandler.CallGameMusicPlay(AudioClip.Click, AudioPlayType.Play);
        var value = m_BtnMusicOff.activeSelf;
        var audioPlayType = value ? AudioPlayType.MuteOff : AudioPlayType.MuteOn;
        m_BtnMusicOff.SetActive(!value);
        EventHandler.CallGameMusicPlay(AudioClip.GameMusic, audioPlayType);
    }

    private void OnClickVol()
    {
        EventHandler.CallGameMusicPlay(AudioClip.Click, AudioPlayType.Play);
        var value = m_BtnVolOff.activeSelf;
        var audioPlayType = value ? AudioPlayType.MuteOff : AudioPlayType.MuteOn;
        m_BtnVolOff.SetActive(!value);
        EventHandler.CallGameMusicPlay(AudioClip.Click, audioPlayType);
    }
}