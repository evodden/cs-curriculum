using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    GameManager gm;
    float health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        gm.health = 100;
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            gm.health -= 10;
            print("You have " + gm.health + " health left.");
        }
    }
}
