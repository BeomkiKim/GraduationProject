using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RColliderScale : MonoBehaviour
{
    //r¹Ù±ù½ºÅ³
    float timer = 0;
    Vector3 baseScale = new Vector3(1f, 1f, 1f);

    public float skillPower;
    int damage;
    float dmgRate;

    private void OnEnable()
    {
        
        StartCoroutine("Scaletrans");

    }

    void Update()
    {

        StartCoroutine("ResetRskill");

    }

    public void Scaling(Vector3 newScale)
    {
        transform.localScale = newScale + baseScale;
    }

    IEnumerator Scaletrans()
    {
        while (true)
        {
            timer += Time.deltaTime*2f;
            Scaling(new Vector3(timer*5f, timer*5f, timer*5f));
            yield return null;
        }

    }

    IEnumerator ResetRskill()
    {
        
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);

        //gameObject.SetActive(false);
    }

    void CalculateDmg()
    {
        PlayerState playerState = FindObjectOfType<PlayerState>();
        BossState bossState = FindObjectOfType<BossState>();


        dmgRate = Random.Range(0.8f, 1.2f);
        int cri = Random.Range(0, 100);
        if (cri < playerState.cri)
            dmgRate = Random.Range(2f, 2.5f);

        damage = (int)((playerState.atk - (bossState.def * 0.5f) + skillPower) * dmgRate);
    }


    private void OnTriggerEnter(Collider other)
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
