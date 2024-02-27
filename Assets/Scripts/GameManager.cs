using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void GameStart()
    {
        Debug.Log("버튼눌림");
        LoadingSceneManager.LoadScene("Basecamp");
    }
}
