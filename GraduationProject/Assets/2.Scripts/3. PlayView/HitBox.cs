using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitBox : MonoBehaviour
{
    public TextMeshProUGUI dmgText;
    public TextMeshProUGUI criText;

    EnemyController enemyController;
    PlayerState playerState;


    public float criDmg;
    public float superCriDmg;
    public bool hit;

    public string dmg;
    public string cri;

    private void Awake()
    {
        enemyController = GetComponentInParent<EnemyController>();
        playerState = FindObjectOfType<PlayerState>();
        criDmg = playerState.atk * 1.5f;
        superCriDmg = playerState.atk * 2.0f;



    }
    public void TakeDamage(int damage)
    {
        //체력이 감소되거나 애니메이션 재생되는 등의 코드를 작성
        BossState bossState = FindObjectOfType<BossState>();

        if (damage <= 0)
        {
            damage = 0;
        }

        bossState.hp_Cur -= damage;

        if (damage > 0)
        {
            dmg = string.Format("{0}", damage);
            dmgText.text = dmg;
        }
        if (damage >= criDmg && damage <superCriDmg)
        {
            criText.gameObject.SetActive(true);
            dmgText.color = Color.yellow;
            criText.color = Color.yellow;
            cri = string.Format("Critical!");
            criText.text = cri;
        }
        else if(damage >= superCriDmg)
        {
            criText.gameObject.SetActive(true);
            dmgText.color = Color.red;
            criText.color = Color.red;
            cri = string.Format("SuperCritical!!");
            criText.text = cri;
        }
        else
            dmgText.color = Color.white;

        dmgText.gameObject.SetActive(true);
        hit = true;

    }


}
