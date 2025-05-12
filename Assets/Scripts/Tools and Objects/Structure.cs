using UnityEngine;
[CreateAssetMenu(fileName = "Structure", menuName = "Scriptable Objects/Structure")]
public class Structure : BackpackStorableItem
{
    public GameObject structurePrefab;

    public GameObject structureBlueprint;

    public bool canReturnToBackpack;
}
