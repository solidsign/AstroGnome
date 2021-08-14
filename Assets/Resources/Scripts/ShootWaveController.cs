using System.Collections;
using UnityEngine;

public class ShootWaveController : MonoBehaviour
{
    [SerializeField] private float defaultSpeed;
    [SerializeField] private float defaultDamage;
    [SerializeField] private float activeTime;
    private ShootWaveColorIntensity color;
    private float damage;
    private float speed;
    private bool instanciated = false;

    private Animator animator;
    private Rigidbody2D rb;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        color = GetComponent<ShootWaveColorIntensity>();
        damage = defaultDamage;
        speed = defaultSpeed;
    }

    private void Update()
    {
        rb.MovePosition(transform.position + transform.up * speed);
        Vector3 scale = transform.localScale;
        scale.x += damage * Time.deltaTime;
        transform.localScale = scale;
    }

    private void OnEnable()
    {
        if (!instanciated)
        {
            Start();
            instanciated = true;
            return;
        }
        animator.SetTrigger("Activate");
        Vector3 scale = Vector3.one;
        transform.localScale = scale;
        StartCoroutine(WaveDisabler());
    }

    public void IncreaseDamage(float multiplier)
    {
        damage = defaultDamage * multiplier;
        speed = defaultSpeed * multiplier / 2;
        color.Intensity = multiplier;
    }

    public void DeactivateWave()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator WaveDisabler()
    {
        yield return new WaitForSeconds(activeTime);
        animator.SetTrigger("Deactivate");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemy;
        if (collision.transform.TryGetComponent<EnemyHealth>(out enemy))
        {
            enemy.DealDamage(collision.transform.position - transform.position, damage);
        }
    }
}
