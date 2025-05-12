using TMPro;
using UnityEngine;

public class Task : MonoBehaviour
{
    TaskGroup taskGroup;

    TextMeshProUGUI taskText;

    public string taskName;

    bool isCompleted = false;

    public void CompleteTask()
    {
        if (isCompleted)
        {
            return;
        }
        if (taskText != null)
        {
            taskText.fontStyle = FontStyles.Strikethrough;
        }

        isCompleted = true;

        taskGroup.CheckTasks();

        Debug.Log($"Task {taskName} completed!");
        
    }   

    public void SetTaskGroup(TaskGroup newTaskGroup)
    {
        taskGroup = newTaskGroup;
    }

    public void SetTaskText(TextMeshProUGUI newTaskText)
    {
        taskText = newTaskText;
        if (isCompleted)
        {
            taskText.fontStyle = FontStyles.Strikethrough;
        }
    }

    public void FadeText(float increment)
    {
        taskText.alpha -= increment * Time.deltaTime; ;
    }

    public bool IsCompleted()
    {
        return isCompleted;
    }
}
