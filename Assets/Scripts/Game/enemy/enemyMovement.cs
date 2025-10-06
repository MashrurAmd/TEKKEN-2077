using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;

    public float kickForce = 1f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage()
    {
        if (animator != null)
        {
            animator.SetTrigger("damage");
            Debug.Log("💥 Enemy took damage!");
        }
        else
        {
            animator.ResetTrigger("damage");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("feet"))
        {
            animator.SetTrigger("damage");
            this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * kickForce, ForceMode.Impulse);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        animator.ResetTrigger("damage");
    }
}
