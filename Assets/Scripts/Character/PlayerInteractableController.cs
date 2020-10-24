using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ItemSlot))]
public class PlayerInteractableController : MonoBehaviour
{
    [SerializeField] private LayerMask Targets;
    [SerializeField] private SpriteRenderer ItemMount;
    [SerializeField] private Text ItemText;
    private ItemSlot slot;
    private InteractablePerformer performer;

    private void Start()
    {
        slot = GetComponent<ItemSlot>();
        slot.SlotItemChanged += ReinitItem;
        ReinitItem(slot.Get());
    }

    private void Update()
    {
        performer?.Update();

        if (Input.GetKeyDown(KeyCode.LeftControl))
            PerformAttack();
    }

    private void ReinitItem(ItemBase current)
    {
        if (current != null)
        {
            performer = new InteractablePerformer(current);
            performer.OnItemEnded += OnItemEnded;
            performer.OnItemChanged += OnItemChanged;
            performer.Reset();
            performer.Mount(ItemMount);
        }
        else
        {
            if (performer != null)
            {
                performer.Destroy();
                performer = null;
            }
            ItemMount.sprite = null;
            OnItemChanged();
        }
    }

    private void OnItemChanged()
    {
        ItemBase item = slot.Get();
        if(item != null)
            ItemText.text = string.Format("Current item: {0} ({1}/{2})", item.name, performer.Count, item.Count);
        else
            ItemText.text = "Current item: none";
    }

    private void OnItemEnded()
    {
        slot.Set(null);
    }

    public void PerformAttack ()
    {
        performer?.Activate(ItemMount.gameObject.transform.position, transform.localScale.x, Targets);
    }
}
