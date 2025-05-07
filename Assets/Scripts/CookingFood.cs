using UnityEngine;

public class CookingFood : MonoBehaviour
{
    public bool isCooking = false;

    float cookingTimer = 0f;

    [SerializeField]
    float overCookPoint = 10f;

    public void StartCooking()
    {
        isCooking = true;
    }

    void Cook()
    {
        cookingTimer += Time.deltaTime;
        if (cookingTimer >= overCookPoint)
        {
            Debug.Log("Food is overcooked!");
            isCooking = false;
        }
    }

    private void Update()
    {
        if (isCooking)
        {
            Cook();
        }
    }
}
