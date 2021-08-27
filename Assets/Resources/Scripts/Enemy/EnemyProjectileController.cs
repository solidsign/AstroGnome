using System.Collections;
using UnityEngine;

public class EnemyProjectileController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float flyTime;
    [SerializeField] private AudioClip hitSound;

    private AudioSource audioSource;
    private Rigidbody2D rb;
    private Animator animator;
    private bool instanciated = false;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        if (!instanciated)
        {
            Start();
            instanciated = true;
            return;
        }
        StartCoroutine(FlyTimer());
        StartCoroutine(Fly());
    }

    private IEnumerator Fly()
    {
        while (true)
        {
            rb.MovePosition(transform.position + transform.up * speed);
            yield return null;
        }
    }
    private IEnumerator FlyTimer()
    {
        yield return new WaitForSeconds(flyTime);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthHandler hp;
        if(collision.TryGetComponent<HealthHandler>(out hp))
        {
            audioSource.PlayOneShot(hitSound);
            hp.DealDamage(damage);
            StopAllCoroutines();
            animator.SetTrigger("Disable");
        }
    }

    public void DisableProjectile()
    {
        gameObject.SetActive(false);
    }
}
