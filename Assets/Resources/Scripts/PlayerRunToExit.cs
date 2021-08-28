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
        playerRB.useFullKinematicContacts = false;
        playerDisabler.DisableComponents();
        player = playerRB.transform;
    }

    private IEnumerator Running()
    {
        Vector3 displacementPerSecond = holeToJumpIn.position - player.position;
        float timer = 0f;
        bool jumped = false;
        while(timer < timeOfRunning)
        {
            if(!jumped && timer < 0.5f)
            {
                playerAnimator.SetBool("Run", false);
                playerAnimator.SetTrigger("Jump");
                jumped = true;
            }
            player.Translate(displacementPerSecond * Time.deltaTime);
            yield return null;
        }
    }
}
