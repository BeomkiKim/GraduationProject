using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCollision : MonoBehaviour
{
    public GameObject collisionPrefab;
    GameObject[] existCollision;
    int maxCollision = 1;


    SkillBtn skill;
    PlayerState playerState;

    void Start()
    {
        skill = FindObjectOfType<SkillBtn>();
        playerState = FindObjectOfType<PlayerState>();
        existCollision = new GameObject[maxCollision];


    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && skill.isFCool == false && playerState.mpCur >= skill.fCost)
        {
            StartCoroutine(Exec());
        }
    }
    IEnumerator Exec()
    {
        while (true)
        {
            Generate();
            yield return new WaitForSeconds(3.0f);
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
