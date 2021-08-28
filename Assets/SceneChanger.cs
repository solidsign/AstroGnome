using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private Animator curtain;

    private void Start()
    {
        curtain.SetTrigger("Down");
    }

    public void NextLevel()
    {
        curtain.SetTrigger("Up");
        var op = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        op.allowSceneActivation = false;
        StartCoroutine(WaitForCurtain(op));
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator WaitForCurtain(AsyncOperation op)
    {
        yield return new WaitForSeconds(0.5f);
        op.allowSceneActivation = true;
    }

}
