using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusSkillCtrl : MonoBehaviour
{
    public float downSpeed;
    public float forwardSpeed;
    public int damage;
    float dmgRate;
    BossState bossState;
    private void OnEnable()
    {
        bossState = FindObjectOfType<BossState>();
        StartCoroutine("SecondeSkill");
    }
    private void Update()
    {
        setDamage();

    }
    private void setDamage()
    {
        dmgRate = Random.Range(0.8f, 1.2f);
        int cri = Random.Range(0, 100);
        if (cri < bossState.cri)
            dmgRate = Random.Range(2f, 2.5f);

        damage = (int)(bossState.atk * dmgRate * 7);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHit"))
        {
            other.GetComponent<PlayerHit>().TakeDamage(damage);
        }
        if(other.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
    IEnumerator SecondeSkill()
    {
        yield return new WaitForSeconds(2.0f);

        while (true)
        {
            transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
            transform.Translate(Vector3.down * downSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
