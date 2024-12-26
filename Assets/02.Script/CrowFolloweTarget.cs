using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowFolloweTarget : MonoBehaviour
{

    public float range = 10f;  // 레이캐스트의 거리
    public float horizontalAngle = 45f;  // 수평 부채꼴의 각도
    public float verticalAngle = 30f;    // 수직 부채꼴의 각도
    public int horizontalRays = 10;      // 수평 방향 레이캐스트 개수
    public int verticalRays = 5;         // 수직 방향 레이캐스트 개수
    public float speed = 5f;             // 따라가는 속도
    public string targetTag = "Firefly"; // 따라갈 대상 태그 (firefly 오브젝트에 설정된 태그)

    private Transform target;    // firefly의 Transform을 저장할 변수
    private Vector3 originalPosition;  // 원래 위치 저장

    void Start()
    {
        // 원래 위치 저장
        originalPosition = transform.position;
    }

    void Update()
    {
        // 부채꼴 레이캐스트로 firefly를 감지하고, 발견하면 따라가도록 설정
        if (FindTarget())
        {
            FollowTarget();
        }
        else
        {
           
            BackPosition();  // firefly가 없으면 원래 위치로 돌아가기
          
        }

        // 부채꼴 레이캐스트 발사
        CastFanRay();
    }

    void CastFanRay()
    {
        float horizontalStep = horizontalAngle / horizontalRays; // 수평 각도 간격
        float verticalStep = verticalAngle / verticalRays; // 수직 각도 간격

        for (int i = 0; i < horizontalRays; i++)
        {
            for (int j = 0; j < verticalRays; j++)
            {
                // 수평 각도와 수직 각도를 계산하여 3D 공간에서 방향을 구함
                float currentHorizontalAngle = -horizontalAngle / 2 + i * horizontalStep;
                float currentVerticalAngle = -verticalAngle / 2 + j * verticalStep;

                // 회전 벡터 계산
                Vector3 direction = Quaternion.Euler(currentVerticalAngle, currentHorizontalAngle, 0) * transform.forward;
                RaycastHit hit;

                // 레이캐스트 발사
                if (Physics.Raycast(transform.position, direction, out hit, range))
                {
                    Debug.DrawRay(transform.position, direction * hit.distance, Color.red);
                    if (hit.collider.CompareTag(targetTag)) // firefly를 발견하면
                    {
                        target = hit.collider.transform; // 해당 오브젝트의 Transform 저장
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
        // target이 존재하면 true 반환, firefly를 찾은 경우
        return target != null;
    }

    private void FollowTarget()
    {
        if (target != null)
        {
            // firefly를 향해 이동
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void BackPosition()
    {
        // firefly가 없으면 원래 위치로 돌아가기
        transform.position = Vector3.MoveTowards(transform.position, originalPosition, speed * Time.deltaTime);
    }
    /* ref velocity: 내부적으로 속도를 추적하며 가속 및 감속을 계산
       smoothTime: 값이 클수록 움직임이 느리고 부드러워집니다.*//*
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

        // 수직 및 수평 레이 반복 발사
        for (int v = 0; v < verticalRayCount; v++)
        {
            float verticalAngle = verticalAngleStart + (v * verticalStep);

            for (int h = 0; h < horizontalRayCount; h++)
            {
                float horizontalAngle = horizontalAngleStart + (h * horizontalStep);

                // 레이 방향 계산 (수평 + 수직)
                Vector3 direction = Quaternion.Euler(verticalAngle, horizontalAngle, 0) * transform.forward;

                // 레이 디버그 시각화
                Debug.DrawRay(transform.position, direction * rayDistance, Color.blue, 0.3f);
               
                // 충돌 체크
                if (Physics.Raycast(transform.position, direction, out RaycastHit hit, rayDistance))
                {

                    // 타겟 설정
                    target = hit.transform;
                    targetFound = true;
                    Debug.Log($"Ray hit: {hit.transform.name}, Target Found2: {targetFound}");
                    break; // 첫 번째 충돌만 처리
                  
                }
            }
            if (targetFound)
            {
               
                FollowTarget();
                break;

            }
            // 타겟을 찾으면 중단
        }
*//*
        if (targetFound)
        {
          //  FollowTarget(); // 타겟을 따라감
        }
        else
        {
            // 타겟이 없을 경우 초기화
            target = null;
            BackPosition(); // 원래 위치로 복귀
        }*//*
    }

    private void FollowTarget()
    {
        if (target != null)
        {
            // SmoothDamp를 사용해 타겟 위치로 부드럽게 이동
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
        }
    }

    private void BackPosition()
    {
        // 원래 위치로 돌아가는 로직 (예: 초기 위치로 돌아가기)
        Debug.Log("Returning to original position");
    }*/
}
