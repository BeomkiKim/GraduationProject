using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MonsterHitBox : MonoBehaviour
{
    public float criDmg;
    public float superCriDmg;
    public bool hit;

    public string dmg;
    public string cri;

    public TextMeshProUGUI dmgText;
    public TextMeshProUGUI criText;

    PlayerState playerState;

    private void Awake()
    {
        playerState = FindObjectOfType<PlayerState>();
        criDmg = playerState.atk * 1.5f;
        superCriDmg = playerState.atk * 2.0f;
    }

    public void TakeDamage(int damage)
    {
        MonsterState monsterState = transform.root.GetComponent<MonsterState>();

        //damage -= (int)monsterState.def;
        monsterState.hpCur -= damage;

        if (damage > 0)
        {
            dmg = string.Format("{0}", damage);
            dmgText.text = dmg;
        }
        if (damage >= criDmg && damage < superCriDmg)
        {
            criText.gameObject.SetActive(true);
            dmgText.color = Color.yellow;
            criText.color = Color.yellow;
            cri = string.Format("Critical!");
            criText.text = cri;
        }
        else if (damage >= superCriDmg)
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
