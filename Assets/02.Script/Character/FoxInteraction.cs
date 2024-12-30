using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoxInteraction : PlayerInteraction
{
    
    public Image keyG;
    public float sphereRadius; // 구의 반지름
    public float rayLength;// 레이 길이
    public Color debugColor = Color.red; // Debug 색상
    private void Update()
    {
        HitRayCast();
    }
    protected override void HitRayCast()
    {
        // Ray의 시작 위치와 방향
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        RaycastHit hit;
        if (Physics.SphereCast(origin, sphereRadius, direction, out hit, rayLength))
        {
            IFoxInteractable interactable = hit.collider.GetComponent<IFoxInteractable>();
            if (interactable != null)
            {
                keyG.color = Color.white;

                if (Input.GetKeyDown(KeyCode.G)) //상호작용
                {
                    interactable.Interaction(this);
                }
            }
        }
        else
        {
            keyG.color = new Color(0f, 0f, 0f, 0f); // 상호작용 불가능 시 색 변경
        }
        // Debug 시각화
        Debug.DrawLine(origin, origin + direction * rayLength, debugColor); // Ray 시각화
        DrawSphereAtRayEnd(origin + direction * rayLength, sphereRadius); // Ray 끝에 Sphere 시각화
    }

    void DrawSphereAtRayEnd(Vector3 position, float radius)
    {
        // Sphere를 표현하기 위한 다양한 방향
        Debug.DrawRay(position, Vector3.up * radius, debugColor);
        Debug.DrawRay(position, Vector3.down * radius, debugColor);
        Debug.DrawRay(position, Vector3.left * radius, debugColor);
        Debug.DrawRay(position, Vector3.right * radius, debugColor);
        Debug.DrawRay(position, Vector3.forward * radius, debugColor);
        Debug.DrawRay(position, Vector3.back * radius, debugColor);
    }

}
