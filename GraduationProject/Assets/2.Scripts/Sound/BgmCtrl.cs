using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmCtrl : MonoBehaviour
{
    public GameObject dontDestroy;

    private void Start()
    {
        DontDestroyOnLoad(dontDestroy);

        //    GameObject[] audios = GameObject.FindGameObjectsWithTag("BGM");
        //    if (audios.Length >= 2)
        //    {
        //        Destroy(audios[1]);
        //    }
    }

}
