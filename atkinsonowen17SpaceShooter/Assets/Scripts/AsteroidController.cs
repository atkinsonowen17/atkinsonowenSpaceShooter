using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public GameObject Player;
    public float points;
    public float health;
    public float destroyX = -10f;    
    public float moveSpeed;
    private float rotationSpeed;        

    void Start()
    {
        rotationSpeed = Random.Range(-50f, 50f);
    }

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameController.instance.DamagePlayer(1);
            Destroy(gameObject);           
        }
    }

    public void DamageAsteroid(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameController.instance.AddScore(points);
            Destroy(gameObject);
        }

    }
}