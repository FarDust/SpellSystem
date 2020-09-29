using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    public Inventory inventory;

    public void PickUp(Item item) {
        inventory.AddItem(item);
    }
}
