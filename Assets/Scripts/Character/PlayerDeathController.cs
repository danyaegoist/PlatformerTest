using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathController : MonoBehaviour
{
    [SerializeField] private Transform RespawnPoint;

    public void OnDeathTriggered()
    {
        transform.position = RespawnPoint.position;
    }
}
