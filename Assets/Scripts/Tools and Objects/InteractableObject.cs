using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField]
    Tool requiredTool = null;

    [SerializeField]
    string stringToDisplay = "Interact";

    virtual public bool CanInteract(Tool heldTool)
    {
        if (heldTool == requiredTool || requiredTool == null)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    virtual public void Interaction()
    {
        Debug.Log("Boop!");
    }

    virtual public string GetStringToDisplay()
    {
        return stringToDisplay;
    }

}