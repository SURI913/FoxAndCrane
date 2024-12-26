using System.Collections;
using UnityEngine;
using System;

public class SwichingCamera : MonoBehaviour
{
    public GameObject[] cameraGroup = new GameObject[2];
    public GameObject lightObject;
    private bool isChange;

    public static event Action OnSwichMovement;

    public float rotationDuration = 2f; // ȸ�� �ð� (��)

    private Coroutine currentRotationCoroutine; // ���� ���� ���� �ڷ�ƾ

    private void Start()
    {
        isChange = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        
        //�÷��̾� ĳ���� ���� �� ȭ�� ��ȯ�ϴ� �� ĳ���Ͱ� �ΰ��ϱ� �� �� �����ؾ��� �ǵ��� �ؾ��ϳ�?
        if (collision.CompareTag("Player") && !isChange)
        {
            
            // ���� �ڷ�ƾ ���� �� ���ο� �ڷ�ƾ ����
            StartLightRotation(Quaternion.Euler(50, -30, 0), Quaternion.Euler(0, 70, 0));
            //ī�޶� ȸ���Ǹ� �����ӵ� �ٲ��
            cameraGroup[0].SetActive(false);
            cameraGroup[1].SetActive(true);
            isChange = true;
            OnSwichMovement?.Invoke();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        //�÷��̾� ĳ���� ���� �� ȭ�� ��ȯ
        if (collision.CompareTag("Player") && isChange)
        {
            // ���� �ڷ�ƾ ���� �� ���ο� �ڷ�ƾ ����
            StartLightRotation(Quaternion.Euler(0, 70, 0), Quaternion.Euler(50, -30, 0));
            cameraGroup[0].SetActive(true);
            cameraGroup[1].SetActive(false);
            isChange = false;
            OnSwichMovement?.Invoke();
            //ī�޶� ��ȯ �߿� �÷��̾� ������ ���ƾ��� �� ������ �̰� ��� �ұ�?
        }
    }

    //�ߺ����� ������
    private void StartLightRotation(Quaternion startRotation, Quaternion endRotation)
    {
        // ���� �ڷ�ƾ ����
        if (currentRotationCoroutine != null)
        {
            StopCoroutine(currentRotationCoroutine);
        }

        // ���ο� �ڷ�ƾ ����
        currentRotationCoroutine = StartCoroutine(RotateLight(startRotation, endRotation));
    }

    private IEnumerator RotateLight(Quaternion startRotation, Quaternion endRotation)
    {
        float remainingAngle = Quaternion.Angle(startRotation, endRotation);
        while (remainingAngle > 0.1f) // �ּ� ���� ���̰� �� ������ �ݺ�
        {
            float step = Time.deltaTime / rotationDuration * remainingAngle;
            lightObject.transform.rotation = Quaternion.RotateTowards(lightObject.transform.rotation, endRotation, step); //Lerp���� ���� ����
            remainingAngle = Quaternion.Angle(lightObject.transform.rotation, endRotation);
            yield return null;
        }

        // ���������� ��Ȯ�� ��ǥ ������ ����
        lightObject.transform.rotation = endRotation;
        currentRotationCoroutine = null;
    }
}
