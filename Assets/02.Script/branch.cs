using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    private Rigidbody rb; // Rigidbody 컴포넌트 저장

    void Start()
    {
        // Rigidbody 초기화
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Ground나 다른 오브젝트와 충돌했을 때
        if (collision.gameObject.CompareTag("BridgePart"))
        {
            // rigidbody를 비활성화해서 물리적인 움직임 멈춤
            if (rb != null)
            {
                rb.isKinematic = true;
            }
            //오브젝트 태그 변경
            gameObject.tag = "BridgePart";

            // 충돌된 오브젝트의 부모로 설정하여 이어붙이기
            this.transform.parent = collision.transform;
        }
    }
}
