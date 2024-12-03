using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public int coinAmount = 0;
    public int health = 100;

    public TextMeshProUGUI coinTest;
    public TextMeshProUGUI healthTest;
    public bool enemyAttack = false;

    public bool enemyDead = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (gm != null && gm != this)
        {
            Destroy(gameObject);
        }
        else
        {
            gm = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {
        coinTest.text = "Coins: " + coinAmount;
        healthTest.text = "Health: " + health;
    }

    private void Update()
    {
        coinTest.text = "Coins: " + coinAmount;   
        healthTest.text = "Health: " + health;
    }
}

   
    


