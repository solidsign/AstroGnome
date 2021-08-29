using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuritoSoundController : MonoBehaviour
{
    [SerializeField] private AudioClip loseMusic;
    [SerializeField] private AudioClip winMusic;
    [SerializeField] private float distanceOfPlayingWinMusic;
    [SerializeField] private Transform player;
    [SerializeField] private float startVolumeOfAstrognomeMusic;
    [SerializeField] private ComponentsDisabler button;
    [SerializeField] private AudioSource music;
    private AudioSource audioSource;
    private bool winMusicPlayed = false;
    private bool volumeZero = false;
    private float startDistance;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        music.PlayOneShot(loseMusic);
        startDistance = Vector3.Distance(player.position, transform.position);
    }

    private void FixedUpdate()
    {
        if(!winMusicPlayed && distanceOfPlayingWinMusic > Vector3.Distance(player.position, transform.position))
        {
            winMusicPlayed = true;
            StartCoroutine(ShowButton());
            StartCoroutine(LowMusicVolume());
            music.PlayOneShot(winMusic);
            PlayerPrefs.SetInt("GameCompleted", 1);
        }
        if (!volumeZero)
        {
            float x = startDistance - Vector3.Distance(player.position, transform.position);
            x = x / startDistance;
            audioSource.volume = startVolumeOfAstrognomeMusic + x;
        }
    }

    private IEnumerator ShowButton()
    {
        yield return new WaitForSeconds(5f);
        button.EnableComponents();
    }

    private IEnumerator LowMusicVolume()
    {
        audioSource.volume = 0f;
        volumeZero = true;
        yield return new WaitForSeconds(10f);
        while(audioSource.volume != 1f)
        {
            audioSource.volume = Mathf.Lerp(audioSource.volume, 1f, 3 * Time.deltaTime);
            yield return null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, distanceOfPlayingWinMusic);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
