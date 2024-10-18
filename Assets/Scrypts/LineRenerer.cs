using UnityEngine;

public class LineRenerer : MonoBehaviour
{
    [SerializeField] private LineRenderer renerer;
    public GameObject target1;
    public GameObject target2;
    public SpringJoint2D SpringJoint2D;

    void Update()
    {
        renerer.SetPosition(0, target1.transform.position);
        renerer.SetPosition(1, target2.transform.position);
        if (SpringJoint2D == null)
        {
            Destroy(gameObject);
        }
    }
}
