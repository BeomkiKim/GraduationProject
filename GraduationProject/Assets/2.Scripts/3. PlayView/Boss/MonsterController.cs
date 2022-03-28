using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField]
    private GameObject attackCollision;
    Animator anim;
    public Transform target;

    MonsterHitBox monsterHitBox;
    EnemyController bossController;

    public float speed;
    private SkinnedMeshRenderer meshRenderer;
    private Color originColor;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        monsterHitBox = GetComponentInChildren<MonsterHitBox>();
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        bossController = FindObjectOfType<EnemyController>();
       
        originColor = meshRenderer.material.color;
        target = bossController.target;

    }

    private void Update()
    {

        RotateMonster();
        MoveMonster();
        AttackMonster();

        if (monsterHitBox.hit)
        {
            //색상 변경
            StartCoroutine("OnHitColor");
        }
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
        }
    }

    void AttackMonster()
    {
        if ((target.position - transform.position).magnitude < 2)
        {
            anim.Play("Attack");
        }
    }
    private IEnumerator OnHitColor()
    {
        meshRenderer.material.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        meshRenderer.material.color = originColor;
        monsterHitBox.hit = false;
    }

    public void onAttackCollision()
    {
        attackCollision.SetActive(true);
    }
}
