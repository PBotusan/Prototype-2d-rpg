using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Abilities/Generic Ability", fileName = "New Generic Ability")]
public class GenericAbility : ScriptableObject
{
    [SerializeField] float duration;
    public float Duration { get {return duration; } set { duration = value; } }    

    public virtual void Ability(Vector2 playerPos, Vector2 playerFacingDirection, Rigidbody2D playerRigidBody = null) 
    {
        
    }

    public virtual void Ability(Vector2 playerPos, Rigidbody2D playerRigidBody = null)
    {

    }

    public virtual void Ability(Vector2 playerPos)
    {
        
    }

    public virtual void Ability()
    {

    }
}
