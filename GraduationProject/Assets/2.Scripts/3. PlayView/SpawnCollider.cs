using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollider : MonoBehaviour
{
    public GameObject spawnMonster;

	private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            spawnMonster.gameObject.SetActive(true);
        }
    }
}
