using UnityEngine;

public class ShipController : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 8f;
    public float yLimit = 3.5f;
    public float fireDelay = 0.3f;
    public float lastFire;

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
    }
}
