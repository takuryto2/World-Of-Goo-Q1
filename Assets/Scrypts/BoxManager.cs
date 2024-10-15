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
    [SerializeField] private bool isConnected;
    private List<Collider2D> targets;

    [Header("Spring Parameters")]
    [SerializeField] private float distance;
    [SerializeField] private float dampingRatio;
    [SerializeField] private float frequency;

    private void Update()
    {
        if (dragging && !isConnected)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            if (Input.GetMouseButton(0))
            {
                targets = Physics2D.OverlapCircleAll(transform.position, radius, 3 << LayerMask.NameToLayer("Anchor")).ToList();
            }
        }

        if (isConnected)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.gray;

            GetComponent<BoxManager>().enabled = false;
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
        if (targets.Count >= 3 && !isConnected)
        {
            isConnected = true;
            for (int i = 0; i < targets.Count; i++)
            {
                SpringJoint2D joint =  gameObject.AddComponent<SpringJoint2D>();
                joint.autoConfigureDistance = false;
                joint.distance = distance;
                joint.dampingRatio = dampingRatio;
                joint.frequency = frequency;
                joint.connectedBody = targets[i].gameObject.GetComponent<Rigidbody2D>();
            }
        }
    }
    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
