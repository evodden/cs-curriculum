using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    GameManager gm;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [System.Obsolete]
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            gm.coinAmount += 1;
            Destroy(other.gameObject);
            
        }
    }
}
