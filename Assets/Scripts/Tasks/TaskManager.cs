using TMPro;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField]
    private TaskGroup[] taskGroups;

    [SerializeField]
    GameObject content;

    [SerializeField]
    TextMeshProUGUI taskGroupNameText;

    [SerializeField]
    GameObject taskUIPrefab;

    [SerializeField]
    float fadeSpeed = 0.05f;
    bool isTextFading = false;

    public float alpha = 1;

    int currentTask = 0;

    void GenerateTaskUI(TaskGroup taskGroup)
    {
        taskGroupNameText.text = taskGroup.groupName;

        foreach (Task task in taskGroup.tasks)
        {
            GameObject taskUI = Instantiate(taskUIPrefab, content.transform);
            
            string taskName = task.taskName;

            taskName = "- " + taskName;

            taskUI.GetComponent<TextMeshProUGUI>().text = taskName;

            task.SetTaskText(taskUI.GetComponent<TextMeshProUGUI>());
        }
    }

    private void Start()
    {
        GenerateTaskUI(taskGroups[0]);
    }

    private void Update()
    {
        if(isTextFading)
        {
            FadeText();
        }
    }

    public void CompleteTaskGroup()
    {
        isTextFading = true;
    }

    void FadeText()
    {
        alpha -= fadeSpeed * Time.deltaTime;

        if (alpha <= 0)
        {
            alpha = 0;
            isTextFading = false;
            NextTask();
        }

        taskGroupNameText.alpha = alpha;

        foreach (Task task in taskGroups[0].tasks)
        {
            task.FadeText(fadeSpeed);
        }
    }

    void NextTask()
    {
        currentTask++;
        alpha = 1;
        if (currentTask >= taskGroups.Length)
        {
            Debug.Log("All tasks completed!");
            currentTask = 0;
        }
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }
        GenerateTaskUI(taskGroups[currentTask]);

        taskGroups[currentTask].active = true;
    }
}