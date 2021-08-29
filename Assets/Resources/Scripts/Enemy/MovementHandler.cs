using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    private float speed;
    private Vector2 velocity = Vector2.zero;
    private Rigidbody2D rb;
    [SerializeField] private bool lookRight = true;
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
    }

    private void Update()
    {
        if(velocity.magnitude > 0f)
        {
            rb.MovePosition((Vector2)transform.position + Time.deltaTime * speed * velocity);
            if (!lookRight && velocity.x > 0f) Flip();
            else if(lookRight && velocity.x < 0f) Flip();
        }
    }

    private void Flip()
    {
        transform.Rotate(0, 180f, 0);
        lookRight = !lookRight;
    }
}
