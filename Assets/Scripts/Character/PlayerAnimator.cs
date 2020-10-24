using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Rigidbody2D RigidBody;
    private Animator Animator;

    private void Awake()
    {
        RigidBody = GetComponentInChildren<Rigidbody2D>();
        Animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        CheckAnimationState();
        CheckRotation();
    }

    private void CheckAnimationState()
    {
        if (Mathf.Abs(RigidBody.velocity.y) > 0.9)
            Animator.SetInteger("State", RigidBody.velocity.y > 0 ? 2 : 3);
        else if (Mathf.Abs(RigidBody.velocity.x) > 0.3)
            Animator.SetInteger("State", 1);
        else
            Animator.SetInteger("State", 0);
    }

    private void CheckRotation()
    {
        if (StickController.Horizontal() != 0)
            transform.localScale = new Vector3(StickController.Horizontal() < 0 ? -1 : 1, transform.localScale.y, transform.localScale.z);
    }
}
