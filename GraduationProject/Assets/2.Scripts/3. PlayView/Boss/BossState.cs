using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;


public class BossState : MonoBehaviour
{
    public float hp;
    public float hp_Cur;

    public float atk;
    public float def;
    public float cri;

    public float exp;

    PlayerState playerState;

    public GameObject[] comunityObj;

    public Image hpBar_Front;
    public Image hpBar_Back;
    public GameObject hp_bar;

    Animator anim;

    bool isDied;

    private void Start()
    {
        hp_bar.SetActive(true);
        hp_Cur = hp;
        anim = GetComponent<Animator>();
        playerState = FindObjectOfType<PlayerState>();

    }

    void SyncBar()
    {
        hpBar_Front.fillAmount = hp_Cur / hp;

        if (hpBar_Back.fillAmount > hpBar_Front.fillAmount)
        {
            hpBar_Back.fillAmount = Mathf.Lerp(hpBar_Back.fillAmount, hpBar_Front.fillAmount, Time.deltaTime);

        }
    }
    private void Update()
    {
        SyncBar();

        if (hp_Cur <= 0f)
        {
            StartCoroutine("Died");
            Debug.Log("Á×À½");
            
            hp_Cur = 0f;
            playerState.expCur += exp;
            if (comunityObj.Length == 0)
                return;
            comunityObj[0].SetActive(false);
            comunityObj[1].SetActive(true);
            comunityObj[2].SetActive(false);
        }
    }

    IEnumerator Died()
    {
        anim.SetBool("Die", true);
        Debug.Log("Die");
        yield return new WaitForSeconds(3f);
        hp_bar.SetActive(false);
        gameObject.SetActive(false);
        //yield return new WaitForSeconds(5f);
        //SceneManager.LoadScene("MainScene", LoadSceneMode.Single);

    }

}
