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
        //���� ���� ��ư ���� �� LoadingSceneManager�� ���� ���̽�ķ�� ������ �̵�
        LoadingSceneManager.LoadScene("Basecamp");
    }
}
