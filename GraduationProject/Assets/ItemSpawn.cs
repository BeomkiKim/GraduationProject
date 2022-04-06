using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [Header("������")]
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
        if (dropItemPrefab == null)//�������������� �� ���������
            return;
        else
        {
            GameObject dropItem = dropItemPrefab;
            Instantiate(dropItem, transform.position, Quaternion.identity);
            return;
        }
    }
}
