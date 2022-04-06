using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonItem : MonoBehaviour
{
    PlayerState player;
    private void Awake()
    {
        player = FindObjectOfType<PlayerState>();
    }
    private void OnEnable()
    {
        StartCoroutine("ActiveCtrl");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player.SendMessage("Poison");
        }
    }

    IEnumerator ActiveCtrl()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
