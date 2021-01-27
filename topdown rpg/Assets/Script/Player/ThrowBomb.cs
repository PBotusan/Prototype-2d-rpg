using System;
using UnityEngine;

public class ThrowBomb : MonoBehaviour
{
    /// <summary>
    /// Instantiate the bomb.
    /// </summary>
    [SerializeField] GameObject bomb;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        if (Input.GetButtonDown("ThrowBomb"))
        {
            InstantiateBomb();
        }
    }

    private void InstantiateBomb()
    {
        Instantiate(bomb.gameObject, transform.position, Quaternion.identity);
    }
}
