using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventorySlot> itemInventory = new List<InventorySlot>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Checks if item is already in inventory.
    //If yes, add amount to stack.
    //If no, adds new List entry.
    public void AddItem(ItemScriptableObject itemAdded, int amount)
    {
        bool hasItem = false;

        for (int i = 0; i < itemInventory.Count; i++)
        {
            if (itemInventory[i].item == itemAdded)
            {
                print("Item incremented");
                hasItem = true;
                itemInventory[i].AddAmount(amount);
                break;
            }
        }
        if(!hasItem)
        {
            itemInventory.Add(new InventorySlot(itemAdded, amount));
        }

    }

    //Checks if player has item in inventory.
    //Deducts amount used/sold if amount is less than inventory amount.
    //Removes item from List if amount is greater than inventory amount.

    /*
    public void RemoveItem(ItemScriptableObject itemRemoved, float amount)
    {
        if (itemInventory.Contains(itemRemoved) && itemRemoved.Amount == amount)
        {
            itemInventory.Remove(itemRemoved);
        }
        else if(itemInventory.Contains(itemRemoved) && itemRemoved.Amount > amount)
        {
            int itemIndex = itemInventory.IndexOf(itemRemoved);
            itemInventory[itemIndex].Amount -= amount;
        }
    }*/
}
