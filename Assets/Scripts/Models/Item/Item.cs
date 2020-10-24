using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Platformer/Create Item")]
public class Item : ItemBase
{
    public override void Mount(SpriteRenderer renderer)
    {
        renderer.sprite = Sprite;
    }
}