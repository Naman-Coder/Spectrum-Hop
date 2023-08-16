using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    private float speed = 1.25f;
    private float jumpForce = 5f; 
    private float raycastDistance = 1f;
    private bool isGrounded;
    private bool pressedEnter;

    private void FixedUpdate() 
    {
        ForwardMovement();
        GroundCheck();
    }

    private void Update() {
        Jump();
    }

    private void ForwardMovement() 
    {
        if(Input.GetKeyDown(KeyCode.Return))
            pressedEnter = true;
        if(pressedEnter) {
            Vector3 forwardMovement = transform.forward * speed * Time.deltaTime;
            rb.MovePosition(rb.position + forwardMovement);
        }
    }
    
    private void GroundCheck()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, raycastDistance);
    }

    private void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}







