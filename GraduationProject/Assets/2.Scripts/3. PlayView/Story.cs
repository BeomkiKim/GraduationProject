using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    private Text text;
    public float colorSpeed;
    
    void Start()
    {
        text = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        text.color = Vector4.Lerp(text.color, new Vector4(1, 1, 1, 0), Time.deltaTime * colorSpeed);

        if (text.color.a <= 0.05f)
        {
            Destroy(gameObject);
        }
    }


}
