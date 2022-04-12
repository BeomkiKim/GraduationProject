using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenBloodCtrl : MonoBehaviour
{
    public Image bloodImage;
    float time = 0f;
    float fadeTime = 1f;
    float resetTime = 0.01f;

    private void OnEnable()
    {
        //Color startAlpha = bloodImage.color;
        //startAlpha.a = 1f;

        StartCoroutine("HitEffect");
    }

    IEnumerator HitEffect()
    {
        time = 0f;
        Color alpha = bloodImage.color;
        while (alpha.a == 0f)
        {
            time += Time.deltaTime / resetTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            bloodImage.color = alpha;
            yield return null;
        }

        yield return new WaitForSeconds(1.5f);

        time = 0f;
        while(alpha.a > 0f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(1, 0, time);
            bloodImage.color = alpha;
            yield return null;
        }
        yield return new WaitForSeconds(1.0f);
        gameObject.SetActive(false);

    }
}
