using UnityEngine;

public class ShipController : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 8f;
    public float yLimit = 3.5f;
    public float fireDelay = 0.3f;
    public float lastFire;
    public GameObject fireballPrefab;
    public GameObject fireballPrefab2;
    public float bulletSpeed = 10f;

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
        Debug.Log("shoot");

        Vector3 spawnPos = transform.position + Vector3.right * 1.3F;

        GameObject fireball = Instantiate(fireballPrefab, spawnPos, transform.rotation);

        Destroy(fireball, 1f);

        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        rb.linearVelocity = -transform.up * bulletSpeed;
    }
}
