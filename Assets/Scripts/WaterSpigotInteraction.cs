using UnityEngine;

public class WaterSpigotInteraction : InteractableObject
{
    [SerializeField]
    Tool filledBucket;

    public override void Interaction()
    {
        GameObject.Find("Player").GetComponent<ObjectInteraction>().ChangeTool(filledBucket);
        Debug.Log("Filled Bucket");
    }
}
