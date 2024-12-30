using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickFruit : MonoBehaviour, ICraneInteractable //�ڽ����� �ϸ� ��������
{

    bool isAttached = false;
    [SerializeField]
    Transform craneTransform;
    Vector3 offset; //�η�̿� ���� ������ �ʱ� ����� ��ġ

    //�η�� ���¸� �����ϴ� ���� ����
    public static bool isFruitAttachedToCrane = false;
    void LateUpdate()
    {
        if(isAttached && craneTransform != null)
        {
            //���Ÿ� �η�� ��� ��ġ ����
            transform.position = craneTransform.position + offset;
        }
    }
    public void Interaction(CraneInteraction obj) //�ڽ����� ������ Ʈ���� �ڽĿ��� ����
    {
        if(!isAttached && !isFruitAttachedToCrane) //�η�̿� ����
        {
            isAttached = true;
            isFruitAttachedToCrane = true; //�ٸ� ���� ��������
            craneTransform = obj.transform;
            offset = transform.position - craneTransform.position;
        }
        else if(isAttached)
        {
            isAttached = false;
            isFruitAttachedToCrane = false;
            craneTransform = null;
        }
    }
   
}
