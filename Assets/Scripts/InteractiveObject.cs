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
                Debug.Log("�������Դϴ�.");
                //GameDataManager ������Ʈ�� ����, �� ������Ʈ�� ������ �����͸� �����Ͽ� ����
                //�̱��� ����
                //ex) ������������ �Ա� �� : key = 0 / ���������� ���� �� : key = 1
                break;
            case ObjectType.eCraftBox:
                Debug.Log("ũ������ �ڽ��Դϴ�.");
                break;
            case ObjectType.eDungeonGate:
                Debug.Log("���� �Ա��Դϴ�.");
                GameManager.instance.uIManager.gameObject.SetActive(true);
                break;
            case ObjectType.eStorageBox:
                Debug.Log("������Դϴ�.");
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
