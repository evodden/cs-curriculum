using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public int coinAmount;

    public int health;
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



}
