using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private float Speed = 4.0f;
    [SerializeField] private float JumpForce = 1.0f;
    [SerializeField] private float AdditionalJumpTime = 0.3f;
    [SerializeField] private float LastChanceJumpTime = 0.4f;
    [SerializeField] private LayerMask WhatIsFloor;

    private Rigidbody2D rb;
    private float HorizontalDelta;
    private float VerticalDelta;
    private bool IsGrounded;
    private bool IsJumping;
    private bool IsJumpContinue = false;
    private float AdditionalJumpTimer;
    private float LastChanceJumpTimer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        CheckNormalGravity();
        CheckZeroGravity();
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
        if (rb.gravityScale == 0) return;

            if (!IsGrounded)
            LastChanceJumpTimer -= Time.deltaTime;
        else
            LastChanceJumpTimer = LastChanceJumpTime;

        if (pressed && IsJumpContinue && (IsGrounded && !IsJumping || (!IsGrounded && !IsJumping && LastChanceJumpTimer > 0)))
        {
            LastChanceJumpTimer = -1;
            IsJumping = true;
            AdditionalJumpTimer = AdditionalJumpTime;
            rb.velocity = Vector2.up * JumpForce;
        }

        if (IsJumpContinue && IsJumping)
        {
            if (AdditionalJumpTimer > 0)
                PerformAdditionalJump();
            else
                StopJumping();
        }


        if (released)
            StopJumping();
    }

    private void StopJumping()
    {
        IsJumping = false;
        AdditionalJumpTimer = -1;
        LastChanceJumpTimer = -1;
    }

    public void OnJumpStarted()
    {
        IsJumpContinue = true;
        PerformJump(true);
    }

    public void OnJumpStopped()
    {
        IsJumpContinue = false;
        PerformJump(false, true);
    }

    private void PerformAdditionalJump()
    {
        rb.velocity = Vector2.up * JumpForce;
        AdditionalJumpTimer -= Time.deltaTime;
    }

    private void CheckNormalGravity()
    {
        if (rb.gravityScale != 0)
            rb.velocity = new Vector2(HorizontalDelta * Speed, rb.velocity.y);
    }

    private void CheckZeroGravity()
    {
        if (rb.gravityScale == 0)
        {
            rb.velocity = new Vector2();
            rb.MovePosition(new Vector2(transform.position.x + HorizontalDelta * Speed * Time.fixedDeltaTime, transform.position.y + VerticalDelta * Speed * Time.fixedDeltaTime));
        }
    }

    private void CheckGround()
    {
        IsGrounded = Physics2D.OverlapCircle(transform.position, 0.7458081f, WhatIsFloor);
    }
}
