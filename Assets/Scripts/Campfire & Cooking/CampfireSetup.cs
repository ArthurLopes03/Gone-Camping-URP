using Unity.VisualScripting;
using UnityEngine;

public class CampfireSetup : InteractableObject
{
    [SerializeField]
    int sticksRequired, tinderRequired;

    [SerializeField]
    GameObject campfireObject;

    FireBuildingMaterialManager fireBuildingMaterialManager;

    Task task;

    private void Start()
    {
        task = GameObject.Find("Build Campfire").GetComponent<Task>();
        fireBuildingMaterialManager = GameObject.Find("Player").GetComponent<FireBuildingMaterialManager>();
    }

    public override bool CanInteract(Tool heldTool)
    {
        if(fireBuildingMaterialManager.EnoughBuildingMaterial(sticksRequired, tinderRequired))
        {
            return true;
        }
        else
        {
            AlterStringToDisplay("Sticks Required: " + (sticksRequired - fireBuildingMaterialManager.sticksAmount) +"\n Tinder Required: " +
                (sticksRequired - fireBuildingMaterialManager.tinderAmount));
            return true;
        }
    }

    public override void Interaction()
    {
        FireBuildingMaterialManager fireBuildingMaterialManager = GameObject.Find("Player").GetComponent<FireBuildingMaterialManager>();
        if (fireBuildingMaterialManager.EnoughBuildingMaterial(sticksRequired, tinderRequired))
        {
            task.CompleteTask();
            fireBuildingMaterialManager.sticksAmount -= sticksRequired;
            fireBuildingMaterialManager.tinderAmount -= tinderRequired;
            fireBuildingMaterialManager.RemoveFireBuildingMaterials();
            BuildCampfire();
        }
    }

    void BuildCampfire()
    {
        campfireObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}