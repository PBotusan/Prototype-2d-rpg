using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Abilities/PlaceBomb Abilty", fileName = "New PlaceBomb Ability")]
public class PlaceBombAbility : GenericAbility
{
    [SerializeField] GameObject placeObject;

    public override void Ability(Vector2 playerPos)
    {
        ThrowBomb temp = placeObject.GetComponent<ThrowBomb>();
        if (temp)
        {
            temp.Setup(playerPos);
        }
    }
}
