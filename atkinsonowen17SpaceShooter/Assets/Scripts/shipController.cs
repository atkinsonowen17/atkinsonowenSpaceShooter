using UnityEngine;

public class shipController : MonoBehaviour
{
    
    public float moveSpeed = 8f;
    public float yLimit = 3.5f;

    // void Start()
    // {
        
    // }

    // void Update()
    // {
    //     float vertical = Input.GetAxisRaw("Vertical"); 
    //     Vector3 movement = new Vector3(0f, vertical, 0f) * moveSpeed * Time.deltaTime;

    //     transform.position += movement;
        
    //     Vector3 pos = transform.position;
    //     pos.y = Mathf.Clamp(pos.y, -yLimit, yLimit);
    //     transform.position = pos;
    // }
}
