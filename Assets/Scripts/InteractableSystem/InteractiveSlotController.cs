using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveSlotController : MonoBehaviour
{
    [SerializeField] private GameObject Pointer;
    [SerializeField] private LayerMask Targets;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utils.IsInLayerMask(collision.gameObject.layer, Targets))
        {
            PlayerSlotController.currentActiveSlot = GetComponent<ItemSlot>();
            Pointer.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Utils.IsInLayerMask(collision.gameObject.layer, Targets))
        {
            PlayerSlotController.currentActiveSlot = null;
            Pointer.SetActive(false);
        }
    }
}
