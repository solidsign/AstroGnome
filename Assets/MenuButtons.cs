using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private Animator curtain;
    [SerializeField] private Button cheatsButton;

    private void Start()
    {
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
        SceneManager.LoadScene(5);
    }

    public void Options()
    {
        SceneManager.LoadScene(6);
    }

    private IEnumerator Wait(AsyncOperation op)
    {
        yield return new WaitForSeconds(0.5f);
        op.allowSceneActivation = true;
    }
}
