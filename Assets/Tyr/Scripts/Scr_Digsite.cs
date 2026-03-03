using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Scr_Digsite : MonoBehaviour
{
    public BoxCollider trigger;
    public GameObject player;
    public bool playerInTrigger;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(trigger.bounds.Contains(player.transform.position))
        {
            playerInTrigger = true;
        }
        else
        {
            playerInTrigger = false;
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

