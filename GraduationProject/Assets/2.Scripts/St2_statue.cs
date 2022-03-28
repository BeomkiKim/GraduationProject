using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class St2_statue : MonoBehaviour
{
    St_2BossSpawn bossSpawn;
    public GameObject fireEffect;

    private void Awake()
    {
        bossSpawn = FindObjectOfType<St_2BossSpawn>();
        if(fireEffect == null)
        {
            return;
        }
    }
    private void OnDestroy()
    {
        bossSpawn.count += 1;
        fireEffect.SetActive(true);
    }
}
