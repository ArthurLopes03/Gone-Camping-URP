using UnityEngine;

public class CampsiteEntry : MonoBehaviour
{
    [SerializeField]
    private Task findCampsiteTask;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Campsite Entry Triggered");
        if (other.CompareTag("Player"))
        {
            if (findCampsiteTask.isTaskActive)
            {
                findCampsiteTask.CompleteTask();
            }
        }
    }
}