using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusSkillCtrl : MonoBehaviour
{
    public float downSpeed;
    //public float forwardSpeed;
    private void OnEnable()
    {
        gameObject.transform.rotation = Quaternion.Euler(-45, 0, 0); //각도 수정 필요
        StartCoroutine("SecondeSkill");
    }

    IEnumerator SecondeSkill()
    {
        yield return new WaitForSeconds(2.0f);

        while (true)
        {
            //transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
            transform.Translate(Vector3.down * downSpeed * Time.deltaTime);
            yield return null;
        }

    }
}
