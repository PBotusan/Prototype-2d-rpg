using UnityEngine;

public class FireArrow : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D arrowRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        arrowRigidbody2D = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Setup the arrow for direction and speed.
    /// </summary>
    /// <param name="velocity"> is the speed for the arrow</param>
    /// <param name="direction"> the direction of the player is facing, used to fire the arrow in the correct direction</param>
    internal void Setup(Vector2 velocity, Vector3 direction)
    {
        //translate the arrow.
        arrowRigidbody2D.velocity = velocity.normalized * speed; 
        //turn arrow in correct position to face the players direction.
        transform.rotation = Quaternion.Euler(direction);
        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Breakable"))
        {
            Destroy(gameObject);
        }
    }
}
