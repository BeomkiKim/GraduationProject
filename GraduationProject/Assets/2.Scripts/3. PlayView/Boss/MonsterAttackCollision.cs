using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackCollision : MonoBehaviour
{
    public int damage;
    float dmgRate;
    MonsterState monsterState;

    private void Start()
    {
        monsterState = transform.root.GetComponent<MonsterState>();
    }
    private void OnEnable()
    {
        StartCoroutine("AutoDisable");

    }
    private void Update()
    {
        setDamage();

    }
    private void setDamage()
    {
        dmgRate = Random.Range(0.8f, 1.2f);
        int cri = Random.Range(0, 100);
        if (cri < monsterState.cri)
            dmgRate = Random.Range(2f, 2.5f);

        damage = (int)(monsterState.atk * dmgRate * 12);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerHit"))
        {
            other.GetComponent<PlayerHit>().TakeDamage(damage);
        }
    }
    private IEnumerator AutoDisable()
    {
        //0.1초 후에 오브젝트가 사라지도록 한다.
        yield return new WaitForSeconds(0.2f);

        gameObject.SetActive(false);
    }
}
