using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EndManager : MonoBehaviour
{
    [Header("Win Values")]
    [SerializeField] private bool isConnected = false;

    [Header("Box Detection")]
    [SerializeField] private Vector2 coliderPos;
    [SerializeField] private float coliderRadius;
    private List<Collider2D> target;
    private PointEffector2D effector;
    private int boxCount;

    private void Start()
    {
        effector = GetComponent<PointEffector2D>();
        effector.enabled = false;
    }

    private void Update()
    {
        target = Physics2D.OverlapCircleAll(new Vector3(transform.position.x + coliderPos.x, transform.position.y + coliderPos.y),
            coliderRadius, 3 << LayerMask.NameToLayer("Anchor")).ToList();
        print(target.Count);
        print(target[0]);
        //if()
        /*if (!target[0].gameObject.GetComponent<BoxManager>().isActiveAndEnabled)
        {
            effector.enabled = true;
            isConnected = true;
        }*/
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x + coliderPos.x, transform.position.y + coliderPos.y) , coliderRadius);
    }
}
