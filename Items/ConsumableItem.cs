using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConsumableItem", menuName = "ScriptableObjects/Items/Consumable", order = 1)]
public class ConsumableItem : StackableItem
{
    public string message;
    public float value;
    public float coldDown;
    public void Use(GameObject gameObject) {
        gameObject.SendMessage(message, value);
    }
}
