using UnityEngine;

public class TrowelItem : MonoBehaviour
{
    [SerializeField]
    Tool trowel;

    [SerializeField]
    Structure campfire;

    PlayerItemManager playerItemManager;
    ObjectPlacer objectPlacer;
    
    bool isPlacingCampfire = false;

    public void Start()
    {
        playerItemManager = GameObject.Find("Player").GetComponent<PlayerItemManager>();
        objectPlacer = GameObject.Find("Player").GetComponent<ObjectPlacer>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && playerItemManager.GetCurrentlySelectedItem() == trowel && !isPlacingCampfire)
        {
            isPlacingCampfire = true;

            GameObject campfireObject = Instantiate(campfire.structureBlueprint, transform.position, Quaternion.identity);

            objectPlacer.SetPlacingStructure();
            objectPlacer.ChangeSelectedStructure(campfire, campfireObject);

            campfireObject.SetActive(true);
        }
    }
}