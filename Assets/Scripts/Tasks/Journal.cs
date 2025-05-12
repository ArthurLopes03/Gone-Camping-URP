using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Journal : MonoBehaviour
{
    [SerializeField] private GameObject JournalUI;
    [SerializeField] private GameObject JournalObject;
    public TextMeshProUGUI currentObjectiveText;
    public TextMeshProUGUI headingText;
    bool journalOpen;

    public TaskManager taskManager;
    public Material[] pages;
    private Renderer meshRenderer;
    public Material pageToChange1;
    public Material pageToChange2;
    private int pageIndex = 0;

    void Start()
    {
        meshRenderer = JournalObject.GetComponent<MeshRenderer>();
        journalOpen = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            if (!journalOpen)
            {
                OpenJournal();
            }
            else
            {
                CloseJournal();
            }
        }

        //currentObjectiveText.text = taskManager.taskText;

        if (journalOpen)
        {
            if (Input.GetKeyDown("x"))
            {
                pageIndex++;
                if (pageIndex == 3)
                {
                    pageIndex = 0;
                }
            }
            if (pageIndex == 1)
            {
                currentObjectiveText.gameObject.SetActive(false);
                headingText.gameObject.SetActive(false);

                //page 1
                pageToChange1 = pages[1];
                Material[] mats = meshRenderer.materials;
                mats[1] = pageToChange1;
                meshRenderer.materials = mats;
                //page2
                pageToChange2 = pages[2];
                mats[3] = pageToChange2;
                meshRenderer.materials = mats;
            }
            if (pageIndex == 2)
            {
                currentObjectiveText.gameObject.SetActive(false);
                headingText.gameObject.SetActive(false);

                //page 1
                pageToChange1 = pages[3];
                Material[] mats = meshRenderer.materials;
                mats[1] = pageToChange1;
                meshRenderer.materials = mats;
                //page2
                pageToChange2 = pages[4];
                mats[3] = pageToChange2;
                meshRenderer.materials = mats;
            }
            if (pageIndex == 0)
            {
                currentObjectiveText.gameObject.SetActive(true);
                headingText.gameObject.SetActive(true);

                //page 1
                pageToChange1 = pages[0];
                Material[] mats = meshRenderer.materials;
                mats[1] = pageToChange1;
                meshRenderer.materials = mats;
                //page2
                pageToChange2 = pages[5];
                mats[3] = pageToChange2;
                meshRenderer.materials = mats;
            }

        }
    }

    public void OpenJournal()
    {
        JournalUI.SetActive(true);
        journalOpen = true;
    }

    public void CloseJournal()
    {
        JournalUI.SetActive(false);
        journalOpen = false;
    }
}
