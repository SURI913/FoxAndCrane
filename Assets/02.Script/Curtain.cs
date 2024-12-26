using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Curtain : MonoBehaviour
{
    float curtainValue;
    float curtainSpeed;

    [SerializeField]
    Image curtain;

    private void Start()
    {
        curtainValue = 1f;
        curtainSpeed = 0.15f;
    }

    private void Update()
    {
        if (curtainValue > 0)
        {
            CurtainOff();
        }
    }
    public void CurtainOff()//화면 전환
    {
        curtainValue -= Time.deltaTime * curtainSpeed;
        curtain.color = new Color(0f, 0f, 0f, curtainValue);

    }
}
