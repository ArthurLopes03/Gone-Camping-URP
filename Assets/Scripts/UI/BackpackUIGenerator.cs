using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class BackpackUIGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject buttonPrefab, emptyButtonPrefab;
    [SerializeField]
    GameObject UIBackpackContent;
    [SerializeField]
    GameObject UIHeldItemsContent;
    [SerializeField]
    PlayerItemManager playerItemManager;

    private void Start()
    {
    }

    public void GenerateButtons(Backpack backpack)
    {
        ClearButtons();

        GenerateBackpackButtons(backpack);

        GenerateHeldToolsButtons(backpack);
    }

    private void GenerateBackpackButtons(Backpack backpack)
    {
        foreach (BackpackStorableItem s in backpack.items)
        {
            GameObject button = Instantiate(buttonPrefab, UIBackpackContent.transform);

            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = s.itemName;
            button.GetComponent<Button>().onClick.AddListener(() => backpack.TakeItemFromBackpack(s));
        }
    }

    private void GenerateHeldToolsButtons(Backpack backpack)
    {
        foreach (ItemUISlot s in playerItemManager.slots)
        {
            if (s.slottedTool != null)
            {
                GameObject button = Instantiate(buttonPrefab, UIHeldItemsContent.transform);

                button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = s.slottedTool.itemName;
                button.GetComponent<Button>().onClick.AddListener(() => backpack.PutItemInBackpack(s.slottedTool));
            }
            else
            {
                GameObject button = Instantiate(emptyButtonPrefab, UIHeldItemsContent.transform);

                button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Empty Slot";
                button.GetComponent<Button>().interactable = false;
            }
        }
    }

    private void ClearButtons()
    {
        InputSystemUIInputModule inputModule = GameObject.Find("EventSystem").GetComponent<InputSystemUIInputModule>();
        inputModule.enabled = false;
        foreach (Transform child in UIBackpackContent.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in UIHeldItemsContent.transform)
        {
            Destroy(child.gameObject);
        }
        inputModule.enabled = true;
    }
}