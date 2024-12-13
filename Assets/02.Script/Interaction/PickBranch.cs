using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickBranch : MonoBehaviour, ICraneInteractable
{
    Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    public void Interaction(CraneInteraction obj)
    {
        if (obj.transform.childCount == 0)
        {
            //�÷��̾� �ڽ����� ���� �����̱�
            transform.SetParent(obj.transform);

            //���ڽ� ��ġ ���� �ʿ�
        }
        else //���� ���·� ����
        {
            transform.SetParent(null);

            //����Ʈ����
            if (!rigid) return;
            rigid.isKinematic = false;
        }
    }
}
