using UnityEngine;
using UnityEngine.InputSystem;

public class DustOnClick : MonoBehaviour
{
    public Vector3 positionOnFossil;
    public LayerMask sandLayerMask;
    //public Texture2D fossilTexture;
    public Material topLayer, middleLayer, bottomLayer;
    public float opacity, currentlayer;
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
                Debug.Log("dusting");
                if (currentlayer == 0)
                {
                    opacity -= 0.1f;
                    topLayer.color = new Color(1f, 1f, 1f, opacity);
                    if (opacity <= 0)
                    {
                        currentlayer++;
                        opacity = 1;
                    }
                }
                else if (currentlayer == 1)
                {
                    opacity -= 0.1f;
                    middleLayer.color = new Color(1f, 1f, 1f, opacity);
                    if (opacity <= 0)
                    {
                        currentlayer++;
                        opacity = 1;
                    }
                }
                else
                {

                }
                //positionOnFossil = mouseClickHit.point;
                //Debug.Log(positionOnFossil);
            }
        }

    }

    public void paintPixel()
    {
        //fossilTexture.GetPixel(positionOnFossil);
        //fossilTexture.GetPixels
    }
}
