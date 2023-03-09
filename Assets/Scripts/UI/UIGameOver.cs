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
        EventHandler.CallGameMusicPlay(AudioClip.Click, AudioPlayType.Play);
        EventHandler.CallGameBackEvent();
        this.gameObject.SetActive(false);
        UIManager.Instance.HideUI(UIType.UIGameStart);
        UIManager.Instance.ShowUI(UIType.UIGameLobby);
    }
}