using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    GameManager gm;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            gm.health -= 5;
            gm.health = Mathf.Clamp(gm.health, 0, 100);
        }

       
    }
    
}
