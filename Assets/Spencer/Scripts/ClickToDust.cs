using UnityEngine;
using UnityEngine.InputSystem;

public class ClickToDust : MonoBehaviour
{
    //public Vector3 positionOnFossil;
    public LayerMask dustLayerMask, dirtLayerMask;
    //public Texture2D fossilTexture;
    public GameObject target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool rightMouseClicked = Mouse.current.rightButton.wasPressedThisFrame;
        if (rightMouseClicked)
        {
            Vector3 mousePosition = Mouse.current.position.ReadValue();
            //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Ray mouseClickRay = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit mouseClickHit;

            if (Physics.Raycast(mouseClickRay, out mouseClickHit, 25f, dustLayerMask))
            {
                //Debug.Log("Digging");
                target = mouseClickHit.transform.gameObject;
                Destroy(target);
                target = null;
            }
        }
    }
}
