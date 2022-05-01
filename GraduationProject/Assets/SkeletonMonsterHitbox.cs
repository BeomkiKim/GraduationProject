using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMonsterHitbox : MonoBehaviour
{
    public bool hit;


    public void TakeDamage(int damage)
    {
        MonsterState monsterState = transform.root.GetComponent<MonsterState>();

        //damage -= (int)monsterState.def;
        monsterState.hpCur -= damage;


        hit = true;

    }
}
