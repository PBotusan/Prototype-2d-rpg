using UnityEngine.UI;
using UnityEngine;

public class PlayerHealthHUD : MonoBehaviour
{
    /// <summary>
    /// image array of hearts
    /// </summary>
    [SerializeField] Image[] hearts;

    /// images used for hearts
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite halfFullHeart;
    [SerializeField] Sprite emptyHeart;


    public FloatValue heartContainers;
    public FloatValue playerCurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
    }

    /// <summary>
    /// init all the hearts and set the amount to active
    /// </summary>
    public void InitHearts()
    {
        for (int i = 0; i < heartContainers.RuntimeValue; i++)
        {
            if (i < hearts.Length)
            {
                hearts[i].gameObject.SetActive(true);
                hearts[i].sprite = fullHeart;
            }
        }

    }

    /// <summary>
    /// update the current amount of health
    /// </summary>
    public void UpdateHearts()
    {
        InitHearts();
        float tempHealth = playerCurrentHealth.RuntimeValue / 2;
        for (int i = 0; i < heartContainers.RuntimeValue; i++)
        {
            if (i <= tempHealth - 1)
            {
                //full
                hearts[i].sprite = fullHeart;
            }
            else if (i >= tempHealth)
            {
                //emptyHeart
                hearts[i].sprite = emptyHeart;
            }
            else
            {
                //half-full
                hearts[i].sprite = halfFullHeart;
            }
        }


    }

}
