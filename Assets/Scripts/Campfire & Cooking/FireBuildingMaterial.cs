using UnityEngine;

public class FireBuildingMaterial : InteractableObject
{
    [SerializeField]
    int amount = 1;

    public override void Interaction()
    {
        if(!GameObject.Find("Player").GetComponent<PlayerItemManager>().HasItem(requiredTool))
            GameObject.Find("Player").GetComponent<PlayerItemManager>().AddItem(requiredTool);

        GameObject.Find("Player").GetComponent<FireBuildingMaterialManager>().AddFireBuildingMaterial(requiredTool, amount);
        Destroy(this.transform.parent.gameObject, 0.1f);
        this.gameObject.SetActive(false);
    }

    public override bool CanInteract(Tool heldTool)
    {
        if(heldTool == null || heldTool == requiredTool)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}