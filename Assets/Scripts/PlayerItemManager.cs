using Unity.VisualScripting;
using UnityEngine;

public class PlayerItemManager : MonoBehaviour
{
    [SerializeField]
    ItemUISlot slot1, slot2, slot3, slot4;

    ItemUISlot[] slots;

    ItemUISlot currentlySelectedSlot;

    ObjectInteraction objectInteraction;
    public bool AddItem(Tool tool)
    {
        foreach (ItemUISlot slot in slots)
        {
            if (slot.slottedTool == null)
            {
                slot.slottedTool = tool;

                SelectSlot(slot);
                return true;
            }
        }
        return false;
    }

    private void Awake()
    {
        objectInteraction = GameObject.Find("Player").GetComponent<ObjectInteraction>();
    }

    private void Start()
    {
        slots = new ItemUISlot[4];
        slots[0] = slot1;
        slots[1] = slot2;
        slots[2] = slot3;
        slots[3] = slot4;
        foreach (ItemUISlot slot in slots)
        {
            if (slot == null)
            {
                Debug.LogError("Slot is not assigned in the inspector.");
            }

            SelectSlot(slot);
        }
    }

    public void SelectSlot(ItemUISlot slot)
    {
        if (currentlySelectedSlot != null)
            currentlySelectedSlot.HighlightUI(false);

        currentlySelectedSlot = slot;

        currentlySelectedSlot.HighlightUI(true);

        objectInteraction.ChangeTool(currentlySelectedSlot.slottedTool);
    }

    public bool RemoveTool(Tool tool)
    {
        foreach (ItemUISlot slot in slots)
        {
            if (slot.slottedTool == tool)
            {
                slot.slottedTool = null;
                return true;
            }
        }
        return false;
    }

    public void ReplaceTool(Tool toolToReplace,  Tool newTool)
    {
        foreach (ItemUISlot slot in slots)
        {
            if (slot.slottedTool == toolToReplace)
            {
                slot.slottedTool = newTool;
                return;
            }
        }
    }

    public Tool GetCurrentlySelectedItem()
    {
        return currentlySelectedSlot.slottedTool;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSlot(slot1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSlot(slot2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectSlot(slot3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectSlot(slot4);
        }
    }
}
