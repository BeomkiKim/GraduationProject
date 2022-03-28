using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCtrl : MonoBehaviour
{
    [SerializeField]
    private GameObject[] attackCollision;
    public Transform target;
    public float bossSpeed;
    Animator animator;

    bool enableAct;


    private void Awake()
    {
        target = null;
        enableAct = true;
        animator = GetComponent<Animator>();

    }
    private void Update()
    {
        if (enableAct && target != null)
        {
            RotateBoss();
            MoveBoss();
        }
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
        if ((target.position - transform.position).magnitude > 1)
        {
            animator.Play("Walk");
            transform.Translate(Vector3.forward * bossSpeed * Time.deltaTime, Space.Self);
        }
        if ((target.position - transform.position).magnitude <= 1f)
        {
            animator.Play("Attack");
        }
    }

    public void onLAttackCollision()
    {
        attackCollision[1].SetActive(true);
    }
    public void onRAttackCollision()
    {
        attackCollision[0].SetActive(true);
    }
    void FreezeBoss()
    {
        enableAct = false;
    }
    void UnFreezeBoss()
    {
        enableAct = true;
    }
}
