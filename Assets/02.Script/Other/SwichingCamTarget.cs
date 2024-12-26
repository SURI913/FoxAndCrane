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
        //������ ����ϱ� ������ �����
    }

    private void OnEnable()
    {
        // �̺�Ʈ ����
        PlayerMovement.OnSwitchObject += OnSwichCamera;
    }

    private void OnDisable()
    {
        // �̺�Ʈ ���� ����
        PlayerMovement.OnSwitchObject -= OnSwichCamera;
    }

    //ǥ�� �̺�Ʈ ������ �ñ״�ó
    private void OnSwichCamera()
    {
        if (targetGroup == null) { Debug.Log("ī�޶� Ÿ�ϱ׷� ����"); }
        if (PlayerData.currentPlayer == PlayerType.Fox)
        {
            targetGroup.m_Targets[0].weight = fristWight; //���� 
            targetGroup.m_Targets[1].weight = secondWight; //�η��
        }
        else if (PlayerData.currentPlayer == PlayerType.Crane)
        {
            targetGroup.m_Targets[0].weight = secondWight; //���� 
            targetGroup.m_Targets[1].weight = fristWight; //�η��
        }
    }
}
