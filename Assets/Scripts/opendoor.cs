using UnityEngine;

public class opendoor : MonoBehaviour
{
    GameManager gm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.enemyDead == true);
        {
            Destroy(gameObject);
        }
    }
}
