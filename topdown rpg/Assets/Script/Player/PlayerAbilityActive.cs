using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityActive : MonoBehaviour
{
    [SerializeField] GenericAbility currentAbility;
   
    /// <summary>
    /// Playercontroller used from the playercontroller script
    /// </summary>
    [SerializeField] PlayerController playerController;

    [SerializeField] GenericAbility[] abilityNames;

   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Ability1"))
        {
            
            if (currentAbility)
            {
                // when player can choose different items but to chosen item in currentability
                currentAbility = abilityNames[0];
                StartCoroutine(AbilityCoroutine(currentAbility.Duration));
                Debug.Log("Ability1");
            }
        }

        if (Input.GetButtonDown("Ability2"))
        {
            if (currentAbility)
            {
                currentAbility = abilityNames[1];
                StartCoroutine(AbilityCoroutine(currentAbility.Duration));
                Debug.Log("Ability2");
            }
        }

        if (Input.GetButtonDown("Ability3"))
        {
            if (currentAbility)
            {
                currentAbility = abilityNames[2];
                StartCoroutine(AbilityCoroutine(currentAbility.Duration));
                Debug.Log("Ability3");
            }
        }
    }

    public IEnumerator AbilityCoroutine(float abilityDuration)
    {
        playerController.stateMachine.currentPlayerState = PlayerState.ability;
        if (currentAbility.name == "PlaceBomb")
        {
            currentAbility.Ability(playerController.PlayerRigidbody.position);
        }
        else
        {
            currentAbility.Ability();
        }
       
        yield return new WaitForSeconds(abilityDuration);
        playerController.stateMachine.currentPlayerState = PlayerState.idle;
    }
}
