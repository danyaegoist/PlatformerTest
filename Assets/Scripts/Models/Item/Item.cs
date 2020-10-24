using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Platformer/Create Item")]
public class Item : ItemBase
{
    public override void Activate(Vector2 position, float direction, LayerMask targets) {}
    public override void Mount(SpriteRenderer renderer)
    {
        renderer.sprite = Sprite;
    }

    public override float GetReloadingSpeed()
    {
        return 0;
    }
}