using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
	public GameObject enemyPrefab;
	GameObject[] existEnemys;
	float randomTime;
	public int maxEnemy = 1;

	void Start()
	{
		randomTime = Random.Range(15.0f, 20.0f);
		existEnemys = new GameObject[maxEnemy];
		StartCoroutine(Exec());
	}
	IEnumerator Exec()
	{
		while (true)
		{
			Generate();
			yield return new WaitForSeconds(randomTime);
		}
	}

	void Generate()
	{
		for (int enemyCount = 0; enemyCount < existEnemys.Length; ++enemyCount)
		{
			if (existEnemys[enemyCount] == null)
			{
				existEnemys[enemyCount] = Instantiate(enemyPrefab, transform.position, transform.rotation) as GameObject;
				return;
			}
		}
	}
}

