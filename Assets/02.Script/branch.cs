using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    private Rigidbody rb;
    private static int branchCount = 0; 
    public GameObject logPrefab; 
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
        if (collision.gameObject.CompareTag("Water"))
        {
            Debug.Log("ground �� ���� ");

            //rigidbody�� ��Ȱ��ȭ �������� ������ ����
            if (rb != null)
            {
                rb.isKinematic = true;
            }

            //������Ʈ �±� ����
            gameObject.tag = "BridgePart";

            //�浹�� ������Ʈ �θ�� ���� �̾���̱�
            this.transform.parent = collision.transform;

           
            branchCount++;
            Debug.Log(branchCount);

            // Branch�� 5�� �浹���� �� Log ����
            if (branchCount >= 2)
            {
                Instantiate(logPrefab, collision.transform.position, Quaternion.identity);
                branchCount = 0; // ī��Ʈ �ʱ�ȭ
            }

            // ���� �ڵ� ���� - ObstacleManager�� ReturnToPoolAfterDelay
            StartCoroutine(ReturnToPool());
        }
    }

    private IEnumerator ReturnToPool()
    {
        yield return new WaitForSeconds(5f);

        if (obstacleManager != null)
        {
            //ObstacleManager���� Ǯ�� ��ȯ
            obstacleManager.ReturnObstacle("Branch", this.gameObject);
        }
        else
        {
            Debug.LogError("ObstacleManager is not set");
        }
    }

}
