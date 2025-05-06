using UnityEngine;

public class TentSetup : InteractableObject
{
    public GameObject tent;

    Task setUpTentTask;

    public override void Interaction()
    {
        tent.SetActive(true);
        this.gameObject.SetActive(false);

        setUpTentTask = GameObject.Find("Set Up Tent").GetComponent<Task>();

        try
        {
            setUpTentTask.CompleteTask();
        }
        catch
        {
            Debug.Log("Tasks not set");
        }
    }
}
