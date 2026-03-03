using UnityEngine;

public class LuckCam : MonoBehaviour
{
    GameObject cam;
    Vector3 locked;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            locked = cam.transform.localPosition;
            cam.transform.parent = null;
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            cam.transform.parent = transform;
            cam.transform.localPosition = locked;
        }
    }
}
