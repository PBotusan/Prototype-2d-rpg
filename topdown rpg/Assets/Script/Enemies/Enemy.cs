using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Transform target;

    [SerializeField]float health = 10;

    [SerializeField]float movementSpeed = 3.5f;

    [SerializeField] float followDistance = 8;

    [SerializeField] float attackDistance = 0.25f;


    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CalculateDistance();
    }

    private void CalculateDistance()
    {
        var calculateDistance = Vector3.Distance(target.position, transform.position);

        if (calculateDistance <= followDistance && calculateDistance >= attackDistance)
        {
            FollowPlayer();
        }
        else
        {
            //todo states
        }
    }

    protected virtual void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
    }
}
