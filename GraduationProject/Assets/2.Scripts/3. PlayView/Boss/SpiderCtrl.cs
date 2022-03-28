using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderCtrl : MonoBehaviour
{
    [SerializeField]
    private GameObject attackCollision;

    Animator spiderAnimation;
    public Transform target;
    bool enableAct;



    public float bossSpeed;





    private void Awake()
    {
        bossSpeed = Random.Range(1.3f, 2.3f);
        spiderAnimation = GetComponent<Animator>();
        target = FindObjectOfType<TargetManager>().target;
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
        if ((target.position - transform.position).magnitude > 1.2f)
        {
            transform.Translate(Vector3.forward * bossSpeed * Time.deltaTime, Space.Self);
        }
        if ((target.position - transform.position).magnitude <= 1.2f)
        {
            spiderAnimation.Play("Attack");
        }
    }

    private void Update()
    {
        if (enableAct)
        {
            RotateBoss();
            MoveBoss();
        }
    }
    public void onAttackCollision()
    {
        attackCollision.SetActive(true);
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
