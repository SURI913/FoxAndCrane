using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTimeZone : MonoBehaviour
{
    public GameObject lightObject;
    public Quaternion rotateValue;

    public float rotationDuration = 2f; // ȸ�� �ð� (��)

    private bool isChange;

    enum LightType
    {

    }

    struct LightValue{
        public LightValue(Quaternion _quaternion, Color _color)
        {
            quaternion = _quaternion;
            color = _color;
        }
        Quaternion quaternion;
        Color color;
    }
    LightValue dayTime = new LightValue(Quaternion.Euler(50, -30, 0), new Color(255, 244, 214));
    LightValue eveningTime = new LightValue(Quaternion.Euler(40,-45,-20), new Color(180, 150, 145));
    LightValue nightTime = new LightValue(Quaternion.Euler(185, 45, -20), new Color(55, 65, 80));
    LightValue endTime = new LightValue(Quaternion.Euler(0, 70, 0), new Color(180, 150, 145));



    /*
     �⺻ �� : 50 , -30, 0
    color: 255,244,214

     �⺻ ���� : 40, -45 -20
     ���� ����(�׸��� ���) : 0, 70 ,0
    color: 180, 150 145

    �ʹ� ��ο? �̰Ű� �ٽ� ã�ƺ���
    �⺻ ��: 185, 45, -20
    color: 55, 65, 80
     */

    private void Start()
    {
        isChange = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&& !isChange)
        {
            isChange = true;
            StartCoroutine(RotateLight(lightObject.transform.rotation, rotateValue));
        }
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
    }
}
