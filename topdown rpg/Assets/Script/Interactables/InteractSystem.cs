using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSystem : MonoBehaviour
{
    /// <summary>
    /// Interaction symbol used to inform player
    /// </summary>
    [SerializeField] GameObject interactionSymbol;

    [SerializeField] bool interactionActive = false;


    public void ToggleContextSymbol()
    {
        interactionActive = !interactionActive;
        if (interactionActive)
        {
            interactionSymbol.SetActive(interactionActive);
        }
        else
        {
            interactionSymbol.SetActive(interactionActive);
        }

    }
}
