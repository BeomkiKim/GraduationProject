using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1portal : MonoBehaviour
{
    PlayerController playerController;


    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerController.isClear = true;
            
            //SceneManager.LoadScene("StageSelect", LoadSceneMode.Single);
        }
    }
}
