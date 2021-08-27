using UnityEngine;

public class FireTotem : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private GameObjectsPool projectiles;
    private AudioHandler audioHandler;

    private Transform attackPurpose;
    public Transform AttackPurpose { set => attackPurpose = value; }

    private void Start()
    {
        audioHandler = GetComponent<EditableAudioHandler>();
    }

    public void ShootProjectile()
    {
        audioHandler.PlaySound("Attack");
        GameObject projectile = projectiles.GetObject();

        projectile.transform.position = attackPoint.position;
        projectile.transform.rotation = Quaternion.LookRotation(Vector3.forward, (attackPurpose.position - attackPoint.position).normalized);

        if (projectile.activeSelf)
        {
            projectile.SetActive(false);
        }
        projectile.SetActive(true);
    }

    private void OnDisable()
    {
        Destroy(gameObject, 5f);
    }
}
