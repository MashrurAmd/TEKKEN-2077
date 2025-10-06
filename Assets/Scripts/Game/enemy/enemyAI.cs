using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    public float detectionRange = 3f;
    public float attackCooldown = 2f;  // time between attacks
    private float nextAttackTime = 0f;

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        // Face the player
        if (distance < detectionRange)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            direction.y = 0;
            transform.rotation = Quaternion.LookRotation(direction);

            // Attack if cooldown finished
            if (Time.time >= nextAttackTime)
            {
                animator.SetTrigger("attack");
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }
}
