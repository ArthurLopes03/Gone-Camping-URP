using UnityEngine;

public class TaskGroup : MonoBehaviour
{
    public string groupName;
    public bool active = false;

    [SerializeField]
    public Task[] tasks;

    [SerializeField]
    int timeValue;

    private void Start()
    {
        foreach (Task task in tasks)
        {
            task.SetTaskGroup(this);
        }
    }

    public void CheckTasks()
    {
        foreach (Task task in tasks)
        {
            if (!task.IsCompleted())
            {
                return;
            }
        }

        CompleteTaskGroup();
    }

    public void CompleteTaskGroup()
    {
        Debug.Log($"All tasks in {groupName} are completed!");

        this.GetComponentInParent<TaskManager>().CompleteTaskGroup();

        GameObject.Find("TimeManager").GetComponent<TimeManager>().Hours = timeValue;
        active = false;
    }
}
