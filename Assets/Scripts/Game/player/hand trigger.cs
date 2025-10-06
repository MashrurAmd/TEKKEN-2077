using UnityEngine;

public class HandTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("👊 Punch hit Enemy!");

            Animator playerAnimator = GetComponentInParent<Animator>();
            if (playerAnimator != null && playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("punch"))
            {
                EnemyController enemy = other.GetComponent<EnemyController>();
                if (enemy != null)
                {
                    enemy.TakeDamage("Punch");
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("❌ Punch stopped hitting Enemy!");
        }
    }
}
