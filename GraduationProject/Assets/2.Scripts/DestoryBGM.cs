using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryBGM : MonoBehaviour
{
    public GameObject audioBGM;
    private void Start()
    {
        audioBGM = GameObject.FindGameObjectWithTag("BGM");
        if (audioBGM == null) { return; }
        Destroy(this.audioBGM);
    }
}
