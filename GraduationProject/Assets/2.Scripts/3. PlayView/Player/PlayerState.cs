using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
    public int lev;
    public float hp;
    public float mp;
    public int atk;
    public int def;
    public float cri;
    public float maxExp;
    //public int clearCount;

    public float expCur;
    public float hpCur;
    public float mpCur;
    float poisonDmg = 0.04f;
    
    //public int atkPower;
    //public float crticalRate;


    public Image hpBar_Front;
    public Image hpBar_Back;
    public Image mpBar_Front;
    public Image mpBar_Back;
    Animator anim;
    PlayerHit playerHit;
    CameraController cameraController;
    public bool stopMove = false;

    public bool isDie = false;

    public void SavePlayer()
    {
        SaveData save = new SaveData();
        save.Level = lev;
        save.HP = hp;
        save.MP = mp;
        save.ATK = atk;
        save.DEF = def;
        save.CRI = cri;
        save.MAXEXP = maxExp;
        save.EXPCUR = expCur;
        save.HPCUR = hpCur;
        save.MPCUR = mpCur;
        //save.CLEARCOUNT = clearCount;

        SaveManager.Save(save);
        SceneManager.LoadScene("StageSelect", LoadSceneMode.Single);
    }

    public void ResetPlayer()
    {
        SaveData save = new SaveData();
        save.Level = 1;
        save.HP = 500f;
        save.MP = 50f;
        save.ATK = 100;
        save.DEF = 50;
        save.CRI = 0.25f;
        save.MAXEXP = 100f;
        save.EXPCUR = 0f;
        save.HPCUR = 500f;
        save.MPCUR = 50f;
        //save.CLEARCOUNT = 0;

        SaveManager.Save(save);
        LoadPlayer();

    }

    public void LoadPlayer()
    {
        SaveData save = SaveManager.Load();
        Time.timeScale = 1;
        lev = save.Level;
        hp = save.HP ;
        mp = save.MP;
        atk = save.ATK;
        def = save.DEF;
        cri = save.CRI;
        maxExp = save.MAXEXP;
        expCur = save.EXPCUR;
        hpCur = save.HPCUR;
        mpCur = save.MPCUR;
        //clearCount = save.CLEARCOUNT;

    }


    private void Awake()
    {
       hpCur = hp;
       mpCur = mp;
       anim = GetComponent<Animator>();
       playerHit = FindObjectOfType<PlayerHit>();
       cameraController = FindObjectOfType<CameraController>();


    }

    void SyncBar()
    {
        hpBar_Front.fillAmount = hpCur / hp;

        if (hpBar_Back.fillAmount > hpBar_Front.fillAmount)
        {
            hpBar_Back.fillAmount = Mathf.Lerp(hpBar_Back.fillAmount, hpBar_Front.fillAmount, Time.deltaTime);

        }
        mpBar_Front.fillAmount = mpCur / mp;

        if (mpBar_Back.fillAmount > mpBar_Front.fillAmount)
        {
            mpBar_Back.fillAmount = Mathf.Lerp(mpBar_Back.fillAmount, mpBar_Front.fillAmount, Time.deltaTime);

        }
    }
    void Update()
    {
        SyncBar();
        if (hpCur <= playerHit.dmg)
        {
            hpCur = 0f;
            mpCur = 0f;
            isDie = true;
            cameraController.sensitiveity = 0f;
            StartCoroutine("Died");
        }
        if (expCur >= maxExp)
        {
            print("Level Up");
            lev += 1;
            hp += 150f;
            hpCur += hp;
            mp += 100f;
            atk += 50;
            mpCur += mp;
            maxExp += maxExp;
        }
        if (hpCur > hp)
        {
            hpCur -= (hpCur - hp);
        }
        if (mpCur > mp)
        {
            mpCur -= (mpCur - mp);
        }

    }

    public void GetHp(int damage)
    {
        if(hpCur<hp)
            hpCur += damage * 0.0005f;
        if(mpCur<mp)
            mpCur += damage * 0.0005f;
    }

    public void Poison()
    {
        StartCoroutine("PoisonDot");
    }

    IEnumerator Died()
    {
        anim.SetTrigger("onDied");
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("StartScene", LoadSceneMode.Single);

    }

    IEnumerator PoisonDot()
    {
        hpCur -= hpCur * poisonDmg;
        yield return new WaitForSecondsRealtime(2.0f);
        hpCur -= hpCur * poisonDmg;
        yield return new WaitForSecondsRealtime(2.0f);
        hpCur -= hpCur * poisonDmg;
        yield return new WaitForSecondsRealtime(2.0f);
        hpCur -= hpCur * poisonDmg;
        yield return new WaitForSecondsRealtime(2.0f);
        hpCur -= hpCur * poisonDmg;
        yield return new WaitForSecondsRealtime(2.0f);
        hpCur -= hpCur * poisonDmg;
        yield return new WaitForSecondsRealtime(2.0f);
        hpCur -= hpCur * poisonDmg;
        yield return new WaitForSecondsRealtime(2.0f);
        hpCur -= hpCur * poisonDmg;
        yield return new WaitForSecondsRealtime(2.0f);
        hpCur -= hpCur * poisonDmg;
        yield return new WaitForSecondsRealtime(2.0f);
        hpCur -= hpCur * poisonDmg;
    }
}
