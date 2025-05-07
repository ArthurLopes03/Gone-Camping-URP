using UnityEngine;

public class CampfireInteraction : InteractableObject
{
    [SerializeField]
    Tool cookingSetTool;
    [SerializeField]
    GameObject cookingSetObj;
    public override void Interaction()
    {
        GameObject player = GameObject.Find("Player");
        if (player.GetComponent<ObjectInteraction>().CheckTool(cookingSetTool))
        {
            player.GetComponent<ObjectInteraction>().ClearTool();
            player.GetComponent<PlayerItemManager>().RemoveTool(cookingSetTool);
            cookingSetObj.SetActive(true);
        }
        else
        {
            Debug.Log("Boop!");
        }
    }
}