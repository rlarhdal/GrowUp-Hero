using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum alphaValue
{
    SHRINKING,
    GROWING
}

public class Blinking_Effect : MonoBehaviour
{
    public alphaValue currentAlphaValue;
    public float CommentMinAlpha;
    public float CommentMaxAlpha;
    public float CommentCurrentAlpha;

    public Text mytext;

    void Awake()
    {
        mytext = GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        CommentMinAlpha = 0.1f;
        CommentMaxAlpha = 2f;
        CommentCurrentAlpha = 1f;
        currentAlphaValue = alphaValue.SHRINKING;
    }

    // Update is called once per frame
    void Update()
    {
        AlphaComments();
    }

    public void AlphaComments()
    {
        if(currentAlphaValue == alphaValue.SHRINKING)
        {
            CommentCurrentAlpha = CommentCurrentAlpha - 0.001f;
            mytext.color = new Color(Color.black.r, Color.black.g, Color.black.b, CommentCurrentAlpha);
            if(CommentCurrentAlpha <= CommentMinAlpha)
            {
                currentAlphaValue = alphaValue.GROWING;
            }
        }
        else if (currentAlphaValue == alphaValue.GROWING)
        {
            CommentCurrentAlpha = CommentCurrentAlpha + 0.001f;
            mytext.color = new Color(Color.black.r, Color.black.g, Color.black.b, CommentCurrentAlpha);
            if (CommentCurrentAlpha >= CommentMaxAlpha)
            {
                currentAlphaValue = alphaValue.SHRINKING;
            }
        }
    }
}
