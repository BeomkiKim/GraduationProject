using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkillF : MonoBehaviour
{
    public GameObject fSkillObj;

    IEnumerator ResetSkill(GameObject fSkillObj)
    {

        yield return new WaitForSeconds(8.0f);

        // ��ų ��Ȱ��ȭ
        gameObject.SetActive(false);
    }

    private void Update()
    {
        StartCoroutine(ResetSkill(fSkillObj));
    }
}
