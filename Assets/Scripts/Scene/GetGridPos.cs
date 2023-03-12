using UnityEngine;

public class GetGridPos : MonoBehaviour
{
    private bool m_CanPlace = true;

    public void OnMouseDown()
    {
        if (m_CanPlace)
        {
            EventHandler.CallGameMouseDownEvent(transform.localPosition);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
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