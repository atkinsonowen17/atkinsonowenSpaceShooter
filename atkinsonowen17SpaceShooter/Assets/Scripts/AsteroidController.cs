using UnityEngine;

public class AsteriodController : MonoBehaviour
{
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
}