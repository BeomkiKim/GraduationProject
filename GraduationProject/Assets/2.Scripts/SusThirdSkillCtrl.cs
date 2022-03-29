using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusThirdSkillCtrl : MonoBehaviour
{
    public GameObject susSkillObj;
    public float speed;
    private void OnEnable()
    {

        StartCoroutine("ThirdSkill");


    }

    IEnumerator ThirdSkill()
    {
        yield return new WaitForSeconds(2.0f);

        while (true)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            yield return null;
        }

    }

    IEnumerator ResetSkill(GameObject susSkillObj)
    {

        yield return new WaitForSeconds(10.0f);


        gameObject.SetActive(false);
    }

    private void Update()
    {
        StartCoroutine(ResetSkill(susSkillObj));
    }
}
