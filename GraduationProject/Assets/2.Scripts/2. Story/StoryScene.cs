using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryScene : MonoBehaviour
{
    public Text storyText;
    private string text = "�Ӵ�... ";
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
        text = "���� ���̴� ��� ���� �Ӵ�. ";
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < text.Length; i++)
        {
            storyText.text = text.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }

        skipButton.SetActive(true);
        text = "���� �̰��� ���� ���� ���� ���̴�. ";
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < text.Length; i++)
        {
            storyText.text = text.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }

        text = "����..������..��� �׾���. ";
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < text.Length; i++)
        {
            storyText.text = text.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }
        text = "���� �Ϲ��� ����� �̽ʿ� ���� ����, ";
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < text.Length; i++)
        {
            storyText.text = text.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }
        text = "���� ���� ������� ������ ������ ���� ";
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < text.Length; i++)
        {
            storyText.text = text.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }
        text = "�� ��ο� õ���� �ݵ��� �ᱹ �����̶�� ����� ���Ҵ�. ";
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < text.Length; i++)
        {
            storyText.text = text.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }
        text = "���� �����ΰ�...? ";
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < text.Length; i++)
        {
            storyText.text = text.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }

        text = "�� �� �����̾���...";
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < text.Length; i++)
        {
            storyText.text = text.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }
        text = "�ϴ��� ���� �Ǹ�! ";
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < text.Length; i++)
        {
            storyText.text = text.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }
        text = "õ�ϸ� �Ƿ� ������ �Ǳ��� ����! ������ ����! ";
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < text.Length; i++)
        {
            storyText.text = text.Substring(0, i);

            yield return new WaitForSeconds(0.15f);
        }

        text = "õ    �� ";
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
