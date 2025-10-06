using System.Collections;
using UnityEngine;
using UnityEngine.UI; // For Button

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public CharacterController controller;

    [Header("Movement Settings")]
    public float moveSpeed = 3f;
    public float zMin = 0f;
    public float zMax = 15f;

    [Header("UI Controls")]
    public Joystick joystick; // assign your joystick prefab here
    public Button kickButton; // assign your kick button here
    public Button punchButton; // assign your punch button here (new)

    public FootTrigger leftFootTrigger;   // assign in Inspector
    public FootTrigger rightFootTrigger;  // optional second foot

    public GameObject KickBox; // assign kick hitbox here
    public bool isKicking = false;

    public GameObject PunchBox; // assign punch hitbox here
    public bool isPunching = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator.applyRootMotion = false; // disable animation moving character

        // Assign kick button listener
        if (kickButton != null)
            kickButton.onClick.AddListener(Kick);

        // Assign punch button listener
        if (punchButton != null)
            punchButton.onClick.AddListener(Punch);
    }

    void Update()
    {


        if (leftFootTrigger != null && leftFootTrigger.hasTriggered)
        {
            Debug.Log("Player left foot is colliding with enemy!");
        }

        if (rightFootTrigger != null && rightFootTrigger.hasTriggered)
        {
            Debug.Log("Player right foot is colliding with enemy!");
        }


        Vector3 move = Vector3.zero;

        // Horizontal input from joystick (-1 left, 1 right)
        float horizontal = joystick != null ? joystick.Horizontal : 0f;

        if (Mathf.Abs(horizontal) > 0.1f) // deadzone
        {
            // Move along Z-axis based on horizontal input
            move = Vector3.forward * horizontal * moveSpeed * Time.deltaTime;

            animator.SetBool("isWalking", true);

            // Flip character to face movement direction
            if (horizontal > 0)
                transform.rotation = Quaternion.Euler(0, 0, 0);   // forward
            else
                transform.rotation = Quaternion.Euler(0, 180, 0); // backward
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        // Apply movement
        controller.Move(move);

        // Clamp Z position
        Vector3 clampedPos = transform.position;
        clampedPos.z = Mathf.Clamp(clampedPos.z, zMin, zMax);
        transform.position = clampedPos;

        // Kick via Space key (optional)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Kick();
        }

        else 

        // Punch via P key (optional)
        if (Input.GetKeyDown(KeyCode.P))
        {
            Punch();
        }
    }

    // Called by kick button or Space key
    public void Kick()
    {
        if (!isKicking)
        {
            isKicking = true;
            KickBox.GetComponent<Collider>().enabled = true; // Enable hitbox
            animator.SetTrigger("Kick");
            StartCoroutine(ResetKick());
        }
       

    }

    private IEnumerator ResetKick()
    {
        yield return new WaitForSeconds(0.5f); // assuming kick animation is 0.5s
        isKicking = false;
        KickBox.GetComponent<Collider>().enabled = false; // Disable hitbox
        animator.ResetTrigger("Kick");
    }

    // Called by punch button or P key


    public void Punch()
    {
        if (!isPunching)
        {
            isPunching = true;
            PunchBox.GetComponent<Collider>().enabled = true; // Enable punch hitbox
            animator.SetTrigger("punch");
            StartCoroutine(ResetPunch());
        }
    }

    private IEnumerator ResetPunch()
    {
        yield return new WaitForSeconds(0.5f); // adjust based on punch animation length
        isPunching = false;
        PunchBox.GetComponent<Collider>().enabled = false; // Disable hitbox
        animator.ResetTrigger("punch");
    }



}
