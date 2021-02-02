using UnityEngine.SceneManagement;
using UnityEngine;

public class Titlescreen : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
