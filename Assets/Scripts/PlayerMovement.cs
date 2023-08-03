using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public bool canSprint = false;
    public float sprintMultiplier = 1.5f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    
    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // Applying the movement and checking if sprinting
        if(canSprint && Input.GetKey("left shift"))
        {
            characterController.Move((move * speed * Time.deltaTime) * sprintMultiplier);
        }
        else
        {
            characterController.Move(move * speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        // Cap the vertical velocity so that the player doesn't go flying downwards
        if(velocity.y < -100) 
        {
            velocity.y = -100;
        }

        characterController.Move(velocity * Time.deltaTime);
    }
}