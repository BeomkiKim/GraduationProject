using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCtrl : MonoBehaviour
{
    public GameObject questBar;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            questBar.SetActive(true);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            Time.timeScale = 0;
        }
    }
}
