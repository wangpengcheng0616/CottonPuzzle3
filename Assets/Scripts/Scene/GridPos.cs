using UnityEngine;

public class GridPos : MonoBehaviour
{
    private bool m_CanPlace = true;

    private void Awake()
    {
        EventHandler.GameUISettingEvent += OnGameUISettingEvent;
    }

    private void OnDestroy()
    {
        EventHandler.GameUISettingEvent -= OnGameUISettingEvent;
    }

    private void OnGameUISettingEvent(bool boolValue)
    {
        m_CanPlace = boolValue;
    }

    public void OnMouseDown()
    {
        if (m_CanPlace)
        {
            EventHandler.CallGameMouseDownEvent(transform.localPosition);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Snake"))
        {
            m_CanPlace = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Snake"))
        {
            m_CanPlace = true;
        }
    }
}