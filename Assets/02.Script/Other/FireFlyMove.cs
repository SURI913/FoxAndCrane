using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyMove : MonoBehaviour
{
    
    [SerializeField]
    Transform[] arrivePoints; //도착 위치
    
    [SerializeField]
    Vector3 returnPosition;

    PickFireFly pickFireFly;


    float distanceRange = 10f;
    Vector3 currentVelocity = Vector3.zero;
    float moveSpeed = 3f;  //목표 지점 걸리는 시간

  

    // Update is called once per frame
    private void Awake()
    {
        pickFireFly = GetComponent<PickFireFly>();
        returnPosition = transform.position;
    }
    void Update()
    {
        //여우가 놓으면 이동
        if(!pickFireFly.isCatch)
        {
            MoveToClosetPoint();
        }
        //도착하면 종료
    }
    void MoveToClosetPoint()
    {
        //가장 가까운 도착 위치 찾기
        Transform closetPoint = null; //가까운 도착포인트
        //float closetDistance = Mathf.Infinity; //거리

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
            transform.position = Vector3.SmoothDamp(transform.position, closetPoint.position, ref currentVelocity, moveSpeed); //이동
            if(transform.position == closetPoint.position)
            {
                pickFireFly.isCatch = true;
            }
            
        }
        else //범위안에 없으면 원래 자리로 돌아가기
        {
            transform.position = Vector3.SmoothDamp(transform.position, returnPosition, ref currentVelocity, moveSpeed);
            if (transform.position == returnPosition)
            {
                pickFireFly.isCatch = true;
            }

        }
    }
}
