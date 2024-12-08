using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefly : MonoBehaviour
{
   /* ref velocity: 내부적으로 속도를 추적하며 가속 및 감속을 계산합니다.
      smoothTime: 값이 클수록 움직임이 느리고 부드러워집니다.*/
    public Transform target;
    public float smoothTime = 1f; // 값 클 수록 느리게 따라감 
    private Vector3 velocity = Vector3.zero;
    void  start()
    {
      
    }
    private void Update()
    {
       
    }
    private void followTarget()
    {
        if (target != null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
        }
    }
}
