using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemCtrl : MonoBehaviour
{
    [SerializeField]
    private GameObject attackCollision;

    Animator golemAnimation;
    public Transform target;
    bool enableAct;



    public float golemSpeed;





    private void Awake()
    {
        golemSpeed = Random.Range(1.3f, 2.3f);
        golemAnimation = GetComponent<Animator>();
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
            transform.Translate(Vector3.forward * golemSpeed * Time.deltaTime, Space.Self);
        }
        if ((target.position - transform.position).magnitude <= 1.2f)
        {
            golemAnimation.Play("Attack");
        }
        if((target.position - transform.position).magnitude == 2.0f)
        {
            golemAnimation.Play("Rage");
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
