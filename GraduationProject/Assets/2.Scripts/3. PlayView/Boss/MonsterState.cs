using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterState : MonoBehaviour
{
    public int hp;
    public int hpCur;
    public float atk;
    public float cri;
    public int def;
    public int exp;

    PlayerState playerState;
    ItemSpawn item;

    private void Start()
    {
        hpCur = hp;
        playerState = FindObjectOfType<PlayerState>();
        item = GetComponent<ItemSpawn>();
    }

    private void Update()
    {
        if (hpCur <= 0)
        {
            playerState.expCur += exp;
            if (gameObject.tag == "ItemStatue")
            {
                item.SendMessage("DropItem");
            }
            
            Destroy(gameObject);

        }
    }


}
