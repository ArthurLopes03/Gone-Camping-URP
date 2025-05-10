using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Journal : MonoBehaviour
{
    [SerializeField] private GameObject JournalUI;
    public TextMeshProUGUI currentObjectiveText;
    bool journalOpen;

    void Start()
    {
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
