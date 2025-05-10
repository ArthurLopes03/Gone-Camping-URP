using UnityEngine;

public class CampAreaDetector : MonoBehaviour
{
    [SerializeField]
    Task task;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (task != null)
            {
                task.CompleteTask();
            }
        }
    }
}
