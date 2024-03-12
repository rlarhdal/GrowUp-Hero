using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectState;
using UnityEngine.SceneManagement;


public class InteractiveObject : MonoBehaviour
{
    public ObjectType ObjectType;
    private Player player;
    private string objectTag;

    void Start()
    {
        objectTag = this.gameObject.tag;    
    }

    public void Interaction()
    {
        switch (ObjectType)
        {
            case ObjectType.eItemObject:
                Debug.Log("아이템입니다.");
                //GameDataManager 오브젝트를 만들어서, 이 오브젝트의 아이템 데이터를 전달하여 저장
                //싱글톤 패턴
                //ex) 보스아이템을 먹기 전 : key = 0 / 보스아이템 먹은 후 : key = 1
                break;
            case ObjectType.eCraftBox:
                Debug.Log("크래프팅 박스입니다.");
                break;
            case ObjectType.eDungeonGate:
                Debug.Log("던전 입구입니다.");
                GameManager.instance.uIManager.gameObject.SetActive(true);
                break;
            case ObjectType.eStorageBox:
                Debug.Log("저장소입니다.");
                break;
            default: 
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) 
        {
            player = collision.gameObject.GetComponent<Player>();

            if(player != null)
            {
                player.InteractiveObject = this;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(player != null)
            {
                player.InteractiveObject = null;
                player = null;
            }
        }
    }

}
