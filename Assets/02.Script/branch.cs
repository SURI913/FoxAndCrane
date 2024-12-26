using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    private Rigidbody rb;
    private ObstacleManager obstacleManager;


    void Start()
    {
        
        rb = GetComponent<Rigidbody>();

        obstacleManager = FindObjectOfType<ObstacleManager>();
        if (obstacleManager == null)
        {
          //  Debug.LogError("is not null");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            //rigidbody�� ��Ȱ��ȭ�ؼ� �������� ������ ����
            if (rb != null)
            {
                rb.isKinematic = true;
            }
            //������Ʈ �±� ����
            gameObject.tag = "BridgePart";

            //�浹�� ������Ʈ�� �θ�� �����Ͽ� �̾���̱�
            this.transform.parent = collision.transform;
        }
    }
    private IEnumerator ReturnToPoolAfterDelay()
    {
        yield return new WaitForSeconds(5f); 

        if (obstacleManager != null)
        {
            // ObstacleManager���� Ǯ�� ��ȯ
            obstacleManager.ReturnObstacle("Branch", this.gameObject);
        }
        else
        {
            Debug.LogError("");
        }
    }

}
