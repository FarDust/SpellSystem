using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    public Inventory inventory;
    public Canvas drawingCanvas;
    public GameObject inventoryUIprefab;
    private float lastTime;
    private UIInventoryController inventoryUIController;

    private void Start()
    {
        GameObject inventoryUI = Instantiate(inventoryUIprefab);
        inventoryUI.transform.SetParent(drawingCanvas.transform, false);
        inventoryUIController = inventoryUI.GetComponent<UIInventoryController>();
        inventoryUI.SendMessage("setInventory", gameObject.GetComponent<InventoryController>());
        inventoryUI.SendMessage("setUsableButtoms", inventory.usableSlot.Count);
    }

    private void Update()
    {
        if (Input.GetKeyUp("1")) {
            useSlot(0, (ConsumableItem)inventory.usableSlot[0]);
        }
        if (Input.GetKeyUp("2")) {
            useSlot(1, (ConsumableItem)inventory.usableSlot[1]);
        }
    }

    private void updateInventory() {
        inventoryUIController.SendMessage("newItem", inventory);
    }

    public void PickUp(Item item) {
        inventory.AddItem(item);
        if (item is ConsumableItem) {
            for (int i = 0; i < inventory.usableSlot.Count; i++)
            {
                if (inventory.usableSlot[i] == null )
                {
                    assignSlot(i, item);
                    break;
                }
            }
        }
        updateInventory();
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
            inventoryUIController.SendMessage("newItem", inventory);
        }
    }

    public void Request(EventMessage requestedPair) {
        Item item = requestedPair.item;
        GameObject requester = requestedPair.gameObject;
        if(inventory.keyObjects.ContainsKey(item.ID)){
            inventory.UseKeyItem(item.ID);
            requester.SendMessage("Activate");
        }
    }
}

public class EventMessage {
    public GameObject gameObject;
    public Item item;
}