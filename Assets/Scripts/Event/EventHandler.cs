using System;
using UnityEngine;

public class EventHandler
{
    public static event Action GameStartEvent;

    public static void CallGameStartEvent()
    {
        GameStartEvent?.Invoke();
    }

    public static event Action GameBackEvent;

    public static void CallGameBackEvent()
    {
        GameBackEvent?.Invoke();
    }

    public static event Action<string> GameReplayEvent;

    public static void CallGameReplayEvent(string sceneName)
    {
        GameReplayEvent?.Invoke(sceneName);
    }

    public static event Action<string> GamePassEvent;

    public static void CallGamePassEvent(string sceneName)
    {
        GamePassEvent?.Invoke(sceneName);
    }

    public static event Action<AudioClip, AudioPlayType> GameMusicPlay;

    public static void CallGameMusicPlay(AudioClip audioClip, AudioPlayType audioPlayType)
    {
        GameMusicPlay?.Invoke(audioClip, audioPlayType);
    }

    #region Mouse

    public static event Action<Vector3> GameMouseDown;

    public static void CallGameMouseDown(Vector3 vector3)
    {
        GameMouseDown?.Invoke(vector3);
    }

    #endregion
}