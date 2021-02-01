using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class StaminaManager : MonoBehaviour
{
    [SerializeField] Slider staminaSlider;
    [SerializeField] Inventory playerInventory;
    [SerializeField] PlayerController playerController;

    /// <summary>
    /// Max value of stamina.
    /// </summary>
    public float maxStamina = 100;
    /// <summary>
    /// Current stamina amount of player.
    /// </summary>
    public float currentStamina;

    private bool stillAttacking;

    // Start is called before the first frame update
    void Start()
    {
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = maxStamina;

        currentStamina = maxStamina;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (staminaSlider.value < maxStamina)
        {
            StartCoroutine(RegenerateStaminaCoroutine());
        }
    }

    private IEnumerator RegenerateStaminaCoroutine()
    {
        yield return new WaitForSeconds(2);
        staminaSlider.value += 0.5f;
        currentStamina += 0.5f;
    }

    public void DecreaseStamina(float amount)
    {
        staminaSlider.value -= amount; // ui stamina
        currentStamina -= amount; // current stamina

        if (staminaSlider.value < 0)
        {
            staminaSlider.value = 0f;
            currentStamina = 0f;
        }
    } 
}
