using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Default;

public class RotateTimeZone : MonoBehaviour
{
    public GameObject lightObject;
    private  Quaternion rotateValue;
    private Color colorValue;
    private float intensityValue;

    public float rotationDuration = 2f; // ȸ�� �ð� (��)

    public bool isChange;
    private Light myLight;

    public Default.LightType myType;

    struct LightValue{
        public LightValue(Quaternion _quaternion, Color _color, float _intensity)
        {
            quaternion = _quaternion;
            color = _color;
            intensity = _intensity;
        }
        public Quaternion quaternion;
        public Color color;
        public float intensity;
    }
    LightValue dayTime = new LightValue(Quaternion.Euler(50, -30, 0), new Color(255/255f, 244/255f, 214 / 255f), 1);
    LightValue eveningTime = new LightValue(Quaternion.Euler(40,-45,-20), new Color(180 / 255f, 150 / 255f, 145 / 255f), 1);
    LightValue nightTime = new LightValue(Quaternion.Euler(185, 45, -20), new Color(55 / 255f, 65 / 255f, 80 / 255f), 1);
    LightValue dawmTime = new LightValue(Quaternion.Euler(-5, 30, 10), new Color(15 / 255f, 35 / 255f, 85 / 255f), 40);
    LightValue endTime = new LightValue(Quaternion.Euler(0, 70, 0), new Color(180 / 255f, 150 / 255f, 145 /255f), 1);



    /*
     �⺻ �� : 50 , -30, 0
    color: 255,244,214

     �⺻ ���� : 40, -45 -20
     ���� ����(�׸��� ���) : 0, 70 ,0
    color: 180, 150 145

    �ʹ� ��ο? �̰Ű� �ٽ� ã�ƺ���
    �⺻ ��: -100, 45, -20
    color: 55, 65, 80
     */

    private void Start()
    {
        myLight = lightObject.GetComponent<Light>();
        isChange = false;
        switch (myType)
        {
            case Default.LightType.DayTime:
                intensityValue = dayTime.intensity;
                rotateValue = dayTime.quaternion;
                colorValue = dayTime.color;
                break;
            case Default.LightType.EveningTime:
                intensityValue = eveningTime.intensity;
                rotateValue = eveningTime.quaternion;
                colorValue = eveningTime.color;
                break;
            case Default.LightType.NightTime:
                intensityValue = nightTime.intensity;
                rotateValue = nightTime.quaternion; 
                colorValue= nightTime.color;
                break;
            case Default.LightType.DawmTime:
                intensityValue = dawmTime.intensity;
                rotateValue = dawmTime.quaternion;
                colorValue = dawmTime.color;
                break;
            case Default.LightType.EndTime:
                intensityValue = endTime.intensity;
                rotateValue = endTime.quaternion;
                colorValue = endTime.color;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&& !isChange && MapData.currnetLight != myType)
        {
            Debug.Log(other.name+"�� ���� Ȱ��ȭ");
            isChange = true;
            MapData.currnetLight = myType;
            myLight.intensity = intensityValue;
            myLight.color = colorValue;
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
