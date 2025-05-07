using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUISlot : MonoBehaviour
{
    Tool SlottedTool;
    public Tool slottedTool
    {
        get { return SlottedTool; }
        set
        {
            SlottedTool = value;
            if (value == null)
            {
                toolNameText.text = "";
                return;
            }
            toolNameText.text = value.itemName;
        }
    }

    TextMeshProUGUI toolNameText;

    [SerializeField]
    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        toolNameText = GetComponentInChildren<TextMeshProUGUI>();
        if (toolNameText == null)
        {
            Debug.LogError("Tool name text component not found in children.");
        }
    }

    public void HighlightUI(bool on)
    {
        if (on)
        {
            image.color = new Color(1, 1, 1, 1);
        }
        else
        {
            image.color = new Color(1, 1, 1, 0.5f);
        }
    }
}
