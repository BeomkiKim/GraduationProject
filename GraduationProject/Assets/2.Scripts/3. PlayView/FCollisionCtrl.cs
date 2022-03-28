using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FCollisionCtrl : MonoBehaviour
{
    public float skillPower;
    int damage;
    float dmgRate;
    public string dmg;
    Movement movement;
    PlayerController playerController;

    private void Awake()
    {
        movement = FindObjectOfType<Movement>();
        playerController = FindObjectOfType<PlayerController>();
    }



    void CalculateDmg()
    {
        PlayerState playerState = FindObjectOfType<PlayerState>();

        dmgRate = Random.Range(0.8f, 1.2f);
        int cri = Random.Range(0, 100);
        if (cri < playerState.cri)
            dmgRate = Random.Range(2f, 2.5f);


        damage = (int)((playerState.atk * skillPower) * dmgRate);
    }


    private void OnTriggerEnter(Collider other)
    {

        switch (other.gameObject.tag)
        {
            case "Ground":
                Destroy(gameObject);
                movement.moveSpeed = 5.0f;
                playerController.attacking = false;
                break;
            case "Boss":
                CalculateDmg();
                other.GetComponent<HitBox>().TakeDamage(damage);
                break;
            case "Monster":
                CalculateDmg();
                other.GetComponent<MonsterHitBox>().TakeDamage(damage);
                break;

        }
    }
}
