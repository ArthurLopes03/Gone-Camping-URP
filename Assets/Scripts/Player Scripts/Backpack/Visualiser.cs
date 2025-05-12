using System.Collections.Generic;
using UnityEngine;

public class InventoryVisualizer : MonoBehaviour
{
    public Transform displayRoot;
    public List<ItemDisplayMapping> itemMappings; // Links item names to prefabs

    private Dictionary<string, GameObject> spawnedItems = new Dictionary<string, GameObject>();

    void Update()
    {
        UpdateVisuals();
    }

    void UpdateVisuals()
    {
        // Check each mapping
        foreach (var mapping in itemMappings)
        {
            //int count = BackpackInventory.instance.GetItemCount(mapping.itemName);
            /*
            if (count > 0)
            {
                if (!spawnedItems.ContainsKey(mapping.itemName))
                {
                    // Instantiate item prefab
                    GameObject obj = Instantiate(mapping.prefab, displayRoot);
                    obj.name = mapping.itemName;
                    spawnedItems[mapping.itemName] = obj;

                    // Position them differently if needed
                    obj.transform.localPosition = displayRoot.transform.localPosition;
                    obj.transform.localRotation = displayRoot.transform.localRotation;
                    obj.transform.localScale = new Vector3(0.3f,0.3f,0.3f);
                }
            }
            else
            {
                // Remove the visual if the item no longer exists
                if (spawnedItems.ContainsKey(mapping.itemName))
                {
                    Destroy(spawnedItems[mapping.itemName]);
                    spawnedItems.Remove(mapping.itemName);
                }
            }
            */
        }
    }
}

[System.Serializable]
public class ItemDisplayMapping
{
    public string itemName;
    public GameObject prefab;
}
