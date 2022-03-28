using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossColliderScale : MonoBehaviour
{
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
            timer += Time.deltaTime * 2.5f;
            Scaling(new Vector3(timer * 5f, timer * 5f, timer * 5f));
            yield return null;
        }

    }
    void CalculateDmg()
    {
        BossState bossState = FindObjectOfType<BossState>();
        PlayerState playerState = FindObjectOfType<PlayerState>();


        dmgRate = Random.Range(0.8f, 1.2f);
        int cri = Random.Range(0, 100);
        if (cri < bossState.cri)
            dmgRate = Random.Range(2f, 2.5f);

        damage = (int)((bossState.atk-(playerState.def*0.5) + skillPower) * dmgRate);
    }

    IEnumerator ResetRskill()
    {

        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);

    }

    private void OnTriggerStay(Collider other)
    {

        if(other.gameObject.tag == "PlayerHit")
        {
            CalculateDmg();
            other.GetComponent<PlayerHit>().TakeDamage(damage);
        }
    }
}
