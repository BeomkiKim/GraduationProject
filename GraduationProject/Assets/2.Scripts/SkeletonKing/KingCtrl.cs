using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingCtrl : MonoBehaviour
{
    Animator kingAnimator;

    public GameObject AttackCollider;
    public GameObject firstSkillCollider;

    public GameObject hp_bar;

    public Transform target;
    bool enableAct;

    int atkStep;
    HitBox hitBox;


    public float bossSpeed;
    private SkinnedMeshRenderer meshRenderer;
    private Color originColor;
    BossState bossState;

    private void Awake()
    {
        bossState = GetComponent<BossState>();
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        originColor = meshRenderer.material.color;
        kingAnimator = GetComponent<Animator>();
        hitBox = GetComponentInChildren<HitBox>();
        //atkStep = 0;
        enableAct = true;

    }

    private void OnEnable()
    {
        hp_bar.SetActive(true);
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
        if ((target.position - transform.position).magnitude >= 10)
        {
            kingAnimator.SetBool("Walk", true);
            transform.Translate(Vector3.forward * bossSpeed * Time.deltaTime, Space.Self);
        }
        if ((target.position - transform.position).magnitude < 10)
        {
            kingAnimator.SetBool("Walk", false);
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
        if ((target.position - transform.position).magnitude < 10)
        {
            switch (atkStep)
            {
                case 0:
                    atkStep += 1;
                    kingAnimator.Play("Ready 1");
                    break;
                case 1:
                    atkStep += 1;
                    bossState.atk += 6;
                    kingAnimator.Play("Ready 2");
                    break;
                case 2:
                    atkStep = 0;
                    kingAnimator.Play("Ready 3");
                    break;
            }
        }
    }
    void FirstSkill()
    {
        firstSkillCollider.SetActive(true);
    }
    void OnAttackCollider()
    {
        AttackCollider.SetActive(true);
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
}
