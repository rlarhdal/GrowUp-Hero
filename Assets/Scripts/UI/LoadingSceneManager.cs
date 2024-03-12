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

    //씬 넘기기
    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    //씬로드 코루틴
    IEnumerator LoadScene()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0.0f;

        //배경오브젝트 color값 가져오기
        Color color1 = render1.color;
        Color color2 = render2.color;

        while (!op.isDone)
        {
            timer =+ Time.time;
            progressBar.fillAmount = timer/5f;

            //배경오브젝트 alpha값 변경
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
            //실제 씬 로딩 시간에 따른 로직
            //게임 커지면 이 로직으로 변경
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

                //배경 alpha값 변경
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
