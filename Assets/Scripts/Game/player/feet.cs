using UnityEngine;

public class FootTrigger : MonoBehaviour
{
    public bool hasTriggered { get; private set; } = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            hasTriggered = true;
            Debug.Log("✅ Foot started hitting Enemy!");

            // Check if player is kicking and apply damage
            Animator playerAnimator = GetComponentInParent<Animator>();
            if (playerAnimator != null && playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Kick"))
            {
                EnemyController enemy = other.GetComponent<EnemyController>();
                if (enemy != null)
                {
                    enemy.TakeDamage();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            hasTriggered = false;
            Debug.Log("❌ Foot stopped hitting Enemy!");
        }
    }
}
