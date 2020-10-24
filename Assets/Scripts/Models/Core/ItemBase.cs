using UnityEngine;

public abstract class ItemBase : ScriptableObject
{
    public string Name;
    public Sprite Sprite;
    public int Count;
    public bool DestroyWhenEmpty;

    public abstract void Activate(Vector2 position, float direction, LayerMask targets);
    public abstract void Mount(SpriteRenderer renderer);
    public abstract float GetReloadingSpeed();
}