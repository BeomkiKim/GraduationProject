using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]
    private GameObject attackCollision;
    private Animator animator;

    PlayerController playerController;
    Movement movement;

    [HideInInspector]
    public bool isDied;
    // Start is called before the first frame update


    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        movement = GetComponent<Movement>();
    }

    public void onMovement(float horizontal, float vertical)
    {
        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);
    }

    public void onWeaponAttack()
    {
        animator.SetTrigger("onWeaponAttack");

    }

    void startAttack()
    {
        playerController.attacking = true;
        movement.moveSpeed = 1.0f;
    }

    void finishAttack()
    {
        playerController.attacking = false;
        movement.moveSpeed = 5.0f;
    }

    void startSkill()
    {
        playerController.attacking = true;
        movement.moveSpeed = 0.0f;
    }
    void finishSkill()
    {
        playerController.attacking = false;
        movement.moveSpeed = 5.0f;
    }
    void stunStart()
    {
        movement.moveSpeed = 0.0f;
    }
    void stunFinish()
    {
        movement.moveSpeed = 7.0f;
    }

    public void onSkillAttackQ()
    {
        animator.SetTrigger("onSkillAttackQ");
    }
    public void onSkillAttackE()
    {
        animator.SetTrigger("onSkillAttackE");
    }
    public void onSkillAttackF()
    {
        animator.SetTrigger("onSkillAttackF");
    }

    public void onSkillAttackR()
    {
        animator.SetTrigger("onSkillAttackR");
    }

    public void OnAttackCollision()
    {
        attackCollision.SetActive(true);
    }
}
