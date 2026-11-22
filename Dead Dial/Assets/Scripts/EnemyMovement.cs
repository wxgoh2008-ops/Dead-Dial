using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 1.5f;
    public float chaseRange = 4f;
    public float wanderTime = 2f;

    private Rigidbody2D rb;
    private Vector2 wanderDirection;
    private float wanderTimer;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        PickNewDirection();
    }
    void FixedUpdate()
    {
        bool chasing = false;
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            chasing = distance <= chaseRange;
        }
        if (chasing)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * moveSpeed;
        }
        else
        {
            wanderTimer -= Time.fixedDeltaTime;
            if (wanderTimer <= 0f)
            {
                PickNewDirection();
            }
            rb.linearVelocity = wanderDirection * moveSpeed * 0.5f;
        }
        if (rb.linearVelocity.x > 0.01f)
        {
            sr.flipX = true;
        }
        else if (rb.linearVelocity.x < -0.01f)
        {
            sr.flipX = false;
        }
    }
    void PickNewDirection()
    {
        wanderDirection = Random.insideUnitCircle.normalized;
        wanderTimer = wanderTime;
    }
}