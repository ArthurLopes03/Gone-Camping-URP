using UnityEngine;

public class WaterSpigotInteraction : InteractableObject
{
    [SerializeField]
    Tool dirtyCookingSet, cleanCookingSet, dirtyEatingKit, cleanEatingKit;

    [SerializeField]
    Structure filledBucket;

    public override void Interaction()
    {
        PlayerItemManager playerItemManager = GameObject.Find("Player").GetComponent<PlayerItemManager>();
        if (GameObject.Find("Player").GetComponent<PlayerItemManager>().GetCurrentlySelectedItem() == dirtyCookingSet)
        {
            playerItemManager.ReplaceTool(dirtyCookingSet, cleanCookingSet);
            Debug.Log("Cleaned Cooking Set");
        }
        else if (playerItemManager.GetCurrentlySelectedItem() == dirtyEatingKit)
        {
            playerItemManager.ReplaceTool(dirtyEatingKit, cleanEatingKit);
            Debug.Log("Cleaned Eating Kit");
        }
        else
        {
            GameObject.Find("Player").GetComponent<PlayerItemManager>().RemoveTool(requiredTool);
            GameObject.Find("Player").GetComponent<PlayerItemManager>().PickUpStructure(filledBucket);
            Debug.Log("Bucket Filled");
        }
    }

    public override bool CanInteract(Tool heldTool)
    {
        if (heldTool == requiredTool)
        {
            AlterStringToDisplay("Fill Bucket");
            return true;
        }
        else if(heldTool == dirtyCookingSet) 
        {
            AlterStringToDisplay("Clean Cooking Set");
            return true;
        }
        else if (heldTool == dirtyEatingKit)
        {
            AlterStringToDisplay("Clean Eating Kit");
            return true;
        }
        else
        {
            return false;
        }
    }
}
