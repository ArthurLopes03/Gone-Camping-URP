using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScene : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
