using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private Animator curtain;
    [SerializeField] private ComponentsDisabler button;
    [SerializeField] private AudioClip deathMusic;
    [SerializeField] private EnemyManager enemies;
    [SerializeField] private HealthInterface hp;
    private AudioSource audioSource;
    private bool lost = false;

    private void Start()
    {
        curtain.SetTrigger("Down");
        audioSource = GetComponent<AudioSource>();
    }

    public void CurtainUp()
    {
        curtain.SetTrigger("Up");
    }

    public void NextLevel()
    {
        CurtainUp();
        var op = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        op.allowSceneActivation = false;
        StartCoroutine(WaitForCurtain(op));
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Lose()
    {
        if (lost) return;
        lost = true;
        enemies.StopAllCoroutines();
        enemies.StopAllEnemies();
        enemies.StopAllPlayersGuys();
        hp.StopMusic();
        CurtainUp();
        StartCoroutine(WaitForCurtain());
        StartCoroutine(StopMusic());
    }

    private IEnumerator StopMusic()
    {
        while (audioSource.volume > 0.1f)
        {
            audioSource.volume = Mathf.Lerp(audioSource.volume, 0f, 2 * Time.deltaTime);
            yield return null;
        }
        audioSource.Stop();
        audioSource.volume = 1f;
        audioSource.PlayOneShot(deathMusic);
    }

    private IEnumerator WaitForCurtain()
    {
        yield return new WaitForSeconds(0.5f);
        button.EnableComponents();
    }


    private IEnumerator WaitForCurtain(AsyncOperation op)
    {
        yield return new WaitForSeconds(0.5f);
        op.allowSceneActivation = true;
    }

}
