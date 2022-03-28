using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossColliderSpawn : MonoBehaviour
{
    public GameObject collisionPrefab;
    GameObject[] existCollision;
    int maxCollision = 1;

    EnemyController enemy;


    void Start()
    {
        existCollision = new GameObject[maxCollision];
        enemy = FindObjectOfType<EnemyController>();


    }
    private void Update()
    {
        if(enemy.startSkill)
        {
            StartCoroutine(Exec());
        }
    }
    IEnumerator Exec()
    {
        while (true)
        {
            Generate();
            yield return new WaitForSeconds(0.5f);
            break;
        }
    }

    void Generate()
    {
        for (int ii = 0; ii < existCollision.Length; ++ii)
        {
            if (existCollision[ii] == null)
            {
                existCollision[ii] = Instantiate(collisionPrefab, transform.position, transform.rotation) as GameObject;
                return;
            }
        }
    }
}
