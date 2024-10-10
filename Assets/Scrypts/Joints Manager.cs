using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JointsManager : MonoBehaviour
{
    [Header("Box Detection")]
    [SerializeField] private float radius;
    private int boxCount;


    [Header("Spring Connection")]
    private List<Collider2D> targets;
    private bool isConnected;

    void Start()
    {
    }

    public void Detect()
    {
        targets = Physics2D.OverlapCircleAll(transform.position, radius, 3 << LayerMask.NameToLayer("Anchor")).ToList();
        print(targets.Count);
    }

    public void Connect()
    {
        if (boxCount >= 3)
        {
            for (int i = 1; i < targets.Count; i++)
            {
                
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
