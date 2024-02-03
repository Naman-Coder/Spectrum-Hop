using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private int maxJumps = 1; // Max jumps excluding initial jump

    public int remainingJumps;
    private bool isGrounded;
    private float distToGround;

    public delegate void OutOfBounds();
    public static event OutOfBounds OnOutOfBounds;
    public delegate void TriggerPlatform();
    public static event TriggerPlatform OnTriggerPlatform;

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
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed * Time.deltaTime);
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
        if ((remainingJumps > 0) && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Reset vertical velocity
            
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            if (!isGrounded)
            {
                remainingJumps--;
            }
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.layer == 6)
            OnTriggerPlatform?.Invoke();
    
        if(other.CompareTag("Bounds")) 
            OnOutOfBounds?.Invoke(); // Trigger game over screen
    }
}

