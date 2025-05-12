using TMPro;
using UnityEngine;

public class TaskUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI taskText;

    public void SetTaskText(string text)
    {
        taskText.text = text;
    }
}
