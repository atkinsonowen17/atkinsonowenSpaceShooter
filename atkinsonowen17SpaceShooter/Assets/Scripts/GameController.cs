using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{   
    public GameObject player;
    public static GameController instance;
    private static float health = 3f;
    public static float Health { get => health; set => health = value; }
    public float score = 0f;
    public TextMeshProUGUI scoreText;
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
        UpdateScoreUI();
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

    public void AddScore(float points)
    {
        score += points;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}
