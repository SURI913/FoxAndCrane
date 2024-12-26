using System.Collections;
using UnityEngine;
using System;

public class SwichingCamera : MonoBehaviour
{
    public GameObject[] cameraGroup = new GameObject[2];
    public GameObject lightObject;
    private bool isChange;

    public static event Action OnSwichMovement;

    public float rotationDuration = 2f; // 회전 시간 (초)

    private Coroutine currentRotationCoroutine; // 현재 실행 중인 코루틴

    private void Start()
    {
        isChange = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        
        //플레이어 캐릭터 입장 시 화면 전환하는 걸 캐릭터가 두개니까 둘 다 도착해야지 되도록 해야하나?
        if (collision.CompareTag("Player") && !isChange)
        {
            
            // 기존 코루틴 중지 후 새로운 코루틴 실행
            StartLightRotation(Quaternion.Euler(50, -30, 0), Quaternion.Euler(0, 70, 0));
            //카메라가 회전되면 움직임도 바뀌게
            cameraGroup[0].SetActive(false);
            cameraGroup[1].SetActive(true);
            isChange = true;
            OnSwichMovement?.Invoke();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        //플레이어 캐릭터 입장 시 화면 전환
        if (collision.CompareTag("Player") && isChange)
        {
            // 기존 코루틴 중지 후 새로운 코루틴 실행
            StartLightRotation(Quaternion.Euler(0, 70, 0), Quaternion.Euler(50, -30, 0));
            cameraGroup[0].SetActive(true);
            cameraGroup[1].SetActive(false);
            isChange = false;
            OnSwichMovement?.Invoke();
            //카메라 전환 중엔 플레이어 움직임 막아야할 것 같은데 이거 어떻게 할까?
        }
    }

    //중복실행 방지용
    private void StartLightRotation(Quaternion startRotation, Quaternion endRotation)
    {
        // 기존 코루틴 중지
        if (currentRotationCoroutine != null)
        {
            StopCoroutine(currentRotationCoroutine);
        }

        // 새로운 코루틴 시작
        currentRotationCoroutine = StartCoroutine(RotateLight(startRotation, endRotation));
    }

    private IEnumerator RotateLight(Quaternion startRotation, Quaternion endRotation)
    {
        float remainingAngle = Quaternion.Angle(startRotation, endRotation);
        while (remainingAngle > 0.1f) // 최소 각도 차이가 될 때까지 반복
        {
            float step = Time.deltaTime / rotationDuration * remainingAngle;
            lightObject.transform.rotation = Quaternion.RotateTowards(lightObject.transform.rotation, endRotation, step); //Lerp보다 연산 적음
            remainingAngle = Quaternion.Angle(lightObject.transform.rotation, endRotation);
            yield return null;
        }

        // 최종적으로 정확히 목표 각도로 설정
        lightObject.transform.rotation = endRotation;
        currentRotationCoroutine = null;
    }
}
