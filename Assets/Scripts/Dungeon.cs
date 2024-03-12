using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dungeon : MonoBehaviour
{
    public Vector2 playerSpawn;

    public Player player;
    public GameObject position;
    public CinemachineVirtualCamera virtualCamera;

    void Awake()
    {
        player = GameManager.instance.player;
        playerSpawn = position.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        player.gameObject.transform.position = playerSpawn;
        virtualCamera.Follow = player.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
