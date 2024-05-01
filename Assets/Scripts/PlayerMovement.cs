using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;

    public float speed = 12f;
    public float gravity = -9.81f; 

    public Transform groundCheck; // A game object that is placed at the player's feet
    public float groundDistance = 0.4f; // Radius of the sphere that checks if the player is on the ground
    public LayerMask groundMask; // Ground layer
    private AudioSource footsteps;

    Vector3 velocity;
    bool isGrounded; // True if the player is on the ground

    // Start is called before the first frame update
    void Start()
    {
        footsteps = transform.Find("ControlledSFX/FootstepsSFX").GetComponent<AudioSource>();
        if (!footsteps){Debug.Log("Footsteps SFX not found");}
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // Checks if the player is on the ground

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal"); // x is the horizontal movement of the player
        float z = Input.GetAxis("Vertical"); // z is the vertical movement of the player

        Vector3 move = transform.right * x + transform.forward * z; // gets the direction the player is moving

        characterController.Move(speed * Time.deltaTime * move); // Moves the player in the direction they are facing

        velocity.y += gravity * Time.deltaTime; // Applies gravity to the player

        characterController.Move(velocity * Time.deltaTime); // Moves the player down

        if (move.magnitude > 0)
        {
            if (!footsteps.isPlaying)
            {footsteps.Play();}
        }
        else if (footsteps.isPlaying)
        {footsteps.Stop();}
    }
}
