using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowFolloweTarget : MonoBehaviour
{
    /* ref velocity: 내부적으로 속도를 추적하며 가속 및 감속을 계산
       smoothTime: 값이 클수록 움직임이 느리고 부드러워집니다.*/
    [SerializeField]
    private Transform target; //반딧불이 타겟임
    private float smoothTime = 1f; // 값 클 수록 느리게 따라감 
    private Vector3 velocity = Vector3.zero;
    private RaycastHit hit;
    private float rayDistance = 10f;
    private Vector3 originPosition;

     void Start()
     {
        originPosition = transform.position;
     }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.blue, 0.3f);

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
        {
            FollowTarget();
        }
        else
        {
            BackPosition();
        }

    }
    private void FollowTarget()
    {
        if (target != null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
        }
    }

    private void BackPosition()
    {
        transform.position = originPosition;
    }
}
