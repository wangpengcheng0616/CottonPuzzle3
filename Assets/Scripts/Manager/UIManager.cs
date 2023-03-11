using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIManager : MonoSigleton<UIManager>
{
    public UIGameLobby m_UIGameLobby;
    public UIGameStart m_UIGameStart;
    public UIGameSetting m_UIGameSetting;
    public UIGameOver m_UIGameOver;
    public UILoading m_UILoadding;

    public Dictionary<UIType, GameObject> m_UIDictionary;

    public UIManager()
    {
        m_UIDictionary = new Dictionary<UIType, GameObject>();
    }

    protected override void Awake()
    {
        base.Awake();
        m_UIDictionary.Add(UIType.UIGameLobby, m_UIGameLobby.gameObject);
        m_UIDictionary.Add(UIType.UIGameStart, m_UIGameStart.gameObject);
        m_UIDictionary.Add(UIType.UIGameSetting, m_UIGameSetting.gameObject);
        m_UIDictionary.Add(UIType.UIGameOver, m_UIGameOver.gameObject);
        m_UIDictionary.Add(UIType.UILoading, m_UILoadding.gameObject);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        m_UIDictionary.Clear();
    }

    public void ShowUI(UIType uiType, float duration = 2f)
    {
        if (m_UIDictionary.ContainsKey(uiType))
        {
            m_UIDictionary[uiType].SetActive(true);
            UIFadeIn(uiType, duration);
        }
    }

    public void HideUI(UIType uiType, float duration = 2f)
    {
        if (m_UIDictionary.ContainsKey(uiType))
        {
            UIFadeOut(uiType, duration);
            m_UIDictionary[uiType].SetActive(false);
        }
    }

    public void UIFadeIn(UIType uiType, float duration)
    {
        m_UIDictionary[uiType].GetComponent<CanvasGroup>().alpha = 0;
        m_UIDictionary[uiType].GetComponent<CanvasGroup>().DOFade(1, duration);
    }

    public void UIFadeOut(UIType uiType, float duration)
    {
        m_UIDictionary[uiType].GetComponent<CanvasGroup>().DOFade(0, duration);
        m_UIDictionary[uiType].GetComponent<CanvasGroup>().alpha = 1;
    }

    public GameObject GetUI(UIType uiType)
    {
        return m_UIDictionary.ContainsKey(uiType) ? m_UIDictionary[uiType] : null;
    }
}

public enum UIType
{
    UIGameLobby,
    UIGameStart,
    UIGameSetting,
    UIGameOver,
    UILoading,
}