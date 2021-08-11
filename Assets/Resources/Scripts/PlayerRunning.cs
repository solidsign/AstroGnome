using UnityEngine;

public class PlayerRunning : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 velocity = Vector2.zero;
    private Animator animator;
    private bool run;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        velocity.x = Input.GetAxis("Horizontal");
        velocity.y = Input.GetAxis("Vertical");
        if (run != (velocity.magnitude != 0f))
        {
            run = (velocity.magnitude != 0f);
            animator.SetBool("Run", run);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition((Vector2)transform.position + speed * Time.fixedDeltaTime *  velocity);
    }

    public void DisableRunning()
    {
        animator.SetBool("Run", false);
        enabled = false;
    }

    public void EnableRunning()
    {
        enabled = true;
        velocity.x = Input.GetAxis("Horizontal");
        velocity.y = Input.GetAxis("Vertical");
        run = (velocity.magnitude != 0f);
        animator.SetBool("Run", run);
    }
}
