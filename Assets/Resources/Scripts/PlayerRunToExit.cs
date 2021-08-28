using System.Collections;
using UnityEngine;

public class PlayerRunToExit : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private ComponentsDisabler playerDisabler;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Transform holeToJumpIn;
    [Range(0.4f, 2f)] [SerializeField] private float timeOfRunning;
    private Transform player;

    public void StartRunning()
    {
        playerAnimator.SetBool("Run", true);
        playerDisabler.DisableComponents();
        player = playerRB.transform;
        if(player.position.x < holeToJumpIn.position.x)
        {
            if(player.rotation.eulerAngles.y > 100f)
            {
                player.Rotate(0f, 180f, 0f);
            }
        }
        else
        {
            if (player.rotation.eulerAngles.y < 100f)
            {
                player.Rotate(0f, 180f, 0f);
            }
        }
        StartCoroutine(Running());
    }

    private IEnumerator Running()
    {
        Vector3 displacementPerSecond = (holeToJumpIn.position - player.position) / timeOfRunning;
        Debug.Log(holeToJumpIn.position);
        Debug.Log(player.position);
        Debug.Log(holeToJumpIn.position - player.position);
        Debug.Log(displacementPerSecond);
        float timer = 0f;
        bool jumped = false;
        while(timer < timeOfRunning)
        {
            if(!jumped && timeOfRunning - timer < 0.5f)
            {
                playerAnimator.SetBool("Run", false);
                playerAnimator.SetTrigger("Jump");
                jumped = true;
            }
            playerRB.MovePosition(player.position + displacementPerSecond * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(holeToJumpIn.position, Vector3.one);
    }
}
