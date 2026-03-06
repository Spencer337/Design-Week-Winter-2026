using UnityEngine;

public class Inspection : MonoBehaviour
{
    public DiggingAndDusting excavationScript;
    public RotateFossil testFossil;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkFossil(int bookID)
    {
        //testFossil = excavationScript.GetComponent(RotateFossil fossil);
        //Debug.Log("Checking");
        //if (fossil.fossilID == bookID)
        //{
        //    Debug.Log("Correct");
        //    Increase Score
        //}
        //else
        //{
        //    Decrease score
        //    Debug.Log("Incorrect");
        //    fossil.health = 0;
        //}
    }
}
