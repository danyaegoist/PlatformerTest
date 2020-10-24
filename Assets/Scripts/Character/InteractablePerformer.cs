using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractablePerformer
{
    ItemBase Item;

    public InteractablePerformer(ItemBase item)
    {
        Item = item;
    }

    public void Mount(SpriteRenderer renderer)
    {
        Item?.Mount(renderer);
    }
}