
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIBook : MonoBehaviour
{
    public GameObject BookMenu;
    public GameObject BookPage1;
    public GameObject BookPage2;

    public GameObject BookPage3;
    private bool bookOpen = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (BookMenu != null)
            BookMenu.SetActive(false);

        if (BookPage1 != null)
            BookPage1.SetActive(true);

        if (BookPage2 != null)
            BookPage2.SetActive(false);

        if (BookPage3 != null)
            BookPage3.SetActive(false);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bookOpen = !bookOpen;
            BookMenu.SetActive(bookOpen);
        }
    }


    public void PressedToShowBook()
    {
        BookMenu.SetActive(true);
    }
    public void PressedLToGoPageTwo()
    {
        BookPage2.SetActive(true);
        BookPage1.SetActive(false);
    }
    public void PressedRToGoPageOne()
    {
        BookPage1.SetActive(true);
        BookPage2.SetActive(false);
        
    }
    public void PressedRToGoPageThree()
    {
        BookPage3.SetActive(true);
        BookPage2.SetActive(false);
    }
    public void PressedRToGoPagetwo()
    {
        BookPage2.SetActive(true);
        BookPage3.SetActive(false);

    }
    public void CloseBook()
    {
        BookMenu.SetActive(false);
    }
}
