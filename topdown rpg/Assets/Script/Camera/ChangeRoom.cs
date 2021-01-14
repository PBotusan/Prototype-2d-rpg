using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    [SerializeField] Vector2 changeCameraMinPos;
    [SerializeField] Vector2 changeCameraMaxPos;

    [SerializeField] Vector3 changePlayerPos;

    /// <summary>
    /// Current Camera used as CameraController, to change the position.
    /// </summary>
    private CameraDungeonController cam;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraDungeonController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cam.MinPosition += changeCameraMinPos;
            cam.MaxPosition += changeCameraMaxPos;

            Debug.Log("Player transistion");


            collision.transform.position += changePlayerPos;
        }
    }
}
