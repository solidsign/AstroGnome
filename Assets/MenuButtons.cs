using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private Animator curtain;
    [SerializeField] private Button cheatsButton;
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        curtain.SetTrigger("Stay");
        if(PlayerPrefs.GetInt("GameCompleted", 0) == 1)
        {
            cheatsButton.interactable = true;
        }
    }
    public void Play()
    {
        curtain.SetTrigger("Up");
        var op = SceneManager.LoadSceneAsync(1);
        op.allowSceneActivation = false;
        StartCoroutine(Wait(op));
    }

    public void Cheats()
    {
        DontDestroyOnLoad(Camera.main.gameObject);
        SceneManager.LoadScene(5);
    }

    public void Options()
    {
        DontDestroyOnLoad(Camera.main.gameObject);
        SceneManager.LoadScene(6);
    }

    public void Exit()
    {
        Application.Quit();
    }

    private IEnumerator Wait(AsyncOperation op)
    {
        yield return new WaitForSeconds(0.5f);
        audioSource.Stop();
        op.allowSceneActivation = true;
    }
}
