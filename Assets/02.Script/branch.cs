using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    private Rigidbody rb; // Rigidbody ������Ʈ ����

    void Start()
    {
        // Rigidbody �ʱ�ȭ
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Ground�� �ٸ� ������Ʈ�� �浹���� ��
        if (collision.gameObject.CompareTag("BridgePart"))
        {
            // rigidbody�� ��Ȱ��ȭ�ؼ� �������� ������ ����
            if (rb != null)
            {
                rb.isKinematic = true;
            }
            //������Ʈ �±� ����
            gameObject.tag = "BridgePart";

            // �浹�� ������Ʈ�� �θ�� �����Ͽ� �̾���̱�
            this.transform.parent = collision.transform;
        }
    }
}
