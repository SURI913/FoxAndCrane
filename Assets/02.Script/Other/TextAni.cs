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
        //���콺 ��ġ �������� raycast����
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = Input.mousePosition;

        //raycast ��� ����
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);
    

        //raycast ����� text�� ���ԵǾ� �ִ��� Ȯ��
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
