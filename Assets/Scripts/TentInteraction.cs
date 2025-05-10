using UnityEngine;

public class TentInteraction : InteractableObject
{
    TaskGroup taskGroup;

    void Start()
    {
        taskGroup = GameObject.Find("Task Group 3").GetComponent<TaskGroup>();
        if (taskGroup == null)
        {
            Debug.LogError("TentInteraction script requires a TaskGroup component on the parent object.");
        }
    }

    public override bool CanInteract(Tool heldTool)
    {
        if (taskGroup == null)
        {
            return false;
        }
        if (heldTool == null && taskGroup.active)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void Interaction()
    {
        GameObject.Find("Blackout Canvas").GetComponent<Blackout>().StartBlackout(NextDay);
    }

    void NextDay()
    {
        Debug.Log("Next day!");
    }
}
