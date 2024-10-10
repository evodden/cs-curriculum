using UnityEngine;

public class Turret : MonoBehaviour
{
    
    public GameObject Projectile;

    private float Firerate = 2;
    private float cooldown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && cooldown < 0)
        {
            GameObject clone = Instantiate(Projectile, transform.position, Quaternion.identity);
            Projectile script = clone.GetComponent<Projectile>();
            script.target = other.gameObject.transform.position;
            cooldown = Firerate;
        }
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
    }
}
