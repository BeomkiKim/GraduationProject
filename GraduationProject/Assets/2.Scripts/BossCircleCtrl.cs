using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCircleCtrl : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine("Delay");
    }

    IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(10.0f);
        gameObject.SetActive(false);
    }
}
