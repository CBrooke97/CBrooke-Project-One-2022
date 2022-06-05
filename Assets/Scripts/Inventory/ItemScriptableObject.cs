using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Consumable, Equipment }

public class ItemScriptableObject : ScriptableObject
{
    public string Name;
    public string Description;
    public ItemType Type;
    public float BuyPrice;
    public float SellPrice;
    public float StackSize;
    
}
