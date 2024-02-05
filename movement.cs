using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the character movement
    public float jumpForce = 10f; // Force applied when jumping
    private Rigidbody rb;
    private bool isGrounded;
    private Vector3 originalVelocity;

    public bool inTriggerZone = false;
    public float loweredSpeedMultiplier = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalVelocity = rb.velocity;
    }

    void Update()
    {
        
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        if (!inTriggerZone)
        {
            // Normal movement speed
            rb.velocity = moveDirection * moveSpeed;
        }
        else
        {
            // Reduced movement speed while in the trigger zone
            rb.velocity = moveDirection * moveSpeed * loweredSpeedMultiplier;
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("water"))
        {
            inTriggerZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("water"))
        {
            // Restore original speed when leaving the trigger zone
            rb.velocity = originalVelocity;
            inTriggerZone = false;
        }
    }
      private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
