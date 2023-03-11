using UnityEngine;

public class GetGridPos : MonoBehaviour
{
    public void OnMouseDown()
    {
        EventHandler.CallGameMouseDown(transform.localPosition);
    }
}