using UnityEngine;

public class PlayerToMouseLooker : MonoBehaviour
{
    private Camera cam;
    private bool facingRight = true;

    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        float mousePosX = cam.ScreenToWorldPoint(Input.mousePosition).x;
        if ((!facingRight && mousePosX >= transform.position.x) || (facingRight && mousePosX < transform.position.x))
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
