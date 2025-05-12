using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUISlot : MonoBehaviour
{
    Tool SlottedTool;

    [SerializeField]
    GameObject UIObj;

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
    RawImage image;

    private void Awake()
    {
        image = UIObj.GetComponent<RawImage>();
        toolNameText = UIObj.GetComponentInChildren<TextMeshProUGUI>();
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

    public void DarkenUI(bool on)
    {
        if (on)
            image.color = new Color(1, 1, 1, 0.2f);
        else
            image.color = new Color(1, 1, 1, 0.5f);
    }
}
