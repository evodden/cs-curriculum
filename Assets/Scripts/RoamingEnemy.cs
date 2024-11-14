using UnityEngine;

public class RoamingEnemy : MonoBehaviour
{
    GameManager gm;
    public float roamSpeed = 2.0f;  
    public float chaseSpeed = 4.0f; 
    public float roamRange = 10.0f; 
    public float detectionRange = 8.0f;  
    public float changeDirectionTime = 3.0f;  
    public int enemyDamage = 10;  
    public float attackCooldown = 1.0f;  
    
    private Vector2 roamOrigin;  // The starting position for roaming
    private Vector2 direction;  // The current direction the enemy is moving in while roaming
    private float changeDirectionTimer;  
    private Transform player;  
    private bool canAttack = true;
    private bool isChasing = false;
    void Start()
    {
        roamOrigin = transform.position;

        direction = GetRandomDirection();

        changeDirectionTimer = changeDirectionTime;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        gm = FindObjectOfType<GameManager>();
    }
    

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRange)
        {
            isChasing = true;
            ChasePlayer();
        }
        else
        {
            isChasing = false;
            Roam();
        }
    }

    void ChasePlayer()
    {
        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        transform.Translate(directionToPlayer * (chaseSpeed * Time.deltaTime));
    }

    void Roam()
    {
        if (!isChasing)
        {
            transform.Translate(direction * (roamSpeed * Time.deltaTime));

            
            changeDirectionTimer -= Time.deltaTime;

            if (changeDirectionTimer <= 0)
            {
                direction = GetRandomDirection();
                changeDirectionTimer = changeDirectionTime;
            }
        }
    }

  
    Vector2 GetRandomDirection()
    {
        float randomAngle = Random.Range(0, 2 * Mathf.PI);
        return new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && canAttack)
        {
            AttackPlayer(other.gameObject);
        }
    }
    
    void AttackPlayer(GameObject Player)
    {
        if (gm != null)
        {
            gm.health -= enemyDamage;
            gm.enemyAttack = true;
            canAttack = false;
            Invoke(nameof(ResetAttack), attackCooldown);  
        }
        
    }
    
    void ResetAttack()
    {
        canAttack = true;
        gm.enemyAttack = false;
    }
    
}


