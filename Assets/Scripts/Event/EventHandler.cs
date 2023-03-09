using System;

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
}