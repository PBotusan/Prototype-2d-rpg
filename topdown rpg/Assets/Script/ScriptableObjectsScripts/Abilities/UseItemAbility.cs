using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Abilities/Usable Abilty", fileName = "New Usable Ability")]
public class UseItemAbility : GenericAbility
{
    [SerializeField] InventoryItem useItem;

    public override void Ability()
    {
        /*ThrowBomb temp = placeObject.GetComponent<ThrowBomb>();
        if (temp)
        {
            temp.Setup(playerPos);
        }*/
        Debug.Log("Use Potion = " + useItem.name + " " + useItem.ItemDescription);
    }

}
