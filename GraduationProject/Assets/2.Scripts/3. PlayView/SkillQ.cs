using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillQ : MonoBehaviour
{
    public GameObject qSkillObj;

    public float speed;

    public float skillPower;
    int damage;
    float dmgRate;

    private void OnEnable()
    {

        StartCoroutine("QSkill");
        

    }

    IEnumerator QSkill()
    {
        yield return new WaitForSeconds(0.5f);

        while (true)
        {

            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            yield return null;
        }

    }


    void CalculateDmg()
    {
        PlayerState playerState = FindObjectOfType<PlayerState>();
        //BossState bossState = FindObjectOfType<BossState>();


        dmgRate = Random.Range(0.8f, 1.2f);
        int cri = Random.Range(0, 100);
        if (cri < playerState.cri)
            dmgRate = Random.Range(2f, 2.5f);

        damage = (int)((playerState.atk + skillPower) * dmgRate);
    }


    private void OnTriggerEnter(Collider other)
    {
        
        switch(other.gameObject.tag)
        {
            case "Ground":
                StopCoroutine("QSkill");
                gameObject.SetActive(false);
                break;
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

    IEnumerator ResetSkill(GameObject qSkillObj)
    {
        
        yield return new WaitForSeconds(3.5f);

       
        gameObject.SetActive(false);
    }

    private void Update()
    {
        StartCoroutine(ResetSkill(qSkillObj));
    }
}
