using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GenericProjectile : MonoBehaviour
{
    [SerializeField] Rigidbody2D projectileRigidbody;
    [SerializeField] float projectileSpeed;
    



    // Start is called before the first frame update
    void Start()
    {
        projectileRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Setup(Vector2 moveDirection)
    {
        projectileRigidbody.velocity = moveDirection.normalized * projectileSpeed;
    }
}
