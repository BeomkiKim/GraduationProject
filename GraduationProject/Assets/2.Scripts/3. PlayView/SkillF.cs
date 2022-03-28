using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkillF : MonoBehaviour
{
    public GameObject fSkillObj;

    IEnumerator ResetSkill(GameObject fSkillObj)
    {

        yield return new WaitForSeconds(8.0f);

        // 스킬 비활성화
        gameObject.SetActive(false);
    }

    private void Update()
    {
        StartCoroutine(ResetSkill(fSkillObj));
    }
}
