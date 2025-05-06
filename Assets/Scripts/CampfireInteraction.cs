using UnityEngine;

public class CampfireInteraction : InteractableObject
{
    [SerializeField]
    Tool cookingSetTool;
    [SerializeField]
    GameObject cookingSetObj;
    public override void Interaction()
    {
        if (GameObject.Find("Player").GetComponent<ObjectInteraction>().CheckTool(cookingSetTool))
        {
            cookingSetObj.SetActive(true);

            GameObject.Find("Player").GetComponent<ObjectInteraction>().ClearTool();
        }
        else
        {
            Debug.Log("Boop!");
        }
    }
}