using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    private string[] m_MapNameArray = new[] { "Map01", "Map02", "Map03" };
    private List<string> m_MapNameList = new List<string>();
    private string m_MapName;

    private void Awake()
    {
        SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
        EventHandler.GameStartEvent += OnGameStartEvent;
        EventHandler.GameBackEvent += OnGameBackEvent;
        EventHandler.GamePassEvent += OnGamePassEvent;
        EventHandler.GameReplayEvent += OnGameReplayEvent;
    }

    private void OnDestroy()
    {
        EventHandler.GameStartEvent -= OnGameStartEvent;
        EventHandler.GameBackEvent -= OnGameBackEvent;
        EventHandler.GamePassEvent -= OnGamePassEvent;
        EventHandler.GameReplayEvent -= OnGameReplayEvent;
    }

    private void InitMap()
    {
        var mapNum = m_MapNameList.Count;
        if (mapNum == 0)
        {
            UIManager.Instance.m_UIGameOver.gameObject.SetActive(true);
            return;
        }

        // var mapId = Random.Range(0, mapNum);
        var mapId = 0;
        m_MapName = m_MapNameList[mapId];
    }

    private void OnGameStartEvent()
    {
        m_MapNameList.Clear();
        foreach (var mapName in m_MapNameArray)
        {
            m_MapNameList.Add(mapName);
        }

        InitMap();
        StartCoroutine(LoadScene(m_MapName));
        EventHandler.CallGameMusicPlay(AudioClip.GameMusic, AudioPlayType.Play);
    }

    private void OnGameBackEvent()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        EventHandler.CallGameMusicPlay(AudioClip.GameMusic, AudioPlayType.Stop);
        EventHandler.CallGameMusicPlay(AudioClip.Click, AudioPlayType.MuteOff);
    }

    private void OnGameReplayEvent(string sceneName)
    {
        StartCoroutine(SwitchScene(sceneName));
    }

    private void OnGamePassEvent(string sceneName)
    {
        if (m_MapNameList.Contains(sceneName))
        {
            m_MapNameList.Remove(sceneName);
            InitMap();
            StartCoroutine(SwitchScene(m_MapName));
        }
    }

    private static IEnumerator LoadScene(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        var scene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(scene);
    }

    private static IEnumerator SwitchScene(string sceneName)
    {
        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        yield return LoadScene(sceneName);
    }
}