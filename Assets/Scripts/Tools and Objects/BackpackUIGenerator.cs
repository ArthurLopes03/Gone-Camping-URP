using UnityEngine;
using UnityEngine.UI;

public class BackpackUIGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject buttonPrefab;
    [SerializeField]
    GameObject UIContent;
    public void GenerateButtons(Backpack backpack)
    {
        foreach (BackpackStorableItem s in backpack.items)
        {
            GameObject button = Instantiate(buttonPrefab, UIContent.transform);
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = s.itemName;

            button.GetComponent<Button>().onClick.AddListener(() => backpack.TakeItemFromBackpack(s));
        }
    }

    public void ClearButtons()
    {
        foreach (Transform child in UIContent.transform)
        {
            Destroy(child.gameObject);
        }
    }
}