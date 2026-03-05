using UnityEngine;

public class RotateFossil : MonoBehaviour
{
    public float rotateSpeed = 10f;
    public float health = 100;

    public Camera Camera;
    public DiggingAndDusting excavationScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnMouseDrag()
    {
        if (excavationScript.isDigging == false)
        {
            float rotatX = Input.GetAxis("Mouse X") * rotateSpeed;
            float rotatY = Input.GetAxis("Mouse Y") * rotateSpeed;

            transform.Rotate(Vector3.down, rotatX);
            transform.Rotate(Vector3.right, rotatY);
        }
    }

    public void crackFossil()
    {
        health -= 5;
    }
}
