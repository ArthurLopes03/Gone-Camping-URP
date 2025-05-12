using UnityEngine;

public class EndGameZone : MonoBehaviour
{
    [SerializeField]
    TaskGroup taskGroup;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && taskGroup.active)
        {
            GameObject.Find("Blackout Canvas").GetComponent<Blackout>().StartBlackout(EndGame, 4f);
        }
    }

    void EndGame()
    {
        Debug.Log("End Game");
    }
}
