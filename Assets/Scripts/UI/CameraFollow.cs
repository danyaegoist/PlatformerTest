using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private Vector2 Threshold = new Vector2();
    [SerializeField] private float SmoothSpeed = 0.125f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Target == null) return;

        float differenceX = Vector2.Distance(transform.position * Vector2.right, Target.position * Vector2.right);
        float differenceY = Vector2.Distance(transform.position * Vector2.up, Target.position * Vector2.up);

        Vector3 newPosition = transform.position;

        if (Mathf.Abs(differenceX) > Threshold.x)
            newPosition.x = Target.position.x;

        if (Mathf.Abs(differenceY) > Threshold.y)
            newPosition.y = Target.position.y;

        Vector3 velocity = new Vector3();
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, SmoothSpeed);
    }
}
