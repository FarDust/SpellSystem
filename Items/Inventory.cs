using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory", order = 1)]
public class Inventory : ScriptableObject
{
    public Dictionary<int, Item> keyObjects;
    public Dictionary<int, ValueTuple<Item, int>> objects;
    public List<Item> usableSlot;

    public void AddItem(Item item) {
        if (item is Item)
        {
            if (keyObjects.ContainsKey(item.ID))
            {
                DropItem(item.ID);
                keyObjects[item.ID] = item;
            }
            else
            {
                keyObjects.Add(item.ID, item);
            }
        }
        else if (item is StackableItem) {
            if (objects.ContainsKey(item.ID))
            {
                objects[item.ID] = (objects[item.ID].Item1, objects[item.ID].Item2+1);
            }
            else
            {
                objects.Add(item.ID, (item, 1));
            }
        }
    }

    public void DropItem(int Id) {
        keyObjects.Remove(Id);
    }
}
