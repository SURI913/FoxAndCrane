using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowFolloweTarget : MonoBehaviour
{

    public float range = 10f;  // ����ĳ��Ʈ�� �Ÿ�
    public float horizontalAngle = 45f;  // ���� ��ä���� ����
    public float verticalAngle = 30f;    // ���� ��ä���� ����
    public int horizontalRays = 10;      // ���� ���� ����ĳ��Ʈ ����
    public int verticalRays = 5;         // ���� ���� ����ĳ��Ʈ ����
    public float speed = 5f;             // ���󰡴� �ӵ�
    public string targetTag = "Firefly"; // ���� ��� �±� (firefly ������Ʈ�� ������ �±�)

    private Transform target;    // firefly�� Transform�� ������ ����
    private Vector3 originalPosition;  // ���� ��ġ ����

    void Start()
    {
        // ���� ��ġ ����
        originalPosition = transform.position;
    }

    void Update()
    {
        // ��ä�� ����ĳ��Ʈ�� firefly�� �����ϰ�, �߰��ϸ� ���󰡵��� ����
        if (FindTarget())
        {
            FollowTarget();
        }
        else
        {
           
            BackPosition();  // firefly�� ������ ���� ��ġ�� ���ư���
          
        }

        // ��ä�� ����ĳ��Ʈ �߻�
        CastFanRay();
    }

    void CastFanRay()
    {
        float horizontalStep = horizontalAngle / horizontalRays; // ���� ���� ����
        float verticalStep = verticalAngle / verticalRays; // ���� ���� ����

        for (int i = 0; i < horizontalRays; i++)
        {
            for (int j = 0; j < verticalRays; j++)
            {
                // ���� ������ ���� ������ ����Ͽ� 3D �������� ������ ����
                float currentHorizontalAngle = -horizontalAngle / 2 + i * horizontalStep;
                float currentVerticalAngle = -verticalAngle / 2 + j * verticalStep;

                // ȸ�� ���� ���
                Vector3 direction = Quaternion.Euler(currentVerticalAngle, currentHorizontalAngle, 0) * transform.forward;
                RaycastHit hit;

                // ����ĳ��Ʈ �߻�
                if (Physics.Raycast(transform.position, direction, out hit, range))
                {
                    Debug.DrawRay(transform.position, direction * hit.distance, Color.red);
                    if (hit.collider.CompareTag(targetTag)) // firefly�� �߰��ϸ�
                    {
                        target = hit.collider.transform; // �ش� ������Ʈ�� Transform ����
                    }
                }
                else
                {
                    Debug.DrawRay(transform.position, direction * range, Color.green);
                }
            }
        }
    }

    private bool FindTarget()
    {
        // target�� �����ϸ� true ��ȯ, firefly�� ã�� ���
        return target != null;
    }

    private void FollowTarget()
    {
        if (target != null)
        {
            // firefly�� ���� �̵�
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void BackPosition()
    {
        // firefly�� ������ ���� ��ġ�� ���ư���
        transform.position = Vector3.MoveTowards(transform.position, originalPosition, speed * Time.deltaTime);
    }
    /* ref velocity: ���������� �ӵ��� �����ϸ� ���� �� ������ ���
       smoothTime: ���� Ŭ���� �������� ������ �ε巯�����ϴ�.*//*
   [SerializeField]
    private Transform target; 
    private Vector3 velocity = Vector3.zero; 
    private float smoothTime = 0.9f; 
    private float rayDistance = 10f; 
    

    private float horizontalAngleStart = -45f;
    private float horizontalAngleEnd = 30f;
    private float verticalAngleStart = -20f;
    private float verticalAngleEnd = 20f;
    private int horizontalRayCount = 5;
    private int verticalRayCount = 5;

    private void Update()
    {
        float horizontalStep = (horizontalAngleEnd - horizontalAngleStart) / (horizontalRayCount - 1);
        float verticalStep = (verticalAngleEnd - verticalAngleStart) / (verticalRayCount - 1);

        bool targetFound = false;

        // ���� �� ���� ���� �ݺ� �߻�
        for (int v = 0; v < verticalRayCount; v++)
        {
            float verticalAngle = verticalAngleStart + (v * verticalStep);

            for (int h = 0; h < horizontalRayCount; h++)
            {
                float horizontalAngle = horizontalAngleStart + (h * horizontalStep);

                // ���� ���� ��� (���� + ����)
                Vector3 direction = Quaternion.Euler(verticalAngle, horizontalAngle, 0) * transform.forward;

                // ���� ����� �ð�ȭ
                Debug.DrawRay(transform.position, direction * rayDistance, Color.blue, 0.3f);
               
                // �浹 üũ
                if (Physics.Raycast(transform.position, direction, out RaycastHit hit, rayDistance))
                {

                    // Ÿ�� ����
                    target = hit.transform;
                    targetFound = true;
                    Debug.Log($"Ray hit: {hit.transform.name}, Target Found2: {targetFound}");
                    break; // ù ��° �浹�� ó��
                  
                }
            }
            if (targetFound)
            {
               
                FollowTarget();
                break;

            }
            // Ÿ���� ã���� �ߴ�
        }
*//*
        if (targetFound)
        {
          //  FollowTarget(); // Ÿ���� ����
        }
        else
        {
            // Ÿ���� ���� ��� �ʱ�ȭ
            target = null;
            BackPosition(); // ���� ��ġ�� ����
        }*//*
    }

    private void FollowTarget()
    {
        if (target != null)
        {
            // SmoothDamp�� ����� Ÿ�� ��ġ�� �ε巴�� �̵�
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
        }
    }

    private void BackPosition()
    {
        // ���� ��ġ�� ���ư��� ���� (��: �ʱ� ��ġ�� ���ư���)
        Debug.Log("Returning to original position");
    }*/
}
