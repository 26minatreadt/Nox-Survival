using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 120.0f;
    private Animator animator;

    private void Start()
    {
        // Initialize the animator component for character animations.
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Player movement input
        float verticalInput = Input.GetAxis("Horizontal");
        float horizontalInput = Input.GetAxis("Vertical");
        // Calculate the movement direction based on input
        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        moveDirection.Normalize();

        // // Rotate the character towards the movement direction
        // if (moveDirection != Vector3.zero)
        // {
        //     Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        //     transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        // }

        // Move the character
        Vector3 moveAmount = moveDirection * moveSpeed * Time.deltaTime;
        transform.Translate(moveAmount);

        // Update animation parameters
        animator.SetFloat("Speed", moveAmount.magnitude);

        // Add code for jumping, attacking, and other actions as needed.
    }
}