using UnityEngine;

public class GameController : MonoBehaviour
{   
    public GameObject player;
    public static GameController instance;
    private static float health = 3f;
    public static float Health { get => health; set => health = value; }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void Update()
    {
        
    }

    public void DamagePlayer(float damage)
    {
        health -= damage;
        if (Health <= 0)
        {
            // KillPlayer();
        }

    }
}
