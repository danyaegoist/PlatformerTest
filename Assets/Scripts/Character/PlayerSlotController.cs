using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ItemSlot))]
public class PlayerSlotController : MonoBehaviour
{
    public static ItemSlot currentActiveSlot;
    private  ItemSlot playerSlot;

    // Start is called before the first frame update
    void Start()
    {
        playerSlot = GetComponent<ItemSlot>();
    }    

    public void SwitchItems()
    {
        if (currentActiveSlot != null)
        {
            var temp = playerSlot.Get();
            playerSlot.Set(currentActiveSlot.Get());
            currentActiveSlot.Set(temp);
        }

    }
}
