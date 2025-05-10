using Unity.VisualScripting;
using UnityEngine;

public class PlayerItemManager : MonoBehaviour
{
    public ItemUISlot[] slots;

    ItemUISlot currentlySelectedSlot;

    ObjectInteraction objectInteraction;

    ObjectPlacer objectPlacer;

    bool itemsEnabled = true;

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
        objectPlacer = GameObject.Find("Player").GetComponent<ObjectPlacer>();
    }

    private void Start()
    {
        foreach (ItemUISlot slot in slots)
        {
            if (slot == null)
            {
                Debug.LogError("Slot is not assigned in the inspector.");
            }

            SelectSlot(slot);
        }

        DisableItems();
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
                if (currentlySelectedSlot.slottedTool == toolToReplace)
                {
                    objectInteraction.ChangeTool(newTool);
                }

                slot.slottedTool = newTool;
                return;
            }
        }
    }

    public void PickUpStructure(Structure structure)
    {
        DisableItems();

        objectPlacer.structureBeingPlaced = structure;

        objectPlacer.ChangeSelectedStructure(structure, Instantiate(structure.structureBlueprint, transform.position, Quaternion.identity));
    }

    public void PutAwayStructure()
    {
        EnableItems();
        objectPlacer.SetStructureNull();
    }

    public Tool GetCurrentlySelectedItem()
    {
        return currentlySelectedSlot.slottedTool;
    }

    private void Update()
    {
        if(itemsEnabled)
        {
            ProcessInput();
        }
    }

    void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSlot(slots[0]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSlot(slots[1]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectSlot(slots[2]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectSlot(slots[3]);
        }
    }

    void DisableItems()
    {
        itemsEnabled = false;

        objectInteraction.ChangeTool(null);

        foreach (ItemUISlot slot in slots)
        {
            slot.DarkenUI(true);
        }
    }

    public void EnableItems()
    {
        foreach (ItemUISlot slot in slots)
        {
            slot.DarkenUI(false);
        }

        itemsEnabled = true;
        
        SelectSlot(slots[0]);
    }
}