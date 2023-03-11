using UnityEngine;

public class GetGridPos : MonoBehaviour
{
    public void OnMouseDown()
    {
        EventHandler.CallGameMouseDownEvent(transform.localPosition);
    }
}