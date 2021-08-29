using UnityEngine;
using UnityEngine.SceneManagement;

public class GetBackToMenu : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
