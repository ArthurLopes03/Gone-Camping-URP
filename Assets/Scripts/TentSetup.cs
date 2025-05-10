using UnityEngine;

public class TentSetup : InteractableObject
{
    public GameObject tent;
    Task task;
    public override void Interaction()
    {
        task = GameObject.Find("Pitch Tent").GetComponent<Task>();
        if (task != null)
        {
            task.CompleteTask();
        }

        Blackout blackout = GameObject.Find("Blackout Canvas").GetComponent<Blackout>();

        if (blackout != null)
        {
            blackout.StartBlackout(SetUpTent);
        }
    }

    private void SetUpTent()
    {
        tent.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
