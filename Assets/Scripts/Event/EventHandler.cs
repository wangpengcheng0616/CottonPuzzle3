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

    public static event Action<AudioClip, AudioPlayType> GameMusicPlayEvent;

    public static void CallGameMusicPlayEvent(AudioClip audioClip, AudioPlayType audioPlayType)
    {
        GameMusicPlayEvent?.Invoke(audioClip, audioPlayType);
    }

    #region Mouse

    public static event Action<Vector3> GameMouseDownEvent;

    public static void CallGameMouseDownEvent(Vector3 vector3)
    {
        GameMouseDownEvent?.Invoke(vector3);
    }

    #endregion

    public static event Action<int> GamePassNumEvent;

    public static void CallGamePassNumEvent(int num)
    {
        GamePassNumEvent?.Invoke(num);
    }

    public static event Action<string> GameGetMapNameEvent;

    public static void CallGameGetMapNameEvent(string name)
    {
        GameGetMapNameEvent?.Invoke(name);
    }
}