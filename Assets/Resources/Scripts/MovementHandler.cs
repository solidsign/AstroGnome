using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    private float speed;
    private Vector2 velocity = Vector2.zero;
    private Rigidbody2D rb;
    private Animator animator;

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
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }
}
