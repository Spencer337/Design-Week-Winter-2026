using UnityEngine;

public class CamMove : MonoBehaviour
{
    public float PCRotatSpeed = 10f;
    
    public Camera Camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnMouseDrag()
    {
        float rotatX = Input.GetAxis("Mouse X") * PCRotatSpeed;
        float rotatY = Input.GetAxis("Mouse Y") * PCRotatSpeed;

        transform.Rotate(Vector3.down, rotatX);
        transform.Rotate(Vector3.right, rotatY);
    }


}
