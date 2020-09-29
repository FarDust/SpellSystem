using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory", order = 1)]
public class Inventory : ScriptableObject
{
    public List<Item> KeyObjects;
    public List<Item> objects;
    public Item usableSlot1;
    public Item usableSlot2;

    public void AddItem(Item item) {
        if (item is Item) {
            KeyObjects.Add(item);
        }
    }

    public void DropItem() {
        
    }
}
