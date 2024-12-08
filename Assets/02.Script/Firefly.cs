using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefly : MonoBehaviour
{
   /* ref velocity: ���������� �ӵ��� �����ϸ� ���� �� ������ ����մϴ�.
      smoothTime: ���� Ŭ���� �������� ������ �ε巯�����ϴ�.*/
    public Transform target;
    public float smoothTime = 1f; // �� Ŭ ���� ������ ���� 
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
