using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusCtrl : MonoBehaviour
{
    Animator susAnimator;
    PlayerState playerState;
    public Transform sus;

    //public GameObject hp_bar;

    public Transform target;
    bool enableAct;

    int atkStep;
    HitBox hitBox;
    public float bossSpeed;

    [Header("스킬")]
    public GameObject firstSkill;
    public GameObject[] secondSkill;
    public GameObject thirdSkill;




    private SkinnedMeshRenderer meshRenderer;
    private Color originColor;
    BossState bossState;

    private void Awake()
    {
        bossState = GetComponent<BossState>();
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        playerState = FindObjectOfType<PlayerState>();
        originColor = meshRenderer.material.color;
        susAnimator = GetComponent<Animator>();
        hitBox = GetComponentInChildren<HitBox>();
        atkStep = 0;
        enableAct = true;

    }

    //private void OnEnable()
    //{
    //    hp_bar.SetActive(true);
    //}
    void RotateBoss()
    {
        Vector3 dir = target.position - transform.position;

        transform.localRotation =
            Quaternion.Slerp(transform.localRotation,
            Quaternion.LookRotation(dir), 5 * Time.deltaTime);
    }

    void MoveBoss()
    {
        if ((target.position - transform.position).magnitude >= 20)
        {
            susAnimator.SetBool("Walk", true);
            transform.Translate(Vector3.forward * bossSpeed * Time.deltaTime, Space.Self);
        }
        if ((target.position - transform.position).magnitude < 20)
        {
            susAnimator.SetBool("Walk", false);
        }
    }

    private void Update()
    {
        if (enableAct)
        {
            RotateBoss();
            MoveBoss();
            BossAtk();
        }
        if (hitBox.hit)
        {
            StartCoroutine("OnHitColor");
        }
    }

    void BossAtk()
    {
        if ((target.position - transform.position).magnitude < 20)
        {
            switch (atkStep)
            {
                case 0:
                    atkStep += 1;
                    //Debug.Log("1스킬사용");
                    susAnimator.Play("Ready 1");
                    StartCoroutine("FirstSkill");
                    break;
                case 1:
                    atkStep += 1;
                    susAnimator.Play("Ready 2");
                    break;
                case 2:
                    atkStep = 0;
                    susAnimator.Play("Ready 3");
                    StartCoroutine("ThirdSkill");
                    break;
            }
        }
    }
    //void OnAttackCollider()
    //{
    //    AttackCollider.SetActive(true);
    //}
    void FreezeBoss()
    {
        enableAct = false;
    }
    void UnFreezeBoss()
    {
        enableAct = true;
    }
    void Poison()
    {
        if ((target.position - transform.position).magnitude < 65)
        {
            playerState.SendMessage("Poison");
        }
    }
    void Stun()
    {
        playerState.SendMessage("Stun");
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
        yield return new WaitForSeconds(1.0f);
        firstSkill.SetActive(true);
        yield return new WaitForSecondsRealtime(15.0f);
        firstSkill.SetActive(false);
    }
    IEnumerator SecondSkill()
    {
        for (int secondSkillCount = 0; secondSkillCount < secondSkill.Length; secondSkillCount++)
        {
            secondSkill[secondSkillCount].SetActive(true);
        }
        yield return new WaitForSecondsRealtime(10.0f);
        for (int secondSkillCount = 0; secondSkillCount < secondSkill.Length; secondSkillCount++)
        {
            secondSkill[secondSkillCount].SetActive(false);
        }
    }
    IEnumerator ThirdSkill()
    {
        thirdSkill.transform.position = sus.transform.position + new Vector3(0, 3, 5);
        thirdSkill.transform.rotation = sus.transform.rotation;
        yield return new WaitForSecondsRealtime(3.0f);
        thirdSkill.SetActive(true);

    }
}
