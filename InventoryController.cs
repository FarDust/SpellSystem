using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    public Inventory inventory;

    public void PickUp(Item item) {
        inventory.AddItem(item);
    }

    public void assignSlot(int slot, Item item) {
        if (slot < inventory.usableSlot.Count && item is ConsumableItem) {
            inventory.usableSlot[slot] = item;
        }
    }

    public void useSlot(int slot, ConsumableItem item)
    {
        if (slot < inventory.usableSlot.Count && inventory.objects[item.ID].Item2 > 0)
        {
            item.Use(gameObject);
            inventory.objects[item.ID] = (inventory.objects[item.ID].Item1, inventory.objects[item.ID].Item2 - 1);
        }
    }
}
