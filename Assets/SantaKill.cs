using UnityEngine;
using UnityEngine.UI;


public class SantaKill : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private ComponentsDisabler bandit;
    [SerializeField] private Animator banditAnimator;
    [SerializeField] private ComponentsDisabler player;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private Animator santaAnimator;

    public void PlayerExpression()
    {
        text.enabled = true;
        playerAnimator.SetTrigger("Expression");
    }

    public void BanditShoot()
    {
        banditAnimator.SetTrigger("Attack");
    }

    public void HideText()
    {
        text.enabled = false;
    }
    public void ShowText()
    {
        text.enabled = true;
    }

    public void SantaDie()
    {
        santaAnimator.SetTrigger("Dead");
    }
    public void DisableComponents()
    {
        bandit.DisableComponents();
        player.DisableComponents();
    }

    public void EnableComponents()
    {
        bandit.EnableComponents();
        player.EnableComponents();
        enemyManager.gameObject.SetActive(true);
    }
}
