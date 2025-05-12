using TMPro;
using UnityEngine;

public class FireBuildingMaterialManager : MonoBehaviour
{
    [SerializeField]
    Tool sticks, tinder;

    [SerializeField]
    int sticksNeeded, tinderNeeded;

    [SerializeField]
    Task task;

    public int sticksAmount, tinderAmount;

    [SerializeField]
    TextMeshProUGUI fireBuildingMaterialText;

    PlayerItemManager playerItemManager;

    private void Start()
    {
        playerItemManager = GameObject.Find("Player").GetComponent<PlayerItemManager>();
    }

    private void Update()
    {
        CheckIfHoldingMaterial();
    }

    void CheckIfHoldingMaterial()
    {
        if (playerItemManager.GetCurrentlySelectedItem() == sticks)
        {
            fireBuildingMaterialText.text = "Sticks: " + sticksAmount;
        }
        else if (playerItemManager.GetCurrentlySelectedItem() == tinder)
        {
            fireBuildingMaterialText.text = "Tinder: " + tinderAmount;
        }
        else
        {
            fireBuildingMaterialText.text = "";
        }
    }

    public void AddFireBuildingMaterial(Tool tool, int amount)
    {
        if (tool == sticks)
        {
            sticksAmount += amount;
        }
        else if (tool == tinder)
        {
            tinderAmount += amount;
        }

        CheckIfEnoughMaterial();
    }

    public void CheckIfEnoughMaterial()
    {
        if (sticksAmount >= sticksNeeded && tinderAmount >= tinderNeeded)
        {
            task.CompleteTask();
        }
    }

    public bool EnoughBuildingMaterial(int sticks, int tinder)
    {
        if (sticksAmount >= sticks && tinderAmount >= tinder)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RemoveFireBuildingMaterials()
    {
        playerItemManager.ReplaceTool(sticks, null);
        playerItemManager.ReplaceTool(tinder, null);
    }
}
