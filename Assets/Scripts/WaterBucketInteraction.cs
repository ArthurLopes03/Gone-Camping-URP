using UnityEngine;

public class WaterBucketInteraction : InteractableObject
{
    [SerializeField]
    Tool dirtyCookingSet, cleanCookingSet, dirtyEatingKit, cleanEatingKit;

    [SerializeField]
    Structure waterBucket;

    public override void Interaction()
    {
        PlayerItemManager playerItemManager = GameObject.Find("Player").GetComponent<PlayerItemManager>();
        if (playerItemManager.GetCurrentlySelectedItem() == dirtyCookingSet)
        {
            playerItemManager.ReplaceTool(dirtyCookingSet, cleanCookingSet);
            Debug.Log("Cleaned Cooking Set");
        }
        else if (playerItemManager.GetCurrentlySelectedItem() == dirtyEatingKit)
        {
            playerItemManager.ReplaceTool(dirtyEatingKit, cleanEatingKit);
            Debug.Log("Cleaned Eating Kit");
        }
        else if (playerItemManager.GetCurrentlySelectedItem() == null)
        {
            playerItemManager.PickUpStructure(waterBucket);
            Destroy(this.gameObject.transform.parent.gameObject, 0.1f);
            this.gameObject.SetActive(false);
            Debug.Log("Picked Up Cooking Set");
        }
    }

    public override bool CanInteract(Tool heldTool)
    {
        if (heldTool == null)
        {
            AlterStringToDisplay("Pick Up");
            return true;
        }
        else if (heldTool == dirtyCookingSet)
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
