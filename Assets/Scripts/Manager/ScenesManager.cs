using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    private string[] m_MapNameArray = new[] { "Map01", "Map02" };
    private List<string> m_MapNameList = new List<string>();
    private string m_MapName;

    private void Awake()
    {
        SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
        EventHandler.GameStartEvent += OnGameStartEvent;
        EventHandler.GameBackEvent += OnGameBackEvent;
        EventHandler.GamePassEvent += OnGamePassEvent;
        EventHandler.GameReplayEvent += OnGameReplayEvent;
        EventHandler.GameContinueEvent += OnGameContinueEvent;
    }

    private void OnDestroy()
    {
        EventHandler.GameStartEvent -= OnGameStartEvent;
        EventHandler.GameBackEvent -= OnGameBackEvent;
        EventHandler.GamePassEvent -= OnGamePassEvent;
        EventHandler.GameReplayEvent -= OnGameReplayEvent;
        EventHandler.GameContinueEvent -= OnGameContinueEvent;
    }

    private void InitMap()
    {
        var mapNum = m_MapNameList.Count;
        if (mapNum == 0)
        {
            m_MapName = null;
            return;
        }

        var mapId = Random.Range(0, mapNum);

        m_MapName = m_MapNameList[mapId];
    }

    private void OnGameStartEvent()
    {
        m_MapNameList.Clear();
        foreach (var mapName in m_MapNameArray)
        {
            m_MapNameList.Add(mapName);
        }

        DataManager.SetStringArray("AllMaps", m_MapNameList.ToArray());

        InitMap();
        StartCoroutine(LoadScene(m_MapName));
        EventHandler.CallGameMusicPlayEvent(AudioClip.GameMusic, AudioPlayType.Play);
    }

    private void OnGameContinueEvent(string sceneName)
    {
        m_MapNameList.Clear();
        foreach (var mapName in DataManager.GetStringArray("AllMaps"))
        {
            m_MapNameList.Add(mapName);
        }

        StartCoroutine(LoadScene(sceneName));
        EventHandler.CallGameMusicPlayEvent(AudioClip.GameMusic, AudioPlayType.Play);
    }

    private void OnGameBackEvent()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        EventHandler.CallGameMusicPlayEvent(AudioClip.GameMusic, AudioPlayType.Stop);
        EventHandler.CallGameMusicPlayEvent(AudioClip.Click, AudioPlayType.MuteOff);
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

            DataManager.SetStringArray("AllMaps", m_MapNameList.ToArray());

            InitMap();

            if (m_MapName == null)
            {
                DataManager.SetStringData("CurrentMap", string.Empty);
                UIManager.Instance.ShowUI(UIType.UIGameOver);
            }
            else
            {
                StartCoroutine(SwitchScene(m_MapName));
            }
        }
    }

    private static IEnumerator LoadScene(string sceneName)
    {
        UIManager.Instance.ShowUI(UIType.UILoading,1f);
        yield return new WaitForSeconds(1f);
        // yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        yield return operation;
        var scene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(scene);
        EventHandler.CallGameGetMapNameEvent(sceneName);
        DataManager.SetStringData("CurrentMap", sceneName);
    }

    private static IEnumerator SwitchScene(string sceneName)
    {
        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        yield return LoadScene(sceneName);
    }
}