using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutFireFly : MonoBehaviour, IFoxInteractable
{
    [SerializeField]
    Transform[] arrivePoints;

    //float distanceThreshold; //도착으로 간주할 거리
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
        //이동 시작

    }
    void MoveToClosestPoint()
    {
        //가장 가까운 도착위치 찾기
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
            transform.position = Vector3.SmoothDamp(transform.position, closestPoint.position, ref currentVelocity, moveSpeed); //이동
        }
    }
}

//랜덤으로 이동
//void MoveToClosetPoint()
//{
//    //가장 가까운 도착 위치 찾기
//    Transform closestPoint = null; //가까운 도착포인트

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
//        // 랜덤 오프셋 적용
//        Vector3 targetPosition = closestPoint.position + randomOffset;
//        //목표 지점 근처로 이동
//        transform.position = Vector3.SmoothDamp(transform.position, closestPoint.position, ref currentVelocity, moveSpeed); //이동
//        if (Vector3.Distance(transform.position, targetPosition) <= distanceThreshold)
//        {
//            pickFireFly.isCatch = true;
//        }

//    }
//    else //범위안에 없으면 원래 자리로 돌아가기
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
//    float xOffset = Random.Range(-3f, 3f); // X축 랜덤값
//    float yOffset = Random.Range(-0.5f, 0.5f); // Y축 랜덤값 (좀 더 좁게 설정)
//    float zOffset = Random.Range(-1f, 1f); // Z축 랜덤값
//    return new Vector3(xOffset, yOffset, zOffset);
//}