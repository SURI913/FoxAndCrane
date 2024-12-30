using Default;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMatcher : MonoBehaviour
{
    public Transform targetShadow; // ��ǥ �׸����� Transform
    public float positionTolerance = 0.1f; // ��ġ ���� ��� ����
    public float rotationTolerance = 5f; // ȸ�� ���� ��� ���� (�� ����)

    public GameObject particleObj;

    public float countdownTime = 10f; // Ÿ�̸� �ʱ�ȭ �ð� (�� ����)
    private float currentTime;       // ���� Ÿ�̸� ��
    private bool timerRunning = false; // Ÿ�̸� ���� ����

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
            // Ÿ�̸Ӱ� 0���� Ŭ ���� ����
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                //Debug.Log($"���� �ð�: {currentTime:F2}��");
            }
            else
            {
                currentTime = 0;
                timerRunning = false;
                ShowHint(); //n �� �� ��Ʈ ����
            }
        }
    }

    private void OnEnable()
    {
        // Ÿ�̸� �ʱ�ȭ
        currentTime = countdownTime;
        timerRunning = true;

    }

    void CheckMatch()
    {
        // ��ġ ���� ���
        float positionDifference = Vector3.Distance(transform.position, targetShadow.position);

        // ȸ�� ���� ���
        float rotationDifference = Quaternion.Angle(transform.rotation, targetShadow.rotation);


        // ����
        if (positionDifference < positionTolerance && rotationDifference < rotationTolerance 
            && isPlayerGrabCheck == PlayerData.isGrabTorch)
        {
            Debug.Log("��Ī ����!");
            OnMatchSuccess();
        }
    }

    void OnMatchSuccess()
    {
        // ��Ī ���� ó�� (��: ���� �ܰ�� �̵�, ȿ�� ���)
        Debug.Log("���� ó�� �Ϸ�!");
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
