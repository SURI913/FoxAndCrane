using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextAni : MonoBehaviour
{
    public Text[] colorText;


    private void Update()
    {
        foreach(Text targetText in colorText)
        {
            if (IsMouseOverUI(targetText))
            {
                ColorChange(targetText);
            }
            else
            {
                ResetColor(targetText);
            }
        }
        
    }



    bool IsMouseOverUI(Text targetText)
    {
        //마우스 위치 기준으로 raycast생성
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = Input.mousePosition;

        //raycast 결과 대상들
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);
    

        //raycast 결과에 text가 포함되어 있는지 확인
        foreach(RaycastResult result in results)
        { 
            if (result.gameObject == targetText.gameObject)
            {
                return true;
            }
        }
        return false;
    }

    void ColorChange(Text targetText)
    {

            targetText.color = Color.red;
    }
    void ResetColor(Text targetText)
    {
            targetText.color = Color.white;
    }
}
