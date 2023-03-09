using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource m_AudioSource;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
        EventHandler.GameMusicPlay += OnGameMusicPlay;
    }

    private void OnGameMusicPlay(AudioPlayType audioPlayType)
    {
        switch (audioPlayType)
        {
            case AudioPlayType.Play:
                m_AudioSource.Play();
                break;
            case AudioPlayType.MuteOn:
                m_AudioSource.mute = true;
                break;
            case AudioPlayType.MuteOff:
                m_AudioSource.mute = false;
                break;
            case AudioPlayType.Stop:
                m_AudioSource.Stop();
                m_AudioSource.mute = false;
                break;
        }
    }

    private void OnDestroy()
    {
        EventHandler.GameMusicPlay -= OnGameMusicPlay;
    }
}

public enum AudioPlayType
{
    Play,
    MuteOn,
    MuteOff,
    Stop
}