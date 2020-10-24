using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private ItemBase Slot;
    public delegate void SlotItemChangedDelegate(ItemBase current);
    public event SlotItemChangedDelegate SlotItemChanged;

    private void Start()
    {

    }

    public void Set(ItemBase i)
    {
        Slot = i;
        SlotItemChanged?.Invoke(Slot);
    }

    public ItemBase Get()
    {
        return Slot;
    }
}
