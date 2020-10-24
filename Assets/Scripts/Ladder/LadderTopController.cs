using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlatformEffector2D))]
public class LadderTopController : MonoBehaviour
{
    private PlatformEffector2D Effector;

    private void Start()
    {
        Effector = GetComponent<PlatformEffector2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
       if(collision.tag == "Player")
            Effector.rotationalOffset = StickController.Vertical() < 0 ? 180f : 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Effector.rotationalOffset = 0;
    }
}
