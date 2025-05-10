using UnityEngine;

public class Billboard : MonoBehaviour
{

    Transform cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cam.position + cam.forward);
    }
}
