using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryScene : MonoBehaviour
{
    public Text storyText;
    private string text = "붉다... ";
    public GameObject dontDestroy;
    public GameObject skipButton;

    bool isRealStart;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StoryStart");

        DontDestroyOnLoad(dontDestroy);


        GameObject[] audios = GameObject.FindGameObjectsWithTag("BGM");


        if (audios.Length >= 2)
        {
            Destroy(audios[1]);
        }
    }
    IEnumerator StoryStart()
    {

        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < text.Length; i++)
        {
            storyText.text = text.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }
        text = "눈에 보이는 모든 것이 붉다. ";
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < text.Length; i++)
        {
            storyText.text = text.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }

        skipButton.SetActive(true);
        text = "이제 이곳에 남은 것은 죽음 뿐이다. ";
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < text.Length; i++)
        {
            storyText.text = text.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }

        text = "사형..사질들..모두 죽었다. ";
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < text.Length; i++)
        {
            storyText.text = text.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }
        text = "구파 일방을 비롯한 이십여 개의 문파, ";
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < text.Length; i++)
        {
            storyText.text = text.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }
        text = "정예 중의 정예들로 구성된 최후의 결사대 ";
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < text.Length; i++)
        {
            storyText.text = text.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }
        text = "그 모두와 천마의 격돌은 결국 공멸이라는 결과를 낳았다. ";
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < text.Length; i++)
        {
            storyText.text = text.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }
        text = "누구 때문인가...? ";
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < text.Length; i++)
        {
            storyText.text = text.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }

        text = "저 자 때문이었다...";
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < text.Length; i++)
        {
            storyText.text = text.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }
        text = "하늘이 내린 악마! ";
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < text.Length; i++)
        {
            storyText.text = text.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }
        text = "천하를 피로 물들인 악귀의 집단! 마교의 교주! ";
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < text.Length; i++)
        {
            storyText.text = text.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }

        text = "천    마 ";
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < text.Length; i++)
        {
            storyText.text = text.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }
        RealStart();

    }


    void RealStart()
    {

       isRealStart = true;
        ClickSkip();
  
    }

    public void ClickSkip()
    {
        SceneManager.LoadScene("Boss", LoadSceneMode.Single);
    }
}
