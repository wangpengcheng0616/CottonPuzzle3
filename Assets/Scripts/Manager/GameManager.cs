using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // TODO: configuration table
    private string[] m_MapNameArray = new[] { "Map01", "Map02", "Map03" };
    private int[] m_GamePassNumArray = new[] { 2, 2, 1 };
    private int m_GamePassNum;

    private void Awake()
    {
        EventHandler.GamePassNumEvent += OnGamePassNumEvent;
        EventHandler.GameGetMapNameEvent += OnGameGetMapNameEvent;
    }

    private void OnDestroy()
    {
        EventHandler.GamePassNumEvent -= OnGamePassNumEvent;
        EventHandler.GameGetMapNameEvent -= OnGameGetMapNameEvent;
    }

    private void OnGameGetMapNameEvent(string sceneName)
    {
        var length = m_MapNameArray.Length;
        for (var i = 0; i < length; i++)
        {
            if (sceneName != m_MapNameArray[i]) continue;
            m_GamePassNum = m_GamePassNumArray[i];
            return;
        }
    }

    private void OnGamePassNumEvent(int num)
    {
        m_GamePassNum += num;
        // TODO: Collider Bug
        if (m_GamePassNum == 0)
        {
            EventHandler.CallGamePassEvent(SceneManager.GetActiveScene().name);
        }
    }
}