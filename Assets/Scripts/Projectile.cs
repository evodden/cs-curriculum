using UnityEngine;

public class Projectile : MonoBehaviour
{
    GameManager gm;
    public Vector3 target;
    private Vector3 direction;
    public float projectileSpeed = 20f;
    private float deathTime = 0.1f;

    public float lifeTime = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = (target - transform.position).normalized;
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * (projectileSpeed * Time.deltaTime);
    }

   
}
