using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    LayerMask layerMask;
    [SerializeField]
    GameObject structureBlueprint;

    [SerializeField]
    GameObject structurePrefab;

    Transform cameraTransform;

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
                Debug.Log("Placing structure: " + structurePrefab.name);
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
        }
    }

    public void ChangeSelectedStructure(Structure structure, GameObject blueprint)
    {
        structureBlueprint = blueprint;
        structurePrefab = structure.structurePrefab;

        structureBlueprint.SetActive(false);
    }

    private void PlaceStruture()
    {
        structureBlueprint.SetActive(false);
        isPlacingStructure = false;
        Instantiate(structurePrefab, structureBlueprint.transform.position, structureBlueprint.transform.rotation);
        Destroy(structureBlueprint);

        structureBlueprint = null;
        structurePrefab = null;

        this.GetComponent<PlayerItemManager>().EnableItems();
    }
}
