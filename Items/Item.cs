using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DefaultItem", menuName = "ScriptableObjects/Items/Default", order = 1)]
public class Item : ScriptableObject
{
    public int ID;
    public string itemName;
    public string description;
    public Sprite icon;
    public GameObject itemPrefab;
    public AudioClip retrieveSound;
}
