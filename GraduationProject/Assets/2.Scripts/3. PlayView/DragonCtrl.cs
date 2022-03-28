using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonCtrl : MonoBehaviour
{
    //[SerializeField]
    //private GameObject attackCollision;
    Animator anim;
    public Transform target;
    bool enableAct;

    //MonsterHitBox monsterHitBox;

    public float speed;
    private SkinnedMeshRenderer meshRenderer;
    private Color originColor;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        //monsterHitBox = GetComponentInChildren<MonsterHitBox>();
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();

        originColor = meshRenderer.material.color;
        enableAct = true;

    }


    void RotateMonster()
    {
        Vector3 dir = target.position - transform.position;

        transform.localRotation =
            Quaternion.Slerp(transform.localRotation,
            Quaternion.LookRotation(dir), 5 * Time.deltaTime);
    }

    void MoveMonster()
    {
        if ((target.position - transform.position).magnitude >= 2)
        {
            anim.SetBool("Walk", true);
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        }
        if ((target.position - transform.position).magnitude < 2)
        {
            anim.SetBool("Walk", false);
            anim.Play("Attack");
        }
    }

    private void Update()
    {

        if (enableAct)
        {
            RotateMonster();
            MoveMonster();
        }

        

        //if (monsterHitBox.hit)
        //{
        //    //색상 변경
        //    StartCoroutine("OnHitColor");
        //}
    }
    void AttackMonster()
    {
        if ((target.position - transform.position).magnitude < 2)
        {
            anim.SetTrigger("Attack");
        }
    }
    private IEnumerator OnHitColor()
    {
        meshRenderer.material.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        meshRenderer.material.color = originColor;
        //monsterHitBox.hit = false;
    }

    void FreezeBoss()
    {
        enableAct = false;
    }
    void UnFreezeBoss()
    {
        enableAct = true;
    }

    //public void onAttackCollision()
    //{
    //    attackCollision.SetActive(true);
    //}
}
