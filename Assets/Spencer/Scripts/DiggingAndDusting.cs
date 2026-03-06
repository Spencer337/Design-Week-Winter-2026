using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DiggingAndDusting : MonoBehaviour
{
    public LayerMask sandLayer, dustLayer, dirtLayer, fossilLayer;
    public GameObject target;
    public StarterAssetsInputs playerInputs;
    public bool isDigging;
    private Ray mouseClickRay;
    private RaycastHit mouseClickHit;
    public GameObject currentFossil = null;
    public GameObject notebookUI;
    public float score;
    public TMP_Text scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        // If the player is in the digging phase
        if (isDigging == true)
        {
            // Get the mouse Raycast
            bool leftMouseClicked = Mouse.current.leftButton.wasPressedThisFrame;
            if (leftMouseClicked)
            {
                Vector3 mousePosition = Mouse.current.position.ReadValue();

                mouseClickRay = Camera.main.ScreenPointToRay(mousePosition);

                // If the ray hits a sand spot, delete it
                if (Physics.Raycast(mouseClickRay, out mouseClickHit, 25f, sandLayer))
                {
                    target = mouseClickHit.transform.gameObject;
                    Destroy(target);
                    target = null;
                }
            }

            // Check if the player is carrying an object, and they are close to the bench to enter digging
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Debug.Log("Change state");
                notebookUI.SetActive(true);
                isDigging = false;
            }
        }
        // If the player is in the dusting phase
        if (isDigging == false)
        {

            // Display healthbar in UI

            // Get the mouse raycast
            bool rightMouseClicked = Mouse.current.rightButton.wasPressedThisFrame;
            bool leftMouseClicked = Mouse.current.leftButton.wasPressedThisFrame;

            if (leftMouseClicked)
            {
                Vector3 mousePosition = Mouse.current.position.ReadValue();

                mouseClickRay = Camera.main.ScreenPointToRay(mousePosition);

                // If the ray hits a fossil, register it
                if (Physics.Raycast(mouseClickRay, out mouseClickHit, 25f, fossilLayer))
                {
                    Debug.Log("fossilClicked");
                    currentFossil = mouseClickHit.transform.gameObject;
                }
            }

            if (rightMouseClicked)
            {
                Vector3 mousePosition = Mouse.current.position.ReadValue();

                mouseClickRay = Camera.main.ScreenPointToRay(mousePosition);

                // If the ray hits a dust spot, delete it
                if (Physics.Raycast(mouseClickRay, out mouseClickHit, 25f, dustLayer))
                {
                    target = mouseClickHit.transform.gameObject;
                    Destroy(target);
                    target = null;
                }
                else if (Physics.Raycast(mouseClickRay, out mouseClickHit, 25f, dirtLayer))
                {
                    // Decrease score
                    target = mouseClickHit.transform.gameObject;
                    Destroy(target);
                    Debug.Log("Fossil crack");
                    if (currentFossil != null)
                    {
                        currentFossil.GetComponent<RotateFossil>().crackFossil();
                    }
                }
            }

            // Go back into the dusting phase
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Change state");
                notebookUI.SetActive(false);
                isDigging = true;
            }
        }
    }

    public void CheckFossil(int bookID)
    {
        if (currentFossil != null)
        {
            int fossilID = currentFossil.GetComponent<RotateFossil>().fossilID;
            Debug.Log("Checking");
            if (fossilID == bookID)
            {
                Debug.Log("Correct");
                //Increase Score
                score += currentFossil.GetComponent<RotateFossil>().health;
                scoreText.text = score.ToString();
                currentFossil.GetComponent<RotateFossil>().health = 0;
            }
            else
            {
                //Decrease score
                Debug.Log("Incorrect");
                score -= 50;
                scoreText.text = score.ToString();
                currentFossil.GetComponent<RotateFossil>().health = 0;
            }
        }
        
    }
}
