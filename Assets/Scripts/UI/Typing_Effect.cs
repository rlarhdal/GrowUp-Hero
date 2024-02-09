using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typing_Effect : MonoBehaviour
{
    public Text txt;
    public float delaySpeed;

    string dialogue;

    // Start is called before the first frame update
    void Awake()
    {
        txt = GetComponent<Text>();
        dialogue = txt.text;

        StartCoroutine(Typing(dialogue));
    }

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
