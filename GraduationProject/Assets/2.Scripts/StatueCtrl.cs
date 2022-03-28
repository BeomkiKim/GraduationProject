using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueCtrl : MonoBehaviour
{
    public GameObject[] bossZone;

    private void Awake()
    {
        if (bossZone.Length == 0) return;
    }

    private void OnDestroy()
    {
        bossZone[0].gameObject.SetActive(true);
        bossZone[1].gameObject.SetActive(true);
        bossZone[2].gameObject.SetActive(true);
    }
}
