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
        for (int pointCount = 0; pointCount < spawnPoint.Length; ++pointCount)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            spawnPoint[pointCount].SetActive(true);
        }
        yield return new WaitForSecondsRealtime(10.0f);
        for (int pointCount = 0; pointCount < spawnPoint.Length; ++pointCount)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            spawnPoint[pointCount].SetActive(false);
        }
    }
}
