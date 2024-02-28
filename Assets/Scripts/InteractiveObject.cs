using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectState;


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
        /*if (ObjectType == ObjectType.eItemObject)
        {
            
        }
        else if (ObjectType == ObjectType.eCraftBox)
        {
            Debug.Log("ũ������ �ڽ��Դϴ�.");
        }
        else if (ObjectType == ObjectType.eStorageBox)
        {
            Debug.Log("������Դϴ�.");
        }
        else if (ObjectType == ObjectType.eDungeonGate)
        {
            Debug.Log("���� �Ա��Դϴ�.");
        }*/

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
