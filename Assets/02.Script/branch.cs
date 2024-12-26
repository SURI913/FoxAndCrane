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
            //rigidbody를 비활성화해서 물리적인 움직임 멈춤
            if (rb != null)
            {
                rb.isKinematic = true;
            }
            //오브젝트 태그 변경
            gameObject.tag = "BridgePart";

            //충돌된 오브젝트의 부모로 설정하여 이어붙이기
            this.transform.parent = collision.transform;
        }
    }
    private IEnumerator ReturnToPoolAfterDelay()
    {
        yield return new WaitForSeconds(5f); 

        if (obstacleManager != null)
        {
            // ObstacleManager통해 풀로 반환
            obstacleManager.ReturnObstacle("Branch", this.gameObject);
        }
        else
        {
            Debug.LogError("");
        }
    }

}
