using Unity.VisualScripting;
using UnityEngine;

public class CampfireSetup : InteractableObject
{
    [SerializeField]
    int requiredWood = 5;
    [SerializeField]
    int requiredTinder = 1;
    BackpackInventory backpackInventory;

    [SerializeField]
    GameObject campfire;

    void Start()
    {
        backpackInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<BackpackInventory>();
    }

    public override string GetStringToDisplay()
    {
        string stringToDisplay = "";

        if (backpackInventory.GetItemCount("Wood") < requiredWood)
        {
            stringToDisplay += $"You need {requiredWood - backpackInventory.GetItemCount("Wood")} sticks \n";

            if (backpackInventory.GetItemCount("Tinder") < requiredTinder)
            {
                stringToDisplay += $"You need {requiredTinder - backpackInventory.GetItemCount("Tinder")} tinder";
            }
        }
        else if (backpackInventory.GetItemCount("Tinder") < requiredTinder)
        {
            stringToDisplay += $"You need {requiredTinder - backpackInventory.GetItemCount("Tinder")} tinder";
        }
        else
        {
            stringToDisplay = "Set up campfire E";
        }

            return stringToDisplay;
    }

    public override void Interaction()
    {
        if(backpackInventory.GetItemCount("Wood") >= requiredWood && backpackInventory.GetItemCount("Tinder") >= requiredTinder)
        {
            backpackInventory.AddItem(new Item("Wood", -requiredWood));
            backpackInventory.AddItem(new Item("Tinder", -requiredTinder));

            campfire.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
