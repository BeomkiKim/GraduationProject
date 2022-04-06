using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [Header("프리팹")]
    public GameObject dropItemPrefab;
    MonsterState statueState;
    PlayerState playerState;

    private void Awake()
    {
        statueState = GetComponent<MonsterState>();
        playerState = GameObject.Find("Player").GetComponent<PlayerState>();


    }
    public void DropItem()
    {
        if (dropItemPrefab == null)//아이템프리팹이 안 들어가있을경우
            return;
        else
        {
            GameObject dropItem = dropItemPrefab;
            Instantiate(dropItem, transform.position, Quaternion.identity);
            return;
        }
    }
}
