using TMPro;
using UnityEngine;

public class FoodEating : MonoBehaviour
{
    ObjectInteraction objectInteraction;
    PlayerItemManager playerItemManager;
    TextMeshProUGUI interactionText;

    [SerializeField]
    Tool dirtyEatingKit;

    [SerializeField]
    Task task;

    public bool holdingFood = false;

    private void Start()
    {
        objectInteraction = GetComponent<ObjectInteraction>();
        playerItemManager = GetComponent<PlayerItemManager>();
        interactionText = GameObject.Find("Interaction Text").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (playerItemManager.GetCurrentlySelectedItem() != null && playerItemManager.GetCurrentlySelectedItem().isEdible && holdingFood == false)
        {
            interactionText.text = "E = Eat Food";

            objectInteraction.isInteracting = false;

            holdingFood = true;
        }
        else if (playerItemManager.GetCurrentlySelectedItem() == null || (!playerItemManager.GetCurrentlySelectedItem().isEdible && holdingFood == true))
        {
            objectInteraction.isInteracting = true;

            holdingFood = false;
        }

        if(Input.GetKeyDown("e") && holdingFood)
        {
            objectInteraction.isInteracting = true;
            GetComponent<PlayerItemManager>().ReplaceTool(objectInteraction.GetTool(), dirtyEatingKit);

            Debug.Log("Food Eaten");
            objectInteraction.ClearTool();
            interactionText.text = "";

            task.CompleteTask();

            GameObject.Find("Blackout Canvas").GetComponent<Blackout>().StartBlackout(null, 2f);

            this.enabled = false;
        }
    }
}