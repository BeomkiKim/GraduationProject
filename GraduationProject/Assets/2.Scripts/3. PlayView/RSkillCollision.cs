using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSkillCollision : MonoBehaviour
{
    //r안에 스킬
    float timer = 0;

    public float skillPower;
    int damage;
    float dmgRate;

    void Update()
    {

        StartCoroutine("ResetRskill");

    }

    IEnumerator ResetRskill()
    {

        yield return new WaitForSeconds(2f);


        gameObject.SetActive(false);
    }
    void CalculateDmg()
    {
        PlayerState playerState = FindObjectOfType<PlayerState>();


        dmgRate = Random.Range(0.8f, 1.2f);
        int cri = Random.Range(0, 100);
        if (cri < playerState.cri)
            dmgRate = Random.Range(2f, 2.5f);

        damage = (int)((playerState.atk + skillPower) * dmgRate);
    }
    private void OnTriggerStay(Collider other)
    {

        switch (other.gameObject.tag)
        {
            case "Boss":
                CalculateDmg();
                other.GetComponent<HitBox>().TakeDamage(damage);
                break;

            case "Monster":
                CalculateDmg();
                other.GetComponent<MonsterHitBox>().TakeDamage(damage);
                break;


        }
    }
}
