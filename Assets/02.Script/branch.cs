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
            Debug.Log("ground 와 닿음 ");

            //rigidbody를 비활성화 물리적인 움직임 멈춤
            if (rb != null)
            {
                rb.isKinematic = true;
            }

            //오브젝트 태그 변경
            gameObject.tag = "BridgePart";

            //충돌된 오브젝트 부모로 설정 이어붙이기
            this.transform.parent = collision.transform;

           
            branchCount++;
            Debug.Log(branchCount);

            // Branch가 5개 충돌했을 때 Log 생성
            if (branchCount >= 2)
            {
                Instantiate(logPrefab, collision.transform.position, Quaternion.identity);
                branchCount = 0; // 카운트 초기화
            }

            // 기존 코드 유지 - ObstacleManager와 ReturnToPoolAfterDelay
            StartCoroutine(ReturnToPool());
        }
    }

    private IEnumerator ReturnToPool()
    {
        yield return new WaitForSeconds(5f);

        if (obstacleManager != null)
        {
            //ObstacleManager통해 풀로 반환
            obstacleManager.ReturnObstacle("Branch", this.gameObject);
        }
        else
        {
            Debug.LogError("ObstacleManager is not set");
        }
    }

}
