using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyMove : MonoBehaviour
{
    
    [SerializeField]
    Transform[] arrivePoints; //���� ��ġ
    
    [SerializeField]
    Vector3 returnPosition;

    PickFireFly pickFireFly;


    float distanceRange = 10f;
    Vector3 currentVelocity = Vector3.zero;
    float moveSpeed = 3f;  //��ǥ ���� �ɸ��� �ð�

  

    // Update is called once per frame
    private void Awake()
    {
        pickFireFly = GetComponent<PickFireFly>();
        returnPosition = transform.position;
    }
    void Update()
    {
        //���찡 ������ �̵�
        if(!pickFireFly.isCatch)
        {
            MoveToClosetPoint();
        }
        //�����ϸ� ����
    }
    void MoveToClosetPoint()
    {
        //���� ����� ���� ��ġ ã��
        Transform closetPoint = null; //����� ��������Ʈ
        //float closetDistance = Mathf.Infinity; //�Ÿ�

        foreach(Transform point in arrivePoints)
        {
            float distance = Vector3.Distance(transform.position, point.position);

            if(distance < distanceRange)
            {
                distanceRange = distance;
                closetPoint = point;
            }
        }
        if(closetPoint != null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, closetPoint.position, ref currentVelocity, moveSpeed); //�̵�
            if(transform.position == closetPoint.position)
            {
                pickFireFly.isCatch = true;
            }
            
        }
        else //�����ȿ� ������ ���� �ڸ��� ���ư���
        {
            transform.position = Vector3.SmoothDamp(transform.position, returnPosition, ref currentVelocity, moveSpeed);
            if (transform.position == returnPosition)
            {
                pickFireFly.isCatch = true;
            }

        }
    }
}
