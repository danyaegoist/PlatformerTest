using UnityEngine;

public abstract class ItemBase : ScriptableObject
{
    public string Name;
    public Sprite Sprite;
    public abstract void Mount(SpriteRenderer renderer);
}