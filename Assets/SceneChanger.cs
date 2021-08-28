using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private Animator curtain;
    AsyncOperation op;

    private void Start()
    {
        curtain.SetTrigger("Down");
    }

    public void NextLevel()
    {
        curtain.SetTrigger("Up");
        op = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        op.allowSceneActivation = false;
    }

    public void AllowSceneActivation()
    {
        op.allowSceneActivation = true;
    }

}
