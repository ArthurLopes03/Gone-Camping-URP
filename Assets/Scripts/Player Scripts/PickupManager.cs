using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [SerializeField] private Transform player, toolContainer, itemContainer, Camera;
    public Rigidbody rb;
    public BoxCollider col;

    [SerializeField] private float pickUpRange;
    [SerializeField] private float dropForceForward, dropForceUpward;

    public bool equippedTool, equippedItem;
    public static bool toolSlotFull, itemSlotFull;

    private void Start()
    {
        if(!equippedTool)
        {
            rb.isKinematic = false;
            col.isTrigger = false;
        }
        
        if(equippedTool)
        {
            rb.isKinematic = true;
            col.isTrigger = true;
            toolSlotFull = true;
        }
    }

    private void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equippedTool && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !toolSlotFull) PickUpTool();

        if (equippedTool && Input.GetKeyDown(KeyCode.Q)) DropTool();

        if (equippedTool)
        {
            transform.position = toolContainer.transform.position;
            transform.rotation = toolContainer.transform.rotation;
        }
    }

    private void PickUpTool()
    {
        equippedTool = true;
        toolSlotFull = true;

        rb.isKinematic = true;
        col.isTrigger = true;

        //Positioning item
        transform.SetParent(toolContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
    }

    private void DropTool()
    {
        equippedTool = false;
        toolSlotFull = false;

        rb.isKinematic = false;
        col.isTrigger = false;

        transform.SetParent(null); 

        //Drop velocity
        rb.linearVelocity = player.GetComponent<Rigidbody>().linearVelocity;

        //Drop force
        rb.AddForce(Camera.up * dropForceUpward, ForceMode.Impulse);
        rb.AddForce(Camera.forward * dropForceForward, ForceMode.Impulse);
    }
}
