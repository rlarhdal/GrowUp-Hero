using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneManager : MonoBehaviour
{
    [SerializeField]
    Image progressBar;
    SpriteRenderer render1;
    SpriteRenderer render2;

    public static string nextScene;
    public GameObject obj1;
    public GameObject obj2;

    void Awake()
    {
        render1 = obj1.GetComponent<SpriteRenderer>();
        render2 = obj2.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        StartCoroutine(LoadScene());
    }

    //�� �ѱ��
    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    //���ε� �ڷ�ƾ
    IEnumerator LoadScene()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0.0f;

        //��������Ʈ color�� ��������
        Color color1 = render1.color;
        Color color2 = render2.color;

        while (!op.isDone)
        {
            timer =+ Time.time;
            progressBar.fillAmount = timer/5f;

            //��������Ʈ alpha�� ����
            color1.a = progressBar.fillAmount;
            color2.a = progressBar.fillAmount;
            render1.color = color1;
            render2.color = color2;

            if (timer > 5)
            {
                op.allowSceneActivation = true;
            }

            yield return null;

            /* 
            //���� �� �ε� �ð��� ���� ����
            //���� Ŀ���� �� �������� ����
            timer += Time.deltaTime;
            if(op.progress < 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
                if(progressBar.fillAmount >= op.progress)
                    timer = 0f;
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);

                //��� alpha�� ����
                Color color1 = render1.color;
                Color color2 = render2.color;
                color1.a -= progressBar.fillAmount;
                color2.a -= progressBar.fillAmount;
                render1.color = color1;
                render2.color = color2;

                if (progressBar.fillAmount == 1.0f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }

            }*/
        }
    }
}
