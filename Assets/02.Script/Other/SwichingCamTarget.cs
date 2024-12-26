using Cinemachine;
using Default;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwichingCamTarget : MonoBehaviour
{
    CinemachineTargetGroup targetGroup;

    private float fristWight = 1f;
    private float secondWight = 0.1f;
    void Start()
    {
        targetGroup = GetComponent<CinemachineTargetGroup>();
        //시작이 여우니까 세팅은 여우로
    }

    private void OnEnable()
    {
        // 이벤트 구독
        PlayerMovement.OnSwitchObject += OnSwichCamera;
    }

    private void OnDisable()
    {
        // 이벤트 구독 해제
        PlayerMovement.OnSwitchObject -= OnSwichCamera;
    }

    //표준 이벤트 구독자 시그니처
    private void OnSwichCamera()
    {
        if (targetGroup == null) { Debug.Log("카메라 타켓그룹 없음"); }
        if (PlayerData.currentPlayer == PlayerType.Fox)
        {
            targetGroup.m_Targets[0].weight = fristWight; //여우 
            targetGroup.m_Targets[1].weight = secondWight; //두루미
        }
        else if (PlayerData.currentPlayer == PlayerType.Crane)
        {
            targetGroup.m_Targets[0].weight = secondWight; //여우 
            targetGroup.m_Targets[1].weight = fristWight; //두루미
        }
    }
}
