using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusSkillSpawnPoints : MonoBehaviour
{
    public GameObject[] spawnPoint;
    private void OnEnable()
    {
        StartCoroutine("DelaySpawn");
    }

    IEnumerator DelaySpawn()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        spawnPoint[0].SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        spawnPoint[1].SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        spawnPoint[2].SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        spawnPoint[3].SetActive(true);
        yield return new WaitForSecondsRealtime(10.0f);
        spawnPoint[0].SetActive(false);
        spawnPoint[1].SetActive(false);
        spawnPoint[2].SetActive(false);
        spawnPoint[3].SetActive(false);
    }
}
