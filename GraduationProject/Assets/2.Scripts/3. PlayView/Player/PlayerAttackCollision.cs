using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttackCollision : MonoBehaviour
{
    public HitStop hitStop;
    public int damage;

    PlayerState playerState;
    EnemyController takeDamage;

    Color color;
    float dmgRate;


    private void Start()
    {
        playerState = transform.root.GetComponent<PlayerState>();


    }
    private void setDamage()
    {
        dmgRate = Random.Range(0.9f, 1.4f);
        int cri = Random.Range(0, 100);
        if (cri < playerState.cri)
            dmgRate = Random.Range(2.5f, 3.0f);

        damage = (int)(playerState.atk * dmgRate);
    }

    private void Update()
    {
        setDamage();

    }


    private void OnEnable()
    {
        StartCoroutine("AutoDisable");
 
    }

    private void OnTriggerEnter(Collider other)
    {
        //�÷��̾ Ÿ���ϴ� ����� �±�, ������Ʈ, �Լ��� �ٲ� �� �ִ�.
        if(other.CompareTag("Boss"))
        {
            other.GetComponent<HitBox>().TakeDamage(damage);
            playerState.GetHp(damage);


            hitStop.StopTime();
        }
        if(other.CompareTag("Monster"))
        {
            other.GetComponent<MonsterHitBox>().TakeDamage(damage);

            hitStop.StopTime();
            playerState.GetHp(damage);
        }
        if(other.CompareTag("SpawnMonster"))
        {
            other.GetComponent<SkeletonMonsterHitbox>().TakeDamage(damage);
            hitStop.StopTime();
            playerState.GetHp(damage);
        }
    }

    private IEnumerator AutoDisable()
    {
        //0.1�� �Ŀ� ������Ʈ�� ��������� �Ѵ�.
        yield return new WaitForSeconds(0.2f);

        gameObject.SetActive(false);
    }

}
