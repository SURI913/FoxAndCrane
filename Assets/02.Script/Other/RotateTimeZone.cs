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

    public float rotationDuration = 2f; // 회전 시간 (초)

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
     기본 낮 : 50 , -30, 0
    color: 255,244,214

     기본 저녁 : 40, -45 -20
     도착 저녁(그림자 고려) : 0, 70 ,0
    color: 180, 150 145

    너무 어두운데? 이거값 다시 찾아보자
    기본 밤: -100, 45, -20
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
            Debug.Log(other.name+"이 입장 활성화");
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
        while (remainingAngle > 0.1f) // 최소 각도 차이가 될 때까지 반복
        {
            float step = Time.deltaTime / rotationDuration * remainingAngle;
            lightObject.transform.rotation = Quaternion.RotateTowards(lightObject.transform.rotation, endRotation, step); //Lerp보다 연산 적음
            remainingAngle = Quaternion.Angle(lightObject.transform.rotation, endRotation);
            yield return null;
        }

        // 최종적으로 정확히 목표 각도로 설정
        lightObject.transform.rotation = endRotation;
    }
}
