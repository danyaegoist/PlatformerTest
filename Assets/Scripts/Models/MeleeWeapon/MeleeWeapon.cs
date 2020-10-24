using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Platformer/Create Melee Weapon")]
public class MeleeWeapon : ItemBase
{
    public float AttackSpeed;
    public float AttackAmount;

    public override void Activate(Vector2 position, float direction, LayerMask targets)
    {
        var collide = Physics2D.OverlapCircle(position, 0.7458081f, targets);
        if (collide != null)
        {
            collide.GetComponent<HealthController>().Hit(AttackAmount);
        }
    }

    public override float GetReloadingSpeed()
    {
        return AttackSpeed;
    }

    public override void Mount(SpriteRenderer renderer)
    {
        renderer.sprite = Sprite;
    }
}
