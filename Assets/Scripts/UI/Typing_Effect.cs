using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typing_Effect : MonoBehaviour
{
    public Text txt;
    public float delaySpeed;

    string dialogue;

    void Awake()
    {
        txt = GetComponent<Text>();
        dialogue = txt.text;

        //코루틴 호출
        StartCoroutine(Typing(dialogue));
    }

    //타이핑 딜레이를 위한 코루틴
    IEnumerator Typing(string title)
    {
        txt.text = null;
        for(int i = 0; i < title.Length; i++)
        {
            yield return new WaitForSeconds(delaySpeed);
            txt.text += title[i];
        }
    }

}
