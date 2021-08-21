using UnityEngine;

public class FireTotem : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private GameObjectsPool projectiles;

    private Transform attackPurpose;
    public Transform AttackPurpose { set => attackPurpose = value; }

    public void ShootProjectile()
    {
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
