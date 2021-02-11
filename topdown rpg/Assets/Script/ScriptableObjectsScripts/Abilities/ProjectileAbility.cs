using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Abilities/Projectile Abilty", fileName = "New Projectile Ability")]
public class ProjectileAbility : GenericAbility 
{
    [SerializeField] GameObject projectile;

    public override void Ability(Vector2 playerPos, Vector2 playerFacingDirection, Rigidbody2D playerRigidBody = null)
    {
        float facingRotation = Mathf.Atan2(playerFacingDirection.y, playerFacingDirection.x)*Mathf.Rad2Deg;
        GameObject newProjectile = Instantiate(projectile, playerPos, Quaternion.Euler(0f, facingRotation, 0f));

        GenericProjectile temp = projectile.GetComponent<GenericProjectile>();
        if (temp)
        {
            temp.Setup(playerFacingDirection);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Breakable"))
        {
            Destroy(this);
        }
    }
    
}

/*
 
     public IEnumerator AbilityCoroutine(float abilityDuration)
    {
        playerController.currentPlayerState = PlayerState.ability;
       // Vector2 temp = new Vector2(animator.GetFloat("OldHorizontalValue"),animator.GetFloat("OldVerticalValue"));
        //facingDirection = temp;

       // currentAbility.Ability(transform.position, facingDirection, playerController.PlayerRigidbody);

        yield return new WaitForSeconds(abilityDuration);
        playerController.currentPlayerState = PlayerState.idle;
    }
     */
