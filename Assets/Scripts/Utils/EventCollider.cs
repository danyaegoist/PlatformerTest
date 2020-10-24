﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventCollider : MonoBehaviour
{
    [SerializeField] private UnityEvent Event;
    [SerializeField] private LayerMask Targets;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utils.IsInLayerMask(collision.gameObject.layer, Targets))
            Event?.Invoke();
    }

    
}
