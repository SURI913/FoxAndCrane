using Default;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMatcher : MonoBehaviour
{
    public Transform targetShadow; // 목표 그림자의 Transform
    public float positionTolerance = 0.1f; // 위치 판정 허용 오차
    public float rotationTolerance = 5f; // 회전 판정 허용 오차 (도 단위)

    public GameObject particleObj;

    public float countdownTime = 10f; // 타이머 초기화 시간 (초 단위)
    private float currentTime;       // 현재 타이머 값
    private bool timerRunning = false; // 타이머 실행 상태

    public bool isPlayerGrabCheck;

    public GameObject RookObject;

    private SwichingCamera myCleartData;


    private void Start()
    {
        myCleartData = GetComponentInParent<SwichingCamera>();
    }
    private void Update()
    {
        CheckMatch();

        if (timerRunning)
        {
            // 타이머가 0보다 클 때만 감소
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                //Debug.Log($"남은 시간: {currentTime:F2}초");
            }
            else
            {
                currentTime = 0;
                timerRunning = false;
                ShowHint(); //n 초 뒤 힌트 제공
            }
        }
    }

    private void OnEnable()
    {
        // 타이머 초기화
        currentTime = countdownTime;
        timerRunning = true;

    }

    void CheckMatch()
    {
        // 위치 차이 계산
        float positionDifference = Vector3.Distance(transform.position, targetShadow.position);

        // 회전 차이 계산
        float rotationDifference = Quaternion.Angle(transform.rotation, targetShadow.rotation);


        // 판정
        if (positionDifference < positionTolerance && rotationDifference < rotationTolerance 
            && isPlayerGrabCheck == PlayerData.isGrabTorch)
        {
            Debug.Log("매칭 성공!");
            OnMatchSuccess();
        }
    }

    void OnMatchSuccess()
    {
        // 매칭 성공 처리 (예: 다음 단계로 이동, 효과 재생)
        Debug.Log("정답 처리 완료!");
        RookObject.SetActive(false);
        myCleartData.isClear = true;
    }

    private void ShowHint()
    {
        particleObj.SetActive(true);
    }
    private void HideHint()
    {
        particleObj.SetActive(false);

    }
}
