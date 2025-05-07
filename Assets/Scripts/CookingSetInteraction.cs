using UnityEngine;

public class CookingSetInteraction : InteractableObject
{
    [SerializeField]
    Tool eatingKit = null;

    [SerializeField]
    Tool cookedFood = null;

    CookingFood cookingFood;

    private void Start()
    {
        cookingFood = GetComponent<CookingFood>();
    }

    public override void Interaction()
    {
        ObjectInteraction objectInteraction = GameObject.Find("Player").GetComponent<ObjectInteraction>();
        PlayerItemManager playerItemManager = GameObject.Find("Player").GetComponent<PlayerItemManager>();

        if (playerItemManager.GetCurrentlySelectedItem() == eatingKit)
        {
            Debug.Log("Food Taken");

            playerItemManager.ReplaceTool(eatingKit, cookedFood);
            objectInteraction.ChangeTool(cookedFood);
        }
        else
        {
            Debug.Log("Food Added");

            playerItemManager.RemoveTool(requiredTool);
            objectInteraction.ClearTool();

            cookingFood.StartCooking();
        }
    }

    override public bool CanInteract(Tool heldTool)
    {
        if (heldTool == requiredTool || requiredTool == null)
        {
            AlterStringToDisplay("Add Food to Pot");
            return true;
        }
        else if (heldTool == eatingKit && cookingFood.isCooking)
        {
            AlterStringToDisplay("Take Food");
            return true;
        }
        else
        {
            return false;
        }
    }
}
