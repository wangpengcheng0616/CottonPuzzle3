using UnityEngine;

public class Drag : MonoBehaviour
{
    private Vector3 offest;

    private bool isDrag;

    private void Update()
    {
        if (isDrag)
        {
            transform.localPosition = GetCurPos() - offest;
        }
    }

    private void OnMouseDown()
    {
        isDrag = true;
        offest = GetCurPos() - transform.localPosition;
    }

    private void OnMouseUp()
    {
        isDrag = false;
    }

    private Vector3 GetCurPos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}