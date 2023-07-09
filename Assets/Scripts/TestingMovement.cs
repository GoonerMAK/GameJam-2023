using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 1f;
    private float jumpingPower = 4f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public Animator animator;
    private bool isAttacking = false;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        vertical = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            animator.SetBool("IsJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        else if (IsGrounded())
        {
            animator.SetBool("IsJumping", false);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)        // Moving in air
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.2f);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isAttacking)
            {
                animator.SetTrigger("Attacking");
                isAttacking = true;
            }
            else
            {
                animator.ResetTrigger("Attacking");
                animator.SetTrigger("Attacking");
            }
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
