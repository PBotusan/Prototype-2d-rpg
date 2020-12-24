using UnityEngine.UI;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] Image[] hearts;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite halfFullHeart;
    [SerializeField] Sprite emptyHeart;


    [SerializeField] FloatValue heartContainers;

    [SerializeField] FloatValue playerCurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
    }

    public void InitHearts()
    {
        for (int i = 0; i < heartContainers.initialValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }

    }

    public void UpdateHearts()
    {
        float tempHealth = playerCurrentHealth.RuntimeValue / 2;
        for (int i = 1; i < heartContainers.initialValue; i++)
        {
            if (i <= tempHealth)
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
