using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class St_2BossSpawn : MonoBehaviour
{
    public GameObject circle;
    public GameObject statueEffect;
    public GameObject bossCircle;
    public GameObject eventCam;
    //public GameObject st2_boss;
    public int count;



    private void FixedUpdate()
    {
        if (eventCam == null)
            return;
        if (count == 5)
        {
            circle.SetActive(true);
            statueEffect.SetActive(true);
            bossCircle.SetActive(true);
            eventCam.SetActive(true);
            //st2_boss.SetActive(true);
        }
    }
}
