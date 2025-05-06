using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public TaskUI taskUIManager;
    public Task currentTask;
    public string taskText;

    public List<Task> tasks = new List<Task> { };

    int taskIndex = 0;

    public void NextTask()
    {
        taskIndex++;

        if (taskIndex >= tasks.Count)
        {
            Debug.Log("All tasks completed!");
            return;
        }
        currentTask = tasks[taskIndex];

        currentTask.isTaskActive = true;

        taskText = currentTask.name;

        taskUIManager.SetTaskText(taskText);
    }

    void Start()
    {
        currentTask = tasks[taskIndex];

        taskText = currentTask.name;

        taskUIManager.SetTaskText(taskText);
    }
}
