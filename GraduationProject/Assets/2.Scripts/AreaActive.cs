using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaActive : MonoBehaviour
{
    public GameObject area;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            area.SetActive(true);
        }
    }
}
