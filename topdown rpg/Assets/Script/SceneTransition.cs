using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] string loadScene;

    /// <summary>
    /// Current playerposition
    /// </summary>
    [SerializeField] Vector2 playerPos;
    [SerializeField] VectorValueOfPlayer playerStorage;

    /// <summary>
    /// old playerpostion shows the position the player first entered the building. 
    /// </summary>
    [SerializeField] VectorValueOfPlayer playerPosOldValue;


    [SerializeField] GameObject fadeInPanel;
    [SerializeField] GameObject fadeOutPanel;
    [SerializeField] float fadeTime;


    //todo dungeon fading
    //todo cave fading
    //todo death fading
    //todo gameover fadin

    

    private void Awake()
    {
        if (fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger) 
        {
            playerPosOldValue.initialValue = playerPos;
            StartCoroutine(FadeCoroutine());

        }

    }

    public IEnumerator FadeCoroutine()
    {
        if (fadeOutPanel)
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }

        yield return new WaitForSeconds(fadeTime);


        //fade after loading
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(loadScene);

        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }

   
}
