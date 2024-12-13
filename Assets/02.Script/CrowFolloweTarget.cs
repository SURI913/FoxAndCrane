using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowFolloweTarget : MonoBehaviour
{
    /* ref velocity: ���������� �ӵ��� �����ϸ� ���� �� ������ ���
       smoothTime: ���� Ŭ���� �������� ������ �ε巯�����ϴ�.*/
    [SerializeField]
    private Transform target; //�ݵ����� Ÿ����
    private float smoothTime = 1f; // �� Ŭ ���� ������ ���� 
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
