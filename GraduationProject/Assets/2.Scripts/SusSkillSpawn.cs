using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusSkillSpawn : MonoBehaviour
{
	public GameObject poisonPrefab;
	GameObject[] existPoison;
	public int maxPoison = 1;

	void Start()
	{

	}
    private void OnEnable()
    {
		existPoison = new GameObject[maxPoison];
		StartCoroutine(Exec());
	}
    IEnumerator Exec()
	{
		while (true)
		{
			Generate();
			yield return new WaitForSeconds(1.0f);
		}
	}

	void Generate()
	{
		for (int poisonCount = 0; poisonCount < existPoison.Length; ++poisonCount)
		{
			if (existPoison[poisonCount] == null)
			{
				existPoison[poisonCount] = Instantiate(poisonPrefab, transform.position, transform.rotation) as GameObject;
				return;
			}
		}
	}
}
