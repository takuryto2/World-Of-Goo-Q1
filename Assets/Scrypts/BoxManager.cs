using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    [Header("drag n drop")]
    private bool dragging = false;
    private Vector3 offset;

    [Header("Box Detection")]
    [SerializeField] private float radius;
    private int boxCount;

    [Header("Spring Connection")]
    private List<Collider2D> targets;
    private List<SpringJoint2D> joints;
    private bool isConnected;

    private void Update()
    {
        if (dragging && !isConnected)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            if (Input.GetMouseButton(0))
            {
                targets = Physics2D.OverlapCircleAll(transform.position, radius, 3 << LayerMask.NameToLayer("Anchor")).ToList();
                print(targets[0].gameObject.name);
                print(targets.Count);
            }
        }
    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }
    private void OnMouseUp()
    {
        dragging = false;
        if (targets.Count >= 2)
        {
            isConnected = true;
            for (int i = 1; i < targets.Count; i++)
            {
                gameObject.AddComponent<SpringJoint2D>();
                joints[i-1].connectedBody = targets[i].gameObject.GetComponent<Rigidbody2D>();
            }
        }
    }
    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
