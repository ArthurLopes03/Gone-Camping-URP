using UnityEngine;

public class CampfireInteraction : InteractableObject
{
    [SerializeField]
    Tool cookingSetTool;
    [SerializeField]
    GameObject cookingSetObj;

    Task cookingSetTask, campfireRemovalTask;

    private void Start()
    {
        cookingSetTask = GameObject.Find("Set Up Cooking Kit").GetComponent<Task>();
        campfireRemovalTask = GameObject.Find("Remove Campfire").GetComponent<Task>();
    }

    public override void Interaction()
    {
        GameObject player = GameObject.Find("Player");
        if (player.GetComponent<ObjectInteraction>().CheckTool(cookingSetTool))
        {
            cookingSetTask.CompleteTask();
            player.GetComponent<ObjectInteraction>().ClearTool();
            player.GetComponent<PlayerItemManager>().RemoveTool(cookingSetTool);
            cookingSetObj.SetActive(true);
        }
        else if (campfireRemovalTask.gameObject.GetComponentInParent<TaskGroup>().active)
        {
            campfireRemovalTask.CompleteTask();
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Boop!");
        }
    }

    public override bool CanInteract(Tool heldTool)
    {
        GameObject player = GameObject.Find("Player");
        if (player.GetComponent<ObjectInteraction>().CheckTool(cookingSetTool))
        {
            AlterStringToDisplay("Set Up Cooking Kit");
            return true;
        }
        else if (campfireRemovalTask.gameObject.GetComponentInParent<TaskGroup>().active)
        {
            AlterStringToDisplay("Remove Campfire");
            return true;
        }
        else
        {
            return false;
        }
    }
}