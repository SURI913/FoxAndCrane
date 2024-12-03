using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour, IInteractable
{
    Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
   public void Interaction(GameObject obj)
    {
        if(obj.transform.childCount == 0)
        {
            Debug.Log("������");
            //�÷��̾� �ڽ����� ���� �����̱�
            transform.SetParent(obj.transform);
        }
        else //���� ���·� ����
        {
            Debug.Log("���Ѵ�");
            transform.SetParent(null);
            //����Ʈ����
            rigid.isKinematic = false;
        }
    }
}
