using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Platformer/Create Consumable Item")]
public class Consumable : ItemBase
{
    public override void Activate(Vector2 position, float direction, LayerMask targets) {}
    public override float GetReloadingSpeed() { return 0; }
    public override void Mount(SpriteRenderer renderer) { renderer.sprite = Sprite; }
}
