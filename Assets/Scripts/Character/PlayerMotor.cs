using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private float Speed = 4.0f;
    [SerializeField] private float JumpForce = 1.0f;
    [SerializeField] private LayerMask WhatIsFloor;

    private Rigidbody2D rb;
    private float HorizontalDelta;
    private float VerticalDelta;
    private bool IsGrounded;
    private bool IsJumping;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (rb.gravityScale == 0)
        {
            rb.velocity = new Vector2();
            rb.MovePosition(new Vector2(transform.position.x + HorizontalDelta * Speed * Time.fixedDeltaTime, transform.position.y + VerticalDelta * Speed * Time.fixedDeltaTime));
        }
        else
            rb.velocity = new Vector2(HorizontalDelta * Speed, rb.velocity.y);
    }

    private void Update()
    {
        CheckGround();
        PerformJump();
    }

    public void SetMovement(float horizontal, float vertical)
    {
        HorizontalDelta = horizontal;
        VerticalDelta = vertical;
    }

    private void PerformJump(bool pressed = false, bool released = false)
    {
        if (pressed && IsGrounded && !IsJumping)
        {
            IsJumping = true;
            rb.velocity = Vector2.up * JumpForce;
        }

        if (released)
            StopJumping();
    }

    private void StopJumping()
    {
        IsJumping = false;
    }

    public void OnJumpStarted()
    {
        PerformJump(true);
    }

    public void OnJumpStopped()
    {
        PerformJump(false, true);
    }

    private void CheckGround()
    {
        IsGrounded = Physics2D.OverlapCircle(transform.position, 0.7458081f, WhatIsFloor);
    }
}
