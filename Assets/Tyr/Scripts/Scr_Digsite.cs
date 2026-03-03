using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class Scr_Digsite : MonoBehaviour
{
    public BoxCollider trigger;
    public GameObject player;
    public bool playerInTrigger;
    public GameObject digsitePopUp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        digsitePopUp.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(trigger.bounds.Contains(player.transform.position))
        {
            playerInTrigger = true;
            digsitePopUp.gameObject.SetActive(true);
        }
        else
        {
            playerInTrigger = false;
            digsitePopUp.gameObject.SetActive(false);
        }

        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame && playerInTrigger == true)
        {
            sceneSwapper();
        }

    }
    public void sceneSwapper()
    {
        SceneManager.LoadScene(sceneName: "Dusting Test");
    }

}

