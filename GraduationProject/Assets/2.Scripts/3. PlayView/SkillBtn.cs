using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBtn : MonoBehaviour
{ 
    float qCooldown;
    float eCooldown;
    float fCooldown;
    float rCooldown;

    public float qCoolTime;
    public float eCoolTime;
    public float fCoolTime;
    public float rCoolTime;

    public float qCost;
    public float eCost;
    public float fCost;
    public float rCost;

    public Image qImg;
    public Image eImg;
    public Image fImg;
    public Image rImg;

    public bool isQCool;
    public bool isECool;
    public bool isFCool;
    public bool isRCool;

    public void UseSkillQ()
    {
        if (!isQCool)
        {
            isQCool = true;
            StartCoroutine("QCoolDown");
        }
    }
    IEnumerator QCoolDown()
    {
        qCooldown = 0;

        while (true)
        {
            qCooldown += Time.deltaTime;
            qImg.fillAmount = qCooldown / qCoolTime;

            if (isQCool)
            {
                if (qCooldown >= qCoolTime)
                {
                    isQCool = false;
                    StopCoroutine("QCoolDown");
                }
            }
            yield return null;
        }
    }



    public void UseSkillE()
    {
        if (!isECool)
        {
            isECool = true;
            StartCoroutine("ECoolDown");
        }

    }
    IEnumerator ECoolDown()
    {
        eCooldown = 0;

        while (true)
        {
            eCooldown += Time.deltaTime;
            eImg.fillAmount = eCooldown / eCoolTime;
            
            if (isECool)
            {
                if (eCooldown >= eCoolTime)
                {
                    isECool = false;
                    StopCoroutine("ECoolDown");
                }
            }
            yield return null;
        }
    }
    public void UseSkillF()
    {
        if (!isFCool)
        {
            isFCool = true;
            StartCoroutine("FCoolDown");
        }

    }
    IEnumerator FCoolDown()
    {
        fCooldown = 0;

        while (true)
        {
            fCooldown += Time.deltaTime;
            fImg.fillAmount = fCooldown / fCoolTime;

            if (isFCool)
            {
                if (fCooldown >= fCoolTime)
                {
                    isFCool = false;
                    StopCoroutine("FCoolDown");
                }
            }
            yield return null;
        }
    }
    public void UseSkillR()
    {
        if (!isRCool)
        {
            isRCool = true;
            StartCoroutine("RCoolDown");
        }

    }
    IEnumerator RCoolDown()
    {
        rCooldown = 0;

        while (true)
        {
            rCooldown += Time.deltaTime;
            rImg.fillAmount = rCooldown / rCoolTime;

            if (isRCool)
            {
                if (rCooldown >= rCoolTime)
                {
                    isRCool = false;
                    StopCoroutine("RCoolDown");
                }
            }
            yield return null;
        }

    }


}
