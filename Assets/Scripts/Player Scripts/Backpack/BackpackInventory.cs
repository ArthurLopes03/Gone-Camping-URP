using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackpackInventory : MonoBehaviour
{
    public static BackpackInventory instance;
    public List<Item> items = new List<Item>();

    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    public bool hasItem(string itemName)
    {
        foreach (Item item in items)
        {
            if (item.name == itemName)
            {
                return true;
            }
        }
        return false;
    }

    public int GetItemCount(string itemName)
    {
        foreach (Item item in items)
        {
            if (item.name == itemName)
            {
                return item.count;
            }
        }
        return 0;
    }

    public void AddItem(Item itemToAdd)
    {
        bool itemExists = false;

        foreach (Item item in items)
        {
            if(item.name == itemToAdd.name)
            {
                item.count += itemToAdd.count;
                itemExists = true;
                break;
            }
        }
        if(!itemExists)
        {
            items.Add(itemToAdd);
        }
        Debug.Log(itemToAdd.count + " " + itemToAdd.name + "added to inventory.");
    }

    public void RemoveItem(Item itemToRemove)
    {
        foreach (var item in items)
        {
            if(item.name == itemToRemove.name)
            {
                item.count -= itemToRemove.count;
                if(item.count <= 0)
                {
                    items.Remove(item);
                }
                break;
            }
        }
        Debug.Log(itemToRemove.count + " " + itemToRemove.name + "removed from inventory.");
    }
}
