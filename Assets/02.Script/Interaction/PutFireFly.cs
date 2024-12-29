using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutFireFly : MonoBehaviour, IFoxInteractable
{
    [SerializeField]
    Transform[] arrivePoints;

    //float distanceThreshold; //�������� ������ �Ÿ�
    float distanceRange = 10f;

    float moveSpeed = 3f;
    Vector3 currentVelocity = Vector3.zero;


    bool isPut;

    void Start()
    {
        isPut = false;
        GameObject[] arrivePointObj = GameObject.FindGameObjectsWithTag("WayPoint");
        arrivePoints = new Transform[arrivePointObj.Length];
        for(int i = 0; i < arrivePointObj.Length; i++)
        {
            arrivePoints[i] = arrivePointObj[i].transform;
        }
    }
    void Update()
    {
        if(isPut)
        {
            MoveToClosestPoint();
        }
    }
    public void Interaction(FoxInteraction obj)
    {
        transform.SetParent(null);
        isPut = true;
        //�̵� ����

    }
    void MoveToClosestPoint()
    {
        //���� ����� ������ġ ã��
        Transform closestPoint = null;

        foreach(Transform point in arrivePoints)
        {
            float distance = Vector3.Distance(transform.position, point.position);

            if(distance < distanceRange)
            {
                distanceRange = distance;
                closestPoint = point;
            }
        }
        if(closestPoint != null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, closestPoint.position, ref currentVelocity, moveSpeed); //�̵�
        }
    }
}

//�������� �̵�
//void MoveToClosetPoint()
//{
//    //���� ����� ���� ��ġ ã��
//    Transform closestPoint = null; //����� ��������Ʈ

//    foreach(Transform point in arrivePoints)
//    {
//        float distance = Vector3.Distance(transform.position, point.position);

//        if(distance < distanceRange)
//        {
//            distanceRange = distance;
//            closestPoint = point;
//        }
//    }
//    if(closestPoint != null)
//    {
//        // ���� ������ ����
//        Vector3 targetPosition = closestPoint.position + randomOffset;
//        //��ǥ ���� ��ó�� �̵�
//        transform.position = Vector3.SmoothDamp(transform.position, closestPoint.position, ref currentVelocity, moveSpeed); //�̵�
//        if (Vector3.Distance(transform.position, targetPosition) <= distanceThreshold)
//        {
//            pickFireFly.isCatch = true;
//        }

//    }
//    else //�����ȿ� ������ ���� �ڸ��� ���ư���
//    {
//        transform.position = Vector3.SmoothDamp(transform.position, returnPosition, ref currentVelocity, moveSpeed);
//        if (transform.position == returnPosition)
//        {
//            pickFireFly.isCatch = true;
//        }

//    }
//}
//Vector3 GenerateRandomOffset()
//{
//    float xOffset = Random.Range(-3f, 3f); // X�� ������
//    float yOffset = Random.Range(-0.5f, 0.5f); // Y�� ������ (�� �� ���� ����)
//    float zOffset = Random.Range(-1f, 1f); // Z�� ������
//    return new Vector3(xOffset, yOffset, zOffset);
//}