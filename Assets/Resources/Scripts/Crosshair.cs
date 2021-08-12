using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private float distanceFromCenterToAttackPoint;
    [SerializeField] private Vector3 centerOffset;
    private Camera cam;
    private Vector3 mousePos;

    public GameObject pref;

    public Vector3 AttackPoint
    {
        get
        {
            return (mousePos - (transform.position + centerOffset)).normalized * distanceFromCenterToAttackPoint + transform.position + centerOffset;
        }
    }

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        if (Input.GetKeyDown(KeyCode.V))
        {
            Instantiate(pref, AttackPoint, Quaternion.Euler(0, 0, 0));
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position + centerOffset, distanceFromCenterToAttackPoint);
    }
}
