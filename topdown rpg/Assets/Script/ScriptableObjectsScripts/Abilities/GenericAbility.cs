using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Abilities/Generic Ability", fileName = "New Generic Ability")]
public class GenericAbility : ScriptableObject
{
    [SerializeField] float staminaCost;
    [SerializeField] float duration;
    public float Duration { get {return duration; } set { duration = value; } }

    [SerializeField] FloatValue playerStamina;
    

    public virtual void Ability(Vector2 playerPos, Vector2 playerFacingDirection, Rigidbody2D playerRigidBody = null) 
    {
        
    }
}
