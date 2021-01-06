using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSystem : MonoBehaviour
{
    /// <summary>
    /// Interaction symbol used to inform player
    /// </summary>
    [SerializeField] GameObject interactionSymbol;


    public void InteractionEnabled()
    {
        interactionSymbol.SetActive(true);
    }

    public void InteractionDisabled()
    {
        interactionSymbol.SetActive(false);
    }

}
