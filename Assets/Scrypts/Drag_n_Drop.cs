using UnityEngine;

public class Drag_n_Drop : MonoBehaviour
{
    JointsManager JointsManager;
    private bool dragging = false;
    private Vector3 offset;

    private void Update()
    {
        if (dragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
        JointsManager.Detect();
    }
    private void OnMouseUp()
    {
        dragging = false; 
    }
}
