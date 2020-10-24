using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ItemSlot))]
public class PlayerInteractableController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer ItemMount;
    private ItemSlot slot;
    private InteractablePerformer performer;

    private void Start()
    {
        slot = GetComponent<ItemSlot>();
        slot.SlotItemChanged += ReinitItem;
        ReinitItem(slot.Get());
    }

    private void ReinitItem(ItemBase current)
    {
        if (current != null)
        {
            performer = new InteractablePerformer(current);
            performer.Mount(ItemMount);
        }
        else
        {
            if (performer != null)
            {
                performer = null;
            }
            ItemMount.sprite = null;
        }
    }
}
