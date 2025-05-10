using UnityEngine;

public class CookingSetInteraction : InteractableObject
{
    [SerializeField]
    Tool eatingKit = null, cookedFood = null, filledWaterBucket = null, dirtyCookingSet;

    CookingFood cookingFood;

    bool filledWithWater = false;

    bool isDirty = false;

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

            isDirty = true;
        }
        else if (playerItemManager.GetCurrentlySelectedItem() == filledWaterBucket)
        {
            if(filledWithWater)
            {
                Debug.Log("Already filled with water");
                return;
            }
            else
            {
                filledWithWater = true;
                Debug.Log("Filled with water");
            }
        }
        else if(playerItemManager.GetCurrentlySelectedItem() == null && isDirty)
        {
            Debug.Log("Cooking Set Taken");
            playerItemManager.AddItem(dirtyCookingSet);

            this.gameObject.SetActive(false);
        }
        else
        {
            if (filledWithWater)
            {
            Debug.Log("Food Added");

            playerItemManager.RemoveTool(requiredTool);
            objectInteraction.ClearTool();

            cookingFood.StartCooking();
            }
        }
    }

    override public bool CanInteract(Tool heldTool)
    {
        if (heldTool == requiredTool || requiredTool == null)
        {
            if(filledWithWater)
            {
                AlterStringToDisplay("Add Food to Pot");
                return true;
            }
            else
            {
                AlterStringToDisplay("Needs Water!");
                return true;
            }
        }
        else if (heldTool == eatingKit && cookingFood.isCooking)
        {
            AlterStringToDisplay("Take Food");
            return true;
        }
        else if (heldTool == filledWaterBucket && !cookingFood.isCooking)
        {
            AlterStringToDisplay("Fill with Water");
            return true;
        }
        else if (heldTool == null && isDirty)
        {
            AlterStringToDisplay("Take Cooking Set");
            return true;
        }
        else
        {
            return false;
        }
    }
}
