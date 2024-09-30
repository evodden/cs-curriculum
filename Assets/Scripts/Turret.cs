using UnityEngine;

public class Turret : MonoBehaviour
{
    private GameObject Target;
    private GameObject Projectile;

    private float Firerate = 2;
    private float cooldown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && cooldown < 0)
        {
            GameObject clone = Instantiate(Projectile);
            Projectile clonescript = clone.GetComponent+<Projectile>();
            clonescript.target = other.transform.position;
            cooldown = Firerate;
        }
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
    }
}
