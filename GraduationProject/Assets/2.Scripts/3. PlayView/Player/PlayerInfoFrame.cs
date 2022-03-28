using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoFrame : MonoBehaviour
{
    public PlayerState player;

    public Text lev;
    public Text hp;
    public Text mp;
    public Text atk;
    public Text def;
    public Text cri;
    public Image expBar;


    private void Update()
    {
        lev.text = player.lev.ToString();
        hp.text = player.hp.ToString();
        mp.text = player.mp.ToString();
        atk.text = player.atk.ToString();
        def.text = player.def.ToString();
        cri.text = string.Format("{0:0.00}", player.cri);

        expBar.fillAmount = player.expCur / player.maxExp;


    }
}
