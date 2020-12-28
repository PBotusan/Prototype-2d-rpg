using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] string loadScene;

    /// <summary>
    /// Current playerposition
    /// </summary>
    [SerializeField] Vector2 playerPos;

    /// <summary>
    /// old playerpostion shows the position the player first entered the building. 
    /// </summary>
    [SerializeField] VectorValueOfPlayer playerPosOldValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger) 
        {
            playerPosOldValue.initialValue = playerPos;
            SceneManager.LoadScene(loadScene);
        }
    }
}
