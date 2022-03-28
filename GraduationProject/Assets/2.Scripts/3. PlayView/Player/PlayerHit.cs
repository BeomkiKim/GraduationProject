using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public int dmg;
    public void TakeDamage(int damage)
    {
        PlayerState playerState = FindObjectOfType<PlayerState>();

        //damage -= (int)playerState.def;
        if (damage <= 0)
        {
            damage = 0;
        }


        playerState.hpCur -= damage;
        dmg = damage;
    }
}
