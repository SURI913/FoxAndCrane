using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowFolloweTarget : MonoBehaviour
{

    private float range = 10f;  // ����ĳ��Ʈ�� �Ÿ�
    private float horizontalAngle = 45f;  // ���� ��ä���� ����
    private float verticalAngle = 10;    // ���� ��ä���� ����
    private int horizontalRays = 6;      // ���� ���� ����ĳ��Ʈ ����
    private int verticalRays = 5;         // ���� ���� ����ĳ��Ʈ ����
    private float speed = 5f;             // ���󰡴� �ӵ�
    private string targetTag = "Firefly"; // ���� ��� �±� (firefly ������Ʈ�� ������ �±�)

    
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
        float horizontalStep = horizontalAngle / (horizontalRays - 1); // ���� ���� ����
        float verticalStep = verticalAngle / (verticalRays - 1);       // ���� ���� ����

        for (int i = 0; i < horizontalRays; i++) // ���� ���� �ݺ�
        {
            for (int j = 0; j < verticalRays; j++) // ���� ���� �ݺ�
            {
                // ���� �� ���� ������ ���
                float currentHorizontalAngle = -horizontalAngle / 2 + i * horizontalStep;
                float currentVerticalAngle = -verticalAngle / 2 + j * verticalStep;

                // ���� ��� (���� �� ���� ��� �ݿ�)
                Vector3 direction = Quaternion.Euler(currentVerticalAngle, currentHorizontalAngle, 0) * Vector3.left;
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
    
}
