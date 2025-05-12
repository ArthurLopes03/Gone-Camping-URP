using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : InteractableObject
{
    bool backpackOpen = false;
    [SerializeField]
    GameObject backpackUI;
    GameObject playerUI;
    GameObject interactUI;
    GameObject player;

    Task task;

    BackpackUIGenerator backpackUIGenerator;

    public List<BackpackStorableItem> items;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        backpackUI = GameObject.Find("UI").GetComponent<BackPackUIIntermediary>().backPackUI;
        backpackUIGenerator = backpackUI.GetComponent<BackpackUIGenerator>();
        playerUI = GameObject.Find("Player UI");
        interactUI = GameObject.Find("Interact UI");

        task = GameObject.Find("Put Down Backpack").GetComponent<Task>();

        if(task != null)
        {
            task.CompleteTask();
        }
    }

    public override void Interaction()
    {
        if(player.GetComponent<ObjectPlacer>().structureBeingPlaced != null && player.GetComponent<ObjectPlacer>().structureBeingPlaced.canReturnToBackpack)
        {
            PutItemInBackpack(player.GetComponent<ObjectPlacer>().structureBeingPlaced);

            player.GetComponent<ObjectPlacer>().structureBeingPlaced = null;

            player.GetComponent<PlayerItemManager>().EnableItems();

            return;
        }

        backpackUIGenerator.GenerateButtons(this);
        OpenBackPack();
    }

    public override bool CanInteract(Tool heldTool)
    {
        if(player.GetComponent<ObjectPlacer>().structureBeingPlaced != null)
        {
            if (player.GetComponent<ObjectPlacer>().structureBeingPlaced.canReturnToBackpack == false)
            {
                return false;
            }
            AlterStringToDisplay("Return " + player.GetComponent<ObjectPlacer>().structureBeingPlaced.itemName + " to Backpack");
            return true;
        }
        else if(heldTool == requiredTool || requiredTool == null)
        {
            AlterStringToDisplay("Open Backpack");
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Update()
    {
        if (backpackOpen)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CloseBackPack();
            }
        }
    }

    public void CloseBackPack()
    {
        backpackOpen = false;

        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<ObjectInteraction>().enabled = true;

        interactUI.SetActive(true);
        playerUI.SetActive(true);
        backpackUI.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OpenBackPack()
    {
        backpackOpen = true;

        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<ObjectInteraction>().enabled = false;

        interactUI.SetActive(false);
        playerUI.SetActive(false);
        backpackUI.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PutItemInBackpack(BackpackStorableItem item)
    {
        items.Add(item);

        if (item.isTool == true)
        {
            player.GetComponent<PlayerItemManager>().ReplaceTool((Tool)item, null);
        }
        else
        {
            player.GetComponent<PlayerItemManager>().PutAwayStructure();
        }

        backpackUIGenerator.GenerateButtons(this);
    }
    public void TakeItemFromBackpack(BackpackStorableItem item)
    {
        if(item.isTool == true)
        {
            if(player.GetComponent<PlayerItemManager>().AddItem((Tool)item))
            {
                items.Remove(item);
            }
            else
            {
                Debug.Log("No empty slots in the backpack.");
                return;
            }
        }
        else
        {
            Structure structure = (Structure)item;

            PlayerItemManager playerItemManager = player.GetComponent<PlayerItemManager>();

            playerItemManager.PickUpStructure(structure);

            CloseBackPack();
        }

        items.Remove(item);

        backpackUIGenerator.GenerateButtons(this);
    }
}