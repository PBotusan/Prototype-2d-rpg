using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObjectsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// on trigger enter used to break objects.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Breakable"))
        {
            Debug.Log("BreakableObject");
        }
    }
}
