using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movemont : MonoBehaviour
{
   [SerializeField] private LandInputsubscription controllerInput;
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private Rigidbody2D rb;
    private bool isGrounded = true; 


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        if (controllerInput.JumpInput && isGrounded)
        {
            PerformJump();
        }
        if (controllerInput.LclickInput > 0.5f)
        {
            PerformAttack();
        }
    }
    void FixedUpdate()
    {
        Vector2 moveDirection = new Vector2(controllerInput.moveInput.x, controllerInput.moveInput.y);
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
    }
    void PerformJump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }


    void PerformAttack()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
