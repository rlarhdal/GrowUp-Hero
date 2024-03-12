using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("# Game Control")]
    public bool isDungeon;

    [Header("# Player Info")]
    public float health;
    public float maxHealth = 100;
    public float level;
    public float kill;
    public int exp;
    public int[] nextExp = { };

    [Header("# GameObject")]
    public Player player;
    public UIManager uIManager;

    void Awake()
    {
        instance = this;
    }

    public void GameStart()
    {
        //게임 시작 버튼 누를 시 LoadingSceneManager를 통해 베이스캠프 씬으로 이동
        LoadingSceneManager.LoadScene("Basecamp");
    }
}
