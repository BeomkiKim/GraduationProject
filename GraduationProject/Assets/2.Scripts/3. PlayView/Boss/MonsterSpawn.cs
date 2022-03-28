using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{

	public GameObject enemyPrefab;
 
	GameObject[] existEnemys;

	public int maxEnemy = 1;
	EnemyController bossController;

	private void OnEnable()
	{
		bossController = FindObjectOfType<EnemyController>();
		transform.position = bossController.target.position;
		existEnemys = new GameObject[maxEnemy];

		StartCoroutine(Exec());
	}


	IEnumerator Exec()
	{
		while (true)
		{
			Generate();
			yield return new WaitForSeconds(0.8f);
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
