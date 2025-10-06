using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    public float detectionRange = 3f;
    public float attackCooldown = 2f;  // Time between attacks
    private float nextAttackTime = 0f;

    private bool isPlayerInRange = false;

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        // Check if player is within detection range
        if (distance <= detectionRange)
        {
            if (!isPlayerInRange)
            {
                isPlayerInRange = true;
                animator.SetBool("isAttacking", true); // Optional, if you use a bool for looping attack
            }

            // Face the player
            Vector3 direction = (player.position - transform.position).normalized;
            direction.y = 0;
            //transform.rotation = Quaternion.LookRotation(direction);

            // Attack if cooldown finished
            if (Time.time >= nextAttackTime)
            {
                animator.SetTrigger("attack");
                nextAttackTime = Time.time + attackCooldown;
            }
        }
        else
        {
            // Player moved away — stop attacking
            if (isPlayerInRange)
            {
                isPlayerInRange = false;
                animator.SetBool("isAttacking", false); // Optional, helps transition back to idle
            }
        }
    }
}
