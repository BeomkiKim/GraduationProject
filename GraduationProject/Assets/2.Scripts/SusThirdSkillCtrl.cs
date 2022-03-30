using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusThirdSkillCtrl : MonoBehaviour
{
    public GameObject susSkillObj;
    public float speed;
    public int damage;
    float dmgRate;
    BossState bossState;

    private void OnEnable()
    {
        bossState = FindObjectOfType<BossState>();
        StartCoroutine("ThirdSkill");


    }

    IEnumerator ThirdSkill()
    {
        yield return new WaitForSeconds(2.0f);

        while (true)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            yield return null;
        }

    }

    IEnumerator ResetSkill(GameObject susSkillObj)
    {

        yield return new WaitForSeconds(10.0f);


        gameObject.SetActive(false);
    }

    private void setDamage()
    {
        dmgRate = Random.Range(0.8f, 1.2f);
        int cri = Random.Range(0, 100);
        if (cri < bossState.cri)
            dmgRate = Random.Range(2f, 2.5f);

        damage = (int)(bossState.atk * dmgRate * 7);
    }

    private void Update()
    {
        StartCoroutine(ResetSkill(susSkillObj));
        setDamage();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHit"))
        {
            other.GetComponent<PlayerHit>().TakeDamage(damage);
        }
        if (other.tag == "Ground")
        {
            gameObject.SetActive(false);
        }
    }
}
