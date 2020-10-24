using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float Damage = 0;
    public LayerMask Targets;
    private float LifeTimer = 10;

    private void Update()
    {
        LifeTimer -= Time.deltaTime;
        if (LifeTimer < 0)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utils.IsInLayerMask(collision.gameObject.layer, Targets))
        {
            collision.gameObject.GetComponent<HealthController>().Hit(Damage);
            Destroy(this.gameObject);
        }
    }
}
