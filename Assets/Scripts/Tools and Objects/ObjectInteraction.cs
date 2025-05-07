using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public bool isInteracting = true;

    [SerializeField]
    GameObject InteractUI;

    [SerializeField]
    Tool heldTool = null;

    [SerializeField]
    float interactDistance = 2f;

    bool isUIActive = false;

    public LayerMask mask;

    GameObject cameraObj;

    private void Start()
    {
        cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
    }

    public void ChangeTool(Tool newTool)
    {
        heldTool = newTool;
    }

    InteractableObject interactableObject;
    private void Update()
    {
        if(isInteracting == false)
        {
            return;
        }
        CheckForInteractables();
        //Debug.DrawRay(cameraObj.transform.position, cameraObj.transform.forward * interactDistance, Color.green, mask);

        if (Input.GetKeyDown("e") && isUIActive)
        {
            interactableObject.Interaction();
        }
    }

    private void CheckForInteractables()
    {
        if (Physics.Raycast(cameraObj.transform.position, cameraObj.transform.forward, out var hit, Mathf.Infinity, mask))
        {
            var obj = hit.collider.gameObject;

            interactableObject = obj.GetComponent<InteractableObject>();

            if (interactableObject == null)
            {
                interactableObject = obj.GetComponentInParent<InteractableObject>();
            }

            if (Vector3.Distance(hit.point, transform.position) <= interactDistance && interactableObject.CanInteract(heldTool))
            {
                InteractUI.SetActive(true);
                DisplayInteractText(interactableObject);
                isUIActive = true;
            }
            else
            {
                interactableObject = null;
                isUIActive = false;
                DisplayInteractText(null);
            }

        }
        else
        {
            interactableObject = null;
            isUIActive = false;
            DisplayInteractText(null);
        }
    }

    private void DisplayInteractText(InteractableObject obj)
    {
        TextMeshProUGUI text = InteractUI.GetComponentInChildren<TextMeshProUGUI>();

        if(obj == null)
        {
            text.text = "";
            return;
        }
        text.text = obj.GetStringToDisplay();
    }

    public bool CheckTool(Tool tool)
    {
        if (heldTool == tool)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ClearTool()
    {
        heldTool = null;
    }

    public Tool GetTool()
    {
        return heldTool;
    }
}