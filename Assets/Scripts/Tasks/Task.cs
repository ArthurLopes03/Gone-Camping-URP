using UnityEngine;

public abstract class Task : MonoBehaviour
{
    public string taskName;

    public bool isTaskActive;

    public void CompleteTask()
    {
        gameObject.GetComponentInParent<TaskManager>().NextTask();

        isTaskActive = false;
    }
}
