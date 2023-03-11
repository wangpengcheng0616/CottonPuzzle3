using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] m_AudioSources;

    private void Awake()
    {
        EventHandler.GameMusicPlayEvent += OnGameMusicPlayEvent;
    }

    private void OnGameMusicPlayEvent(AudioClip audioClip, AudioPlayType audioPlayType)
    {
        var id = (int)audioClip;
        var audioSource = m_AudioSources[id];
        switch (audioPlayType)
        {
            case AudioPlayType.Play:
                audioSource.Play();
                break;
            case AudioPlayType.MuteOn:
                audioSource.mute = true;
                break;
            case AudioPlayType.MuteOff:
                audioSource.mute = false;
                break;
            case AudioPlayType.Stop:
                audioSource.Stop();
                audioSource.mute = false;
                break;
        }
    }

    private void OnDestroy()
    {
        EventHandler.GameMusicPlayEvent -= OnGameMusicPlayEvent;
    }
}

public enum AudioClip
{
    GameMusic,
    Click
}

public enum AudioPlayType
{
    Play,
    MuteOn,
    MuteOff,
    Stop
}