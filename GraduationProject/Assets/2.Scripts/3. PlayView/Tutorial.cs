using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public GameObject nowPanel;
    public GameObject nextPanel;
    public GameObject title;


    private void Start()
    {
        Time.timeScale = 0;
    }

    void EndPage()
    {
        nowPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void NextPage()
    {
        if (nextPanel == null)
        {
            EndPage();
            title.SetActive(true);
            return;
        }
        nowPanel.SetActive(false);
        nextPanel.SetActive(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
            NextPage();

    }
}
