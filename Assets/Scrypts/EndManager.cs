using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EndManager : MonoBehaviour
{
    [Header("Win Values")]
    [SerializeField] private bool isConnected = false;
    [SerializeField] private float timer;

    [Header("Box Detection")]
    [SerializeField] private Vector2 coliderPos;
    [SerializeField] private float coliderRadius;
    [SerializeField] private GameObject winImage;
    private List<Collider2D> target;
    private PointEffector2D effector;

    private void Start()
    {
        effector = GetComponent<PointEffector2D>();
        effector.enabled = false;
        winImage.SetActive(false);
    }

    private void Update()
    {
        target = Physics2D.OverlapCircleAll(new Vector3(transform.position.x + coliderPos.x, transform.position.y + coliderPos.y),
            coliderRadius, 3 << LayerMask.NameToLayer("Anchor")).ToList();
        if (target[0].gameObject.TryGetComponent<BoxManager>(out BoxManager component))
        {
            if(!component.isActiveAndEnabled)
            {
                effector.enabled = true;
                isConnected = true;
            }
        }
        if (target.Count >= 1)
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                winImage.SetActive(true);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x + coliderPos.x, transform.position.y + coliderPos.y) , coliderRadius);
    }
}
