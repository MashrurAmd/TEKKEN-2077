using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;

    [Header("Hit Reactions")]
    public float kickForce = 1f;
    public float punchForce = 0.5f; // smaller push for punches

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Called from triggers
    public void TakeDamage(string hitType = "Kick")
    {
        if (animator == null) return;

        if (hitType == "Kick")
        {
            animator.SetTrigger("damage"); // Kick damage animation
            if (rb != null)
                rb.AddForce(Vector3.forward * kickForce, ForceMode.Impulse);
        }
        else if (hitType == "Punch")
        {
            animator.SetTrigger("fist_damage"); // Punch damage animation
            if (rb != null)
                rb.AddForce(Vector3.forward * punchForce, ForceMode.Impulse);
        }

        Debug.Log($"💥 Enemy took {hitType} damage!");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Optional fallback for any direct collision
        if (other.CompareTag("feet"))
        {
            TakeDamage("Kick");
        }
        else if (other.CompareTag("hand"))
        {
            TakeDamage("Punch");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (animator != null)
        {
            animator.ResetTrigger("damage");
            animator.ResetTrigger("fist_damage");
        }
    }
}
