using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    LayerMask layerMask;
    [SerializeField]
    GameObject structureBlueprint;

    [SerializeField]
    GameObject structurePrefab;

    Transform cameraTransform;

    public Structure structureBeingPlaced;

    private bool isPlacingStructure = false;

    private void Start()
    {
        // Set the layer mask to only include the "Ground" layer
        layerMask = LayerMask.GetMask("Ground");

        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        if (!isPlacingStructure)
        {
            if (Input.GetKeyDown(KeyCode.Q) && structurePrefab != null)
            {
                isPlacingStructure = true;
                structureBlueprint.SetActive(true);
            }
        }

        if (isPlacingStructure)
        {
            if (Physics.Raycast(cameraTransform.position, cameraTransform.TransformDirection(Vector3.forward), out RaycastHit hit, 100f, layerMask))
            {
                structureBlueprint.transform.position = hit.point;
            }

            if (Input.GetKey(KeyCode.E))
            {
                structureBlueprint.transform.Rotate(new Vector3(0, -0.25f));
            }

            if (Input.GetKey(KeyCode.Q))
            {
                structureBlueprint.transform.Rotate(new Vector3(0, 0.25f));
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                PlaceStruture();
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                structureBlueprint.SetActive(false);
                isPlacingStructure = false;
            }
        }
    }

    public void ChangeSelectedStructure(Structure structure, GameObject blueprint)
    {
        structureBlueprint = blueprint;
        structurePrefab = structure.structurePrefab;

        structureBlueprint.SetActive(false);
    }

    public void SetStructureNull()
    {
        structurePrefab = null;
        structureBlueprint = null;
        structureBeingPlaced = null;
    }

    private void PlaceStruture()
    {
        structureBlueprint.SetActive(false);
        isPlacingStructure = false;
        Instantiate(structurePrefab, structureBlueprint.transform.position, structureBlueprint.transform.rotation);
        Destroy(structureBlueprint);

        structureBlueprint = null;
        structurePrefab = null;
        structureBeingPlaced = null;

        this.GetComponent<PlayerItemManager>().EnableItems();
    }
}
