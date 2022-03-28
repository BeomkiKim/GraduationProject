using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyController : MonoBehaviour
{
    Animator bossAnimator;

    public Transform target;
    bool enableAct;

    int atkStep;
    HitBox hitBox;

    [HideInInspector]
    public bool startSkill;

    public float bossSpeed;
    private SkinnedMeshRenderer meshRenderer;
    private Color originColor;

    public GameObject firstSkill;

    public GameObject monsterSpawnPoint;



    private void Awake()
    {
 
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        originColor = meshRenderer.material.color;
        bossAnimator = GetComponent<Animator>();
        hitBox = GetComponentInChildren<HitBox>();
        enableAct = true;

    }
    void RotateBoss()
    {
        Vector3 dir = target.position - transform.position;

        transform.localRotation =
            Quaternion.Slerp(transform.localRotation,
            Quaternion.LookRotation(dir), 5 * Time.deltaTime);
    }

    void MoveBoss()
    {
        if((target.position - transform.position).magnitude>=15)
        {
            bossAnimator.SetBool("Walk", true);
            transform.Translate(Vector3.forward * bossSpeed * Time.deltaTime, Space.Self);
        }
        if((target.position - transform.position).magnitude < 15)
        {
            bossAnimator.SetBool("Walk", false);
        }
    }

    private void Update()
    {
        if (enableAct)
        {
            RotateBoss();
            MoveBoss();
        }
        if (hitBox.hit)
        {
            StartCoroutine("OnHitColor");
        }
    }

    void BossAtk()
    {
        if((target.position - transform.position).magnitude < 15)
        {
            switch(atkStep)
            {
                case 0:
                    atkStep += 1;   
                    bossAnimator.Play("Ready1");
                    StartCoroutine("FirstSkill");
                    break;
                case 1:
                    atkStep = 0;
                    bossAnimator.Play("Ready3");
                    StartCoroutine("ThirdSkill");
                    break;
            }
        }
    }

    void FreezeBoss()
    {
        enableAct = false;
    }
    void UnFreezeBoss()
    {
        enableAct = true;
    }


    private IEnumerator OnHitColor()
    {
        meshRenderer.material.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        meshRenderer.material.color = originColor;
        hitBox.hit = false;
    }

    IEnumerator FirstSkill()
    {
        yield return new WaitForSeconds(4f);
        startSkill = true;
        firstSkill.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        startSkill = false;
        firstSkill.SetActive(false);
    }

    IEnumerator ThirdSkill()
    {

        yield return new WaitForSeconds(6.5f);
        monsterSpawnPoint.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        monsterSpawnPoint.SetActive(false);
    }
   
}
