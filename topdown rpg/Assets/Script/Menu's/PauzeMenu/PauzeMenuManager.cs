using UnityEngine;
using UnityEngine.SceneManagement;

public class PauzeMenuManager : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] string mainMenu;

    private bool isPaused;


    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            CheckIfPaused();
        }
    }

    public void CheckIfPaused()
    {
        isPaused = !isPaused;

        // lazy quick way
        if (isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }


    public void Quit()
    {
         Time.timeScale = 1;
        SceneManager.LoadScene(mainMenu);
    }
}
