using UnityEngine;

public class TentInteraction : InteractableObject
{
    TaskGroup taskGroup3, taskGroup4;

    [SerializeField] Structure tentStructure;

    Task task;

    void Start()
    {
        taskGroup3 = GameObject.Find("Task Group 5").GetComponent<TaskGroup>();
        taskGroup4 = GameObject.Find("Task Group 6").GetComponent<TaskGroup>();
        task = GameObject.Find("Pack Up Tent").GetComponent<Task>();

        if (taskGroup3 == null || taskGroup4 == null)
        {
            Debug.LogError("TentInteraction script requires a TaskGroup component on the parent object.");
        }
    }

    public override bool CanInteract(Tool heldTool)
    {
        if (taskGroup3 == null)
        {
            return false;
        }

        if (heldTool == null && taskGroup3.active)
        {
            AlterStringToDisplay("Go To Sleep");
            return true;
        }
        else if (heldTool == requiredTool && taskGroup4.active)
        {
            AlterStringToDisplay("Pack Up Tent");
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void Interaction()
    {
        if(taskGroup3.active)
        {
            GameObject.Find("Blackout Canvas").GetComponent<Blackout>().StartBlackout(NextDay, 3f);
        }
        else if (taskGroup4.active)
        {
            task.CompleteTask();
            PackUpTent();
        }
    }

    void NextDay()
    {
        Debug.Log("Next day!");
        taskGroup3.gameObject.GetComponentInChildren<Task>().CompleteTask();
    }

    void PackUpTent()
    {
        GameObject.Find("Player").GetComponent<PlayerItemManager>().PickUpStructure(tentStructure);

        this.gameObject.SetActive(false);
    }
}
