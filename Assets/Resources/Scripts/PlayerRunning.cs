using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunning : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 velocity = Vector2.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        velocity.x = Input.GetAxis("Horizontal");
        velocity.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rb.MovePosition((Vector2)transform.position + velocity * Time.fixedDeltaTime);
    }
}
