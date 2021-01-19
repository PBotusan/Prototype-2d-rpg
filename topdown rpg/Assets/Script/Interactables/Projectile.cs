using UnityEngine;

public class Projectile : MonoBehaviour
{
    /// <summary>
    /// How fast an projectile moves.
    /// </summary>
    [SerializeField] int speed;

    /// <summary>
    /// Moves projectile to the player direction.
    /// </summary>
    [SerializeField] Vector2 directionToMove;

    /// <summary>
    /// how long the projectile stays in the game.
    /// </summary>
    [SerializeField] float lifeTime;

    [SerializeField] Rigidbody2D projectileRigidbody;

    /// <summary>
    /// amount of seconds for lifetime.
    /// </summary>
    private float time;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        time = lifeTime;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        //timer used to destory gameobject
        time -= Time.deltaTime;
        if (time <= 0)
        {
            //Destroy(gameObject);
        }
    }


    internal void Launch(Vector2 initialVelocity)
    {
        // launch the projectile
        projectileRigidbody.velocity = initialVelocity * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
