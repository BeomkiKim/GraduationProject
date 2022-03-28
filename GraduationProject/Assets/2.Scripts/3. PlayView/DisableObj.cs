using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObj : MonoBehaviour
{
    //오브젝트가 비활성화되기까지의 시간
    public float dTime;

    private void OnEnable()
    {
        CancelInvoke();
        Invoke("Disable", dTime);
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }
}
