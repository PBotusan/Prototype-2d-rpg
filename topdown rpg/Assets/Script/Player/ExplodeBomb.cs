using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBomb : MonoBehaviour
{
    [SerializeField] GameObject explosionSprite;

    /// <summary>
    /// Amount of time used to explode.
    /// </summary>
    private float time = 3;

    /// <summary>
    /// Amount of damage.
    /// </summary>
    private float damage;


    private void Start()
    {
       //animator
       //sound
       //rigidbody if you want to poush
       //maybe triggers if you hit it explodes

    }

    private void Update()
    {
        ExplodeTheBomb();
       
    }

    private void ExplodeTheBomb()
    {
        StartCoroutine(ExplodeCoroutine());
    }

    private IEnumerator ExplodeCoroutine()
    {
        yield return new WaitForSeconds(time);
        Explode();
    }

    /// <summary>
    /// Explodes bomb, also used when you hit the bomb with your sword. instant explosion with-out counter.
    /// </summary>
    internal void Explode()
    {
        explosionSprite.SetActive(true);
        //after some time destroy object.
        Destroy(gameObject, 1);
    }
}
