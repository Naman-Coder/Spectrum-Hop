using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    private int maxJumps = 1; // Max jumps excluding initial jump
    private int remainingJumps;
    private float speed = 1.25f;
    private float jumpForce = 5f; 
    private bool isGrounded;
    private float distToGround;

    void Start ()
    {
        remainingJumps = maxJumps;
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    private void FixedUpdate() 
    {
        ForwardMovement();
    }

    private void Update() {
        Jump();
        GroundCheck();
    }

    private void ForwardMovement() 
    {
        Vector3 forwardMovement = transform.forward * speed * Time.deltaTime;
        rb.MovePosition(rb.position + forwardMovement);
    }
    
    private void GroundCheck()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f);
        if (isGrounded)
        {
            remainingJumps = maxJumps;
        }
    }

    private void Jump()
    {
        if ((isGrounded || remainingJumps > 0) && Input.GetButtonDown("Jump"))
        {
            Debug.Log(isGrounded);
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Reset vertical velocity
            
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            if (!isGrounded)
            {
                remainingJumps--;
            }
    }
}
}







