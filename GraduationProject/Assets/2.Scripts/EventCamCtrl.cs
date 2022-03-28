using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCamCtrl : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine("ActiveCamera");
    }

    IEnumerator ActiveCamera()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }
}
