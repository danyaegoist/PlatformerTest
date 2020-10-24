using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractablePerformer
{
    public UnityAction OnItemEnded;
    public UnityAction OnItemChanged;
    public int Count { get; private set; }
    private float LastActivateTimer;
    ItemBase Item;

    public InteractablePerformer(ItemBase item)
    {
        Item = item;
    }

    public void Activate(Vector2 position, float direction, LayerMask targets)
    {
        if (LastActivateTimer < Item.GetReloadingSpeed()) return;

        if(Item != null)
        {
            Item.Activate(position, direction, targets);
            LastActivateTimer = 0;

            Count--;

            if (Count == 0)
            {
                if(Item.DestroyWhenEmpty)
                    OnItemEnded?.Invoke();
                else
                    Count = Item.Count;
            }

            OnItemChanged?.Invoke();
        }
    }

    public void Mount(SpriteRenderer renderer)
    {
        Item?.Mount(renderer);
    }

    public void Reset()
    {
        LastActivateTimer = Item.GetReloadingSpeed();
        Count = Item.Count;
        OnItemChanged?.Invoke();
    }

    public void Update()
    {
        if (LastActivateTimer < Item?.GetReloadingSpeed())
            LastActivateTimer += Time.deltaTime;
    }

    public void Destroy()
    {
        Item = null;
    }
}