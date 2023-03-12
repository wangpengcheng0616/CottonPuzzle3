using UnityEngine;

public class SnakeDrag : MonoBehaviour
{
    public SnakeId m_SnakeId;
    public SnakeDragType m_SnakeDragType;

    private void OnMouseDown()
    {
        EventHandler.CallGameSnakeMoveEvent(m_SnakeId, m_SnakeDragType);
    }
}

public enum SnakeId
{
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Night,
}

public enum SnakeDragType
{
    Head,
    Tail
}