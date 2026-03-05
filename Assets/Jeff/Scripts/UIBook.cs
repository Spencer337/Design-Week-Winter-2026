
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIBook : MonoBehaviour
{
    public GameObject BookMenu;
    private bool bookOpen = false;

    public Image[] ImageTab;
    public GameObject[] GameObjectTabPage;

    public GameObject[] FossilPageArry;
    public GameObject[] ObjectPageArry;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TabPage(0);
        FossilPagePlus(0);
        ObjectPagePlus(0);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bookOpen = !bookOpen;
            BookMenu.SetActive(bookOpen);
        }
    }


    public void TabPage(int tabWhich)
    {
        int count = Mathf.Min(GameObjectTabPage.Length, ImageTab.Length);

        if (tabWhich < 0 || tabWhich >= count) return;
        for (int i = 0; i < GameObjectTabPage.Length; i++)
        {
            GameObjectTabPage[i].SetActive(false);
            ImageTab[i].color = Color.grey;
        }
        GameObjectTabPage[tabWhich].SetActive(true);
        ImageTab[tabWhich].color = Color.white;
    }

    public void FossilPagePlus(int FPageWhichRight)
    {
        if (FPageWhichRight < 0 || FPageWhichRight >= FossilPageArry.Length)
            return;
        for (int i = 0; i < FossilPageArry.Length; i++)
        {
            FossilPageArry[i].SetActive(false);
        }
        FossilPageArry[FPageWhichRight].SetActive(true);

    }
    public void FossilPageMinus(int FPageWhichLeft)
    {
        if (FPageWhichLeft < 0 || FPageWhichLeft >= FossilPageArry.Length)
            return;
        for (int i = 0; i < FossilPageArry.Length; i++)
        {
            FossilPageArry[i].SetActive(false);
        }
        FossilPageArry[FPageWhichLeft].SetActive(true);

    }
    public void ObjectPagePlus(int OPageWhichRight)
    {
        if (OPageWhichRight < 0 || OPageWhichRight >= ObjectPageArry.Length)
            return;
        for (int i = 0; i < ObjectPageArry.Length; i++)
        {
            ObjectPageArry[i].SetActive(false);
        }
        ObjectPageArry[OPageWhichRight].SetActive(true);

    }
    public void ObjectPageMinus(int OPageWhichLeft)
    {
        if (OPageWhichLeft < 0 || OPageWhichLeft >= ObjectPageArry.Length)
            return;
        for (int i = 0; i < ObjectPageArry.Length; i++)
        {
            ObjectPageArry[i].SetActive(false);
        }
        ObjectPageArry[OPageWhichLeft].SetActive(true);

    }
}
