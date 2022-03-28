using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlotState : MonoBehaviour
{
    public Image qImg;
    public Image fImg;
    public Image rImg;

    private Color qOriginColor;
    private Color fOriginColor;
    private Color rOriginColor;


    SkillBtn skill;
    PlayerState playerState;

    private void Awake()
    {
        qOriginColor = qImg.color;
        fOriginColor = fImg.color;
        rOriginColor = rImg.color;

        skill = FindObjectOfType<SkillBtn>();
        playerState = FindObjectOfType<PlayerState>();
    }
    void Update()
    {
        //Q
        if (skill.qCost > playerState.mpCur || playerState.lev < 2)
        {
            qImg.color = Color.red;
        }
        else
        {
            qImg.color = qOriginColor;
        }

        //F
        if (skill.fCost > playerState.mpCur || playerState.lev < 3)
        {
            fImg.color = Color.red;
        }
        else
        {
            fImg.color = fOriginColor;
        }

        //R
        if (skill.rCost > playerState.mpCur || playerState.lev < 4)
        {
            rImg.color = Color.red;
        }
        else
        {
            rImg.color = rOriginColor;
        }
    }
}
