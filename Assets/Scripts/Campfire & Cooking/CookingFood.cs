using UnityEngine;

public class CookingFood : MonoBehaviour
{
    public bool isCooking = false;

    float cookingTimer = 0f;

    [SerializeField]
    float overCookPoint = 30f;

    [SerializeField]
    float cookTime = 10f;

    public Task task;

    private void Start()
    {
        task = GameObject.Find("Cook Some Food").GetComponent<Task>();
    }

    public void StartCooking()
    {
        isCooking = true;
    }

    void Cook()
    {
        cookingTimer += Time.deltaTime;
        if (cookingTimer >= cookTime)
        {
            task.CompleteTask();
            Debug.Log("Food is cooked!");
        }
        else if (cookingTimer >= overCookPoint)
        {
            Debug.Log("Food is overcooked!");
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
