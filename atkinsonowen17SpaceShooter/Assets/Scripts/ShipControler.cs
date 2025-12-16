using UnityEngine;

public class ShipController : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 8f;
    public float yLimit = 4f;
    public float fireDelay = 0.3f;
    public float lastFire;
    public GameObject fireballPrefab;
    public GameObject fireballPrefab2;
    public float bulletSpeed = 10f;
    public int level;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical"); 
        Vector3 movement = new Vector3(0f, vertical, 0f) * moveSpeed * Time.deltaTime;

        transform.position += movement;
        
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -yLimit, yLimit);
        transform.position = pos;

        if (Input.GetKeyDown("space") && Time.time > lastFire + fireDelay)
        {
            Shoot();
            lastFire = Time.time;  
        }
    }

    public void Shoot()
    {
        if (level == 3)
        {
            Vector3 spawnPos1 = transform.position + Vector3.right * 1.3F;
            Vector3 spawnPos2 = transform.position + Vector3.right * 1.3F + Vector3.up * 0.3f;
            Vector3 spawnPos3 = transform.position + Vector3.right * 1.3F + Vector3.up * -0.3f;

            GameObject fireball1 = Instantiate(fireballPrefab2, spawnPos1, transform.rotation);
            GameObject fireball2 = Instantiate(fireballPrefab, spawnPos2, transform.rotation * Quaternion.Euler(0, 0, 3));
            GameObject fireball3 = Instantiate(fireballPrefab, spawnPos3, transform.rotation * Quaternion.Euler(0, 0, -3));

            Destroy(fireball1, 1f);
            Destroy(fireball2, 1f);
            Destroy(fireball3, 1f);

            Vector2 upDirection = Quaternion.Euler(0, 0, 3) * Vector2.right;
            Vector2 downDirection = Quaternion.Euler(0, 0, -3) * Vector2.right;

            Rigidbody2D rb1 = fireball1.GetComponent<Rigidbody2D>();
            rb1.linearVelocity = -transform.up * bulletSpeed;
            Rigidbody2D rb2 = fireball2.GetComponent<Rigidbody2D>();
            rb2.linearVelocity = upDirection * bulletSpeed;
            Rigidbody2D rb3 = fireball3.GetComponent<Rigidbody2D>();
            rb3.linearVelocity = downDirection * bulletSpeed;
        }
        else if (level % 2 == 0) // Even levels use blue fireball
        { 

            Vector3 spawnPos = transform.position + Vector3.right * 1.3F;

            GameObject fireball = Instantiate(fireballPrefab2, spawnPos, transform.rotation);

            Destroy(fireball, 1f);

            Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
            rb.linearVelocity = -transform.up * bulletSpeed;
        }
        else // Odd levels use red fireball
        {
            {

            Vector3 spawnPos = transform.position + Vector3.right * 1.3F;

            GameObject fireball = Instantiate(fireballPrefab, spawnPos, transform.rotation);

            Destroy(fireball, 1f);

            Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
            rb.linearVelocity = -transform.up * bulletSpeed;
        }
        }
    }
}
