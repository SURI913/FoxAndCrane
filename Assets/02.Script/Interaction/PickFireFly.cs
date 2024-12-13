using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickFireFly : MonoBehaviour, IFoxInteractable
{
    public bool isCatch;
    public void Interaction(FoxInteraction obj)
    {
        if (obj.transform.childCount == 0)
        {
            isCatch = true;
            //�÷��̾� �ڽ����� ���� �����̱�
            transform.SetParent(obj.transform);

            //���ڽ� ��ġ ���� �ʿ�
        }
        else //���� ���·� ����
        {
            transform.SetParent(null);
            isCatch = false;
        }
    }
}
