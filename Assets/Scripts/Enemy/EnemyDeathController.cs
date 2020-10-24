using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthController))]
public class EnemyDeathController : MonoBehaviour
{
    public void OnDeathTriggered()
    {
        GetComponent<HealthController>().ResetHealth();
    }
}
