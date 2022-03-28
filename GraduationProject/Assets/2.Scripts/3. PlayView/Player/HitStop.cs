using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStop : MonoBehaviour
{
    bool stop;
    public float stopTime;

    public Transform shakeCam;
    public Vector3 shake;

    public void StopTime()
    {
        if(!stop)
        {
            stop = true;
            shakeCam.localPosition = shake;
            Time.timeScale = 0;

            StartCoroutine("ReturnTimeScale");
        }
    }

    IEnumerator ReturnTimeScale()
    {
        yield return new WaitForSecondsRealtime(stopTime);

        Time.timeScale = 1;
        shakeCam.localPosition = Vector3.zero;
        stop = false;
    }
}
