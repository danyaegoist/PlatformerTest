using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    private PlayerMotor Motor;

    private void Awake()
    {
        Motor = GetComponent<PlayerMotor>();
    }

    private void FixedUpdate()
    {
        Motor.SetMovement(StickController.Horizontal(), StickController.Vertical());
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
            Motor.OnJumpStarted();

        if (Input.GetButtonUp("Jump"))
            Motor.OnJumpStopped();
    }
}
