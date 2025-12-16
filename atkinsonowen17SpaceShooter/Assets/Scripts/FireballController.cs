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
}
