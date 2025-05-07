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

    BackpackUIGenerator backpackUIGenerator;

    public List<BackpackStorableItem> items;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        backpackUI = GameObject.Find("UI").GetComponent<BackPackUIIntermediary>().backPackUI;
        backpackUIGenerator = backpackUI.GetComponent<BackpackUIGenerator>();
        playerUI = GameObject.Find("Player UI");
        interactUI = GameObject.Find("Interact UI");
    }

    public override void Interaction()
    {
        backpackUIGenerator.GenerateButtons(this);
        OpenBackPack();
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
        backpackUIGenerator.ClearButtons();

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

    public void TakeItemFromBackpack(BackpackStorableItem item)
    {
        CloseBackPack();

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

            player.GetComponent<ObjectPlacer>().ChangeSelectedStructure((Structure)item, 
                Instantiate(structure.structureBlueprint, player.transform.position, Quaternion.identity));
        }

        items.Remove(item);
    }
}