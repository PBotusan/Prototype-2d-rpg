using UnityEngine;
using UnityEngine.SceneManagement;

public class PauzeMenuManager : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject inventoryPanel;

    [SerializeField] bool usingPausePanel;
    [SerializeField] string mainMenu;

    private bool isPaused;


    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        inventoryPanel.SetActive(false);
        usingPausePanel = false;
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
            inventoryPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }


    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenu);
    }

    public void SwitchPanels()
    {
        usingPausePanel = !usingPausePanel;
        if (usingPausePanel)
        {
            pausePanel.SetActive(true);
            inventoryPanel.SetActive(false);
        }
        else
        {
            inventoryPanel.SetActive(true);
            pausePanel.SetActive(false);
        }
    }
}
