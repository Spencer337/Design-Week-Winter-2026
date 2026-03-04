using Unity.Multiplayer.PlayMode;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.Port;

public class ClickToDig : MonoBehaviour
{
    public Vector3 positionOnFossil;
    public LayerMask sandLayerMask;
    //public Texture2D fossilTexture;
    public Material topLayer, middleLayer, bottomLayer;
    public float opacity, currentlayer;
    public GameObject target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentlayer = 0;
        opacity = 1;
        topLayer.color = new Color(1f, 1f, 1f, 1f);
        middleLayer.color = new Color(1f, 1f, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        bool leftMouseClicked = Mouse.current.leftButton.wasPressedThisFrame;
        if (leftMouseClicked)
        {
            Vector3 mousePosition = Mouse.current.position.ReadValue();
            //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Ray mouseClickRay = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit mouseClickHit;

            if (Physics.Raycast(mouseClickRay, out mouseClickHit, 25f, sandLayerMask))
            {
                Debug.Log("Digging");
                target = mouseClickHit.transform.gameObject;
                Destroy(target);
                target = null;
            }
        }
    }
}
