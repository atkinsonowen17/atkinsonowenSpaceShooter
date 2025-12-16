using UnityEngine;

public class FireballController : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 0.7f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            AsteroidController asteroid = collision.GetComponent<AsteroidController>();
            if (asteroid != null)
            {
                asteroid.DamageAsteroid(1f);
            }
            Destroy(gameObject);           // destroy bullet
        }
    }
}
