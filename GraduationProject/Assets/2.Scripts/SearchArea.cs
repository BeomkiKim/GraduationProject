using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchArea : MonoBehaviour
{
    ZombieCtrl zombieCtrl;
    TargetManager targetMng;
    private void Start()
    {
        zombieCtrl = transform.root.GetComponent<ZombieCtrl>();
        targetMng = FindObjectOfType<TargetManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Manager.instance.soundManager.bkAudio.PlayOneShot(Manager.instance.soundManager.zombi);
            zombieCtrl.target = targetMng.target;
        }
    }
}
