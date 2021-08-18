using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    private float speed;
    private Vector2 velocity = Vector2.zero;
    private Rigidbody2D rb;
    private Animator animator;
    private bool lookRight = true;
    public float Speed { set => speed = value; }

    public Vector2 Direction
    {
        set
        {
            if (value == Vector2.zero) velocity = Vector2.zero;
            else velocity = value.normalized;
        }
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(velocity.magnitude > 0f)
        {
            rb.MovePosition((Vector2)transform.position + Time.deltaTime * speed * velocity);
            animator.SetBool("Run", true);
            if (!lookRight && velocity.x > 0f) transform.Rotate(0, 180f, 0);
            else if(lookRight && velocity.x < 0f) transform.Rotate(0, 180f, 0);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }
}
