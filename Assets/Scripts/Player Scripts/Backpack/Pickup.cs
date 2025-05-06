using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pickup : InteractableObject
{
    public Item item = new Item("Item Name", 1);

    public override void Interaction()
    {
        BackpackInventory.instance.AddItem(item);
        Destroy(gameObject);
    }
}
